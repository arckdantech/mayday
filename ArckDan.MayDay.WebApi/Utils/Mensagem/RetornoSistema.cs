using ArckDan.MayDay.WebApi.Utils.Enums;
using System.Collections.Generic;

namespace ArckDan.MayDay.WebApi.Utils.Mensagem
{
    public class RetornoSistema : IRetornoSistema
    {
        #region construtores

        /// <summary>
        /// construtor da classe MensagemViewModel
        /// </summary>
        /// <param name="codigo">código da mensagem</param>
        /// <param name="mensagem"descrição da mensagem></param>
        public RetornoSistema() { }

        #endregion

        #region métodos

        protected string TratarMensagem(string method)
        { 
            switch (method)
            {
                case "Post":
                    return "Registro cadastrado com sucesso";

                case "Put":
                    return "Registro atualizado com sucesso";

                case "Delete":
                    return "Registro excluído com sucesso";

                case "GetAll":
                    return "Foram encontrados os seguintes registros";

                case "GetById":
                    return "Foi encontrado o seguinte registro";
            }
            return null;
        }

        #endregion

        #region propriedades

        public EMensagem Codigo { get; private set; }

        public string Mensagem { get; private set; }

        #endregion
    }
}
