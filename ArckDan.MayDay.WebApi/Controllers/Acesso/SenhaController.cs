using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models.Acesso;
using ArckDan.MayDay.WebApi.Utils.Criptografia;
using ArckDan.MayDay.WebApi.Utils.Mensagem;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;

namespace ArckDan.MayDay.WebApi.Controllers.Acesso
{
    [ApiController]
    [Route("api/[controller]")]
    public class SenhaController : ControllerBase
    {
        #region atributos

        readonly IQuery<SenhaModel> _query;
        readonly ICommandHandler<SenhaModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe SenhaController
        /// </summary>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public SenhaController(IQuery<SenhaModel> query, ICommandHandler<SenhaModel> command, IMapper mapper)
        {
            // bloco de construção de objetos
            _query = query;
            _command = command;
            _mapper = mapper;
        }

        #endregion

        #region métodos

        [Route("incluir")]
        [HttpPost]
        public RetornoSistema Post([FromBody] SenhaViewModel senha)
        {
            // bloco de tratamento de exceção
            try
            {               
                // executa o processo de inclusão do registro de usuário
                _command.Post(_mapper.Map<SenhaModel>(Cripto.Criptografar(senha)));
                return new RetornoSistema(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name);
            }
            catch (SqlException sqlEx)
            {
                return new RetornoSistema(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new RetornoSistema(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("atualizar")]
        [HttpPut]
        public RetornoSistema Put([FromBody] SenhaViewModel senha)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de usuário
                _command.Put(_mapper.Map<SenhaModel>(Cripto.Criptografar(senha)));
                return new RetornoSistema(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name);
            }
            catch (SqlException sqlEx)
            {
                return new RetornoSistema(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new RetornoSistema(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("excluir")]
        [HttpDelete]
        public RetornoSistema Delete(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de usuário
                _command.Delete(Id);
                return new RetornoSistema(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name);
            }
            catch (SqlException sqlEx)
            {
                return new RetornoSistema(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new RetornoSistema(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("listar")]
        [HttpGet]
        public ListagemViewModel<SenhaViewModel> GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de usuário
                var lista = new ListagemViewModel<SenhaViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registros = _mapper.Map<IEnumerable<SenhaViewModel>>(_query.GetAll())
                };
                return lista;
            }
            catch (SqlException sqlEx)
            {
                return new ListagemViewModel<SenhaViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ListagemViewModel<SenhaViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("consultar/{Id}")]
        [HttpGet]
        public ConsultaViewModel<SenhaViewModel> GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de usuário
                var registro = new ConsultaViewModel<SenhaViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<SenhaViewModel>(_query.GetById(Id)),
                };

                return registro;
            }
            catch (SqlException sqlEx)
            {
                return new ConsultaViewModel<SenhaViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ConsultaViewModel<SenhaViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("pesquisar/{idLogin}/{senha}")]
        [HttpGet]
        public ConsultaViewModel<SenhaViewModel> GetByParameter(int idLogin, string senha)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                var registro = new ConsultaViewModel<SenhaViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<SenhaViewModel>(_query.GetAll($"WHERE ID_LOGIN = { idLogin } ").FirstOrDefault())
                };

                return (Cripto.Validar(senha, registro.Registro.Chave)) ? registro : null;
            }
            catch (SqlException sqlEx)
            {
                return new ConsultaViewModel<SenhaViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ConsultaViewModel<SenhaViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        #endregion

        #region propriedades

        private Hash Cripto => new Hash(SHA512.Create());

        #endregion
    }
}