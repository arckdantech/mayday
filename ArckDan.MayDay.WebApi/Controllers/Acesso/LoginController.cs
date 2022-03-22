using ArckDan.MayDay.Domain.Models.Acesso;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models.Acesso;
using ArckDan.MayDay.WebApi.Utils.Mensagem;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArckDan.MayDay.WebApi.Controllers.Acesso
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        #region atributos

        readonly IQuery<LoginModel> _query;
        readonly ICommandHandler<LoginModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe LoginController
        /// </summary>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public LoginController(IQuery<LoginModel> query, ICommandHandler<LoginModel> command, IMapper mapper)
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
        public RetornoSistema Post([FromBody] LoginViewModel login)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de login
                _command.Post(_mapper.Map<LoginModel>(login));
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
        public RetornoSistema Put([FromBody] LoginViewModel login)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de alteração do registro de login
                _command.Put(_mapper.Map<LoginModel>(login));
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
                // executa o processo de exclusão do registro de login
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
        public ListagemViewModel GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                // executa a consulta dos registros de login
                var lista = new ListagemViewModel(). (Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registros = _mapper.Map<IEnumerable<LoginViewModel>>(_query.GetAll())
                };
                return lista;
            }
            catch (SqlException sqlEx)
            {
                return new ListagemViewModel<LoginViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ListagemViewModel<LoginViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("consultar/{Id}")]
        [HttpGet]
        public ConsultaViewModel<LoginViewModel> GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa a consulta do registro de login por id
                var registro = new ConsultaViewModel<LoginViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<LoginViewModel>(_query.GetById(Id))
                };

                return registro;
            }
            catch (SqlException sqlEx)
            {
                return new ConsultaViewModel<LoginViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ConsultaViewModel<LoginViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        #endregion
    }
}