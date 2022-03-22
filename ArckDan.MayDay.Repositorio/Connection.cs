using ArckDan.MayDay.Repositorio.Context;
using ArckDan.MayDay.Repositorio.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Data;

namespace ArckDan.MayDay.Repositorio
{
    public abstract class Connection : IDisposable
    {
        #region atributos

        // --> private
        private bool disposed = false;

        // --> protected
        protected IDbConnection _conn;
        protected MayDayContext _db;
        protected IntPtr _handle;

        #endregion

        #region métodos

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        /// <summary>
        /// método para abrir a conexão com o banco de dados para as queries
        /// </summary>
        /// <param name="configuration">objeto de configuração de acesso aos recursos do sistema</param>
        protected void AbrirConexao(IConfiguration configuration, EChaveAcesso chaveAcesso)
        {
            if (chaveAcesso == EChaveAcesso.command)
                _db = new MayDayContext(configuration);
            else {
                _conn = new MayDayContext(configuration).SqlConn;
                _conn.Open();
            }
        }

        /// <summary>
        /// método utilizado para encerrar a conexão com o banco de dados
        /// </summary>
        protected void EncerrarConexao()
        {
            // encerra a conexão com o banco de dados
            _conn.Close();

            // remove os recursos gerenciáveis e não gerenciáveis na memória
            Dispose(disposing: false);
        }

        /// <summary>
        /// método utilizado para dispensar os recursos presos na memória
        /// </summary>
        public void Dispose()
        {
            // chama o dispose para forçar a limpeza do heap
            Dispose(disposing: true);

            // força a passagem do garbage collector
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// método utilizado para controlar a limpeza dos recursos em memória
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            // bloco de construção de objetos
            Component _component = new Component();

            // verifica se o dispose já foi chamado
            if (!disposed)
            {
                // condição para o dispose de recursos gerenciados e não gerenciados
                if (disposing)
                    _component.Dispose();

                // chama os métodos apropriados para limpeza dos recursos não gerenciados
                CloseHandle(_handle);
            }
        }

        #endregion
    }
}