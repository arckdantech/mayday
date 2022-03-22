using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models;
using ArckDan.MayDay.WebApi.Models.Operacional;
using ArckDan.MayDay.WebApi.Models.Sistema;
using ArckDan.MayDay.WebApi.Utils.Mensagem;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArckDan.MayDay.WebApi.Controllers.Operacional
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        #region atributos

        readonly IQuery<UsuarioModel> _query;
        readonly ICommandHandler<UsuarioModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe UsuarioController
        /// </summary>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public UsuarioController(IQuery<UsuarioModel> query, ICommandHandler<UsuarioModel> command, IMapper mapper)
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
        public RetornoSistema Post([FromBody] UsuarioViewModel usuario)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de usuários
                _command.Post(_mapper.Map<UsuarioModel>(usuario));
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
        public RetornoSistema Put([FromBody] UsuarioViewModel usuario)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de alteração do registro de usuários
                _command.Put(_mapper.Map<UsuarioModel>(usuario));
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
                // executa o processo de exclusão do registro de usuários
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
        public ListagemViewModel<UsuarioViewModel> GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                // executa a consulta dos registros de usuário
                var lista = new ListagemViewModel<UsuarioViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registros = _mapper.Map<IEnumerable<UsuarioViewModel>>(_query.GetAll())
                };
                return lista;
            }
            catch (SqlException sqlEx)
            {
                return new ListagemViewModel<UsuarioViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ListagemViewModel<UsuarioViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("consultar/{Id}")]
        [HttpGet]
        public ConsultaViewModel<UsuarioViewModel> GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa a consulta do registro de login por id
                var registro = new ConsultaViewModel<UsuarioViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<UsuarioViewModel>(_query.GetById(Id))
                };

                return registro;
            }
            catch (SqlException sqlEx)
            {
                return new ConsultaViewModel<UsuarioViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ConsultaViewModel<UsuarioViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("listar/{ativo}")]
        [HttpGet]
        public IEnumerable<UsuarioViewModel> GetByParameter(bool ativo = true)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                var lista = new ListagemViewModel<UsuarioViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registros = _mapper.Map<IEnumerable<UsuarioViewModel>>(_query.GetAll($"WHERE ATIVO = { Convert.ToByte(ativo) } "))
                };
                return lista.Registros;
            }
            catch (SqlException sqlEx)
            {
                return new ListagemViewModel<UsuarioViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message).Registros;
            }
            catch (Exception sysEx)
            {
                return new ListagemViewModel<UsuarioViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message).Registros;
            }
        }

        #endregion
    }
}
