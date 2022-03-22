using ArckDan.MayDay.Domain.Models.Operacional;
using ArckDan.MayDay.Repositorio.Interface;
using ArckDan.MayDay.Servico.Interface;
using ArckDan.MayDay.WebApi.Models;
using ArckDan.MayDay.WebApi.Models.Operacional;
using ArckDan.MayDay.WebApi.Models.Sistema;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArckDan.MayDay.WebApi.Controllers.Operacional
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        #region atributos

        readonly IQuery<EnderecoModel> _query;
        readonly ICommandHandler<EnderecoModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe CampoController
        /// </summary>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public EnderecoController(IQuery<EnderecoModel> query, ICommandHandler<EnderecoModel> command, IMapper mapper)
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
        public RetornoSistema Post([FromBody] EnderecoViewModel endereco)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de endereços
                _command.Post(_mapper.Map<EnderecoModel>(endereco));
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
        public RetornoSistema Put([FromBody] EnderecoViewModel endereco)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de alteração do registro de endereços
                _command.Put(_mapper.Map<EnderecoModel>(endereco));
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
                // executa o processo de exclusão do registro de endereços
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
        public ListagemViewModel<EnderecoViewModel> GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                // executa a consulta dos registros de endereços
                var lista = new ListagemViewModel<EnderecoViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registros = _mapper.Map<IEnumerable<EnderecoViewModel>>(_query.GetAll())
                };
                return lista;
            }
            catch (SqlException sqlEx)
            {
                return new ListagemViewModel<EnderecoViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ListagemViewModel<EnderecoViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("consultar/{Id}")]
        [HttpGet]
        public ConsultaViewModel<EnderecoViewModel> GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa a consulta do registro de endereços por id
                var registro = new ConsultaViewModel<EnderecoViewModel>(Utils.Enums.EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<EnderecoViewModel>(_query.GetById(Id)),
                };

                return registro;
            }
            catch (SqlException sqlEx)
            {
                return new ConsultaViewModel<EnderecoViewModel>(Utils.Enums.EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new ConsultaViewModel<EnderecoViewModel>(Utils.Enums.EMensagem.Erro, sysEx.Message);
            }
        }

        #endregion
    }
}