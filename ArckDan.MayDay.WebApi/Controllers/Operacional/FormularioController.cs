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
    public class FormularioController : ControllerBase
    {
        #region atributos

        readonly IQuery<FormularioModel> _query;
        readonly ICommandHandler<FormularioModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe FormularioController
        /// </summary>
        /// <parameter name="iconfiguration"></parameter>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public FormularioController(IQuery<FormularioModel> query, ICommandHandler<FormularioModel> command, IMapper mapper)
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
        public RetornoSistema Post([FromBody] FormularioViewModel formulario)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro do formulário
                _command.Post(_mapper.Map<FormularioModel>(formulario));
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
        public RetornoSistema Put([FromBody] FormularioViewModel formulario)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro do formulário
                _command.Put(_mapper.Map<FormularioModel>(formulario));
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
                // executa o processo de inclusão do registro do formulário
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
        public IEnumerable<FormularioViewModel> GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro do formulário
                var lista = new ListagemViewModel<FormularioViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registros = _mapper.Map<IEnumerable<FormularioViewModel>>(_query.GetAll())
                };
                return lista.Registros;
            }
            catch (SqlException sqlEx)
            {
                return new ListagemViewModel<FormularioViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message).Registros;
            }
            catch (Exception sysEx)
            {
                return new ListagemViewModel<FormularioViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message).Registros;
            }
        }

        [Route("consultar/{Id}")]
        [HttpGet]
        public FormularioViewModel GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro do formulário
                var registro = new ConsultaViewModel<FormularioViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<FormularioViewModel>(_query.GetById(Id)),
                };

                return registro.Registro;
            }
            catch (SqlException sqlEx)
            {
                return new ConsultaViewModel<FormularioViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message).Registro;
            }
            catch (Exception sysEx)
            {
                return new ConsultaViewModel<FormularioViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message).Registro;
            }
        }

        #endregion
    }
}