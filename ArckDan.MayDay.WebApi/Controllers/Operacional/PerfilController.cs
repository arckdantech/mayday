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
    public class PerfilController : ControllerBase
    {
        #region atributos

        readonly IQuery<PerfilModel> _query;
        readonly ICommandHandler<PerfilModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe PerfilController
        /// </summary>
        /// <parameter name="iconfiguration"></parameter>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public PerfilController(IQuery<PerfilModel> query, ICommandHandler<PerfilModel> command, IMapper mapper)
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
        public RetornoSistema Post([FromBody] PerfilViewModel perfil)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                _command.Post(_mapper.Map<PerfilModel>(perfil));
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
        public RetornoSistema Put([FromBody] PerfilViewModel perfil)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                _command.Put(_mapper.Map<PerfilModel>(perfil));
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
                // executa o processo de inclusão do registro de perfil
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
        public ListagemViewModel<PerfilViewModel> GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                var lista = new ListagemViewModel<PerfilViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registros = _mapper.Map<IEnumerable<PerfilViewModel>>(_query.GetAll())
                };
                return lista;
            }
            catch (SqlException sqlEx)
            {
                return new ListagemViewModel<PerfilViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ListagemViewModel<PerfilViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("consultar/{Id}")]
        [HttpGet]
        public ConsultaViewModel<PerfilViewModel> GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                var registro = new ConsultaViewModel<PerfilViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<PerfilViewModel>(_query.GetById(Id)),
                };

                return registro;
            }
            catch (SqlException sqlEx)
            {
                return new ConsultaViewModel<PerfilViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ConsultaViewModel<PerfilViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("listar/{ativo}")]
        [HttpGet]
        public ListagemViewModel<PerfilViewModel> GetByParameter(bool ativo = true)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de perfil
                var lista = new ListagemViewModel<PerfilViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registros = _mapper.Map<IEnumerable<PerfilViewModel>>(_query.GetAll($"WHERE ATIVO = { Convert.ToByte(ativo) } "))
                };
                return lista;
            }
            catch (SqlException sqlEx)
            {
                return new ListagemViewModel<PerfilViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ListagemViewModel<PerfilViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        #endregion
    }
}