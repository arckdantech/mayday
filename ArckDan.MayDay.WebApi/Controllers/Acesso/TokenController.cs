using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models.Acesso;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ArckDan.MayDay.WebApi.Controllers.Acesso
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        #region atributos

        readonly IConfiguration _config;
        readonly IQuery<TokenModel> _query;
        readonly ICommandHandler<TokenModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtures

        /// <summary>
        /// construtor da classe TokenController
        /// </summary>
        /// <param name="config">objeto de configuração da web api</param>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public TokenController
        (
            IConfiguration config,
            IQuery<TokenModel> query,
            ICommandHandler<TokenModel> command,
            IMapper mapper
        )
        {
            _config = config;
            _query = query;
            _command = command;
            _mapper = mapper;
        }

        #endregion

        #region métodos

        [HttpPost]
        public string GerarToken([FromBody] TokenViewModel tokenViewModel)
        {
            // bloco de variáveis
            bool usuarioValido = ValidarUsuario(tokenViewModel);

            // condição para validar o usuário para gerar token padrão JWT
            if (usuarioValido)
            {
                // prepara para gerar o token de autorização
                var issuer = _config["Jwt:Issuer"];
                var audience = _config["Jwt:Audience"];
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // recebe o token gerado pelo claims de segurança
                var token = new JwtSecurityToken(issuer: issuer, 
                    audience: audience, 
                    expires: DateTime.Now.AddMinutes(120), 
                    signingCredentials: credentials);

                // cria o token padrão JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var stringToken = tokenHandler.WriteToken(token);

                return stringToken;
            }
            else
                return Unauthorized().ToString();

        }


        private bool ValidarUsuario(TokenViewModel tokenViewModel)
        {
            return true;
        }

        #endregion
    }
}