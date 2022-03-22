using System;

namespace ArckDan.MayDay.WebApi.Models.Operacional
{
    public class EnderecoViewModel
    {
        #region propriedades

        public int? Id { get; set; }
        public int IdUsuario { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime? Alteracao { get; set; }

        #endregion
    }
}