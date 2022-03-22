using System;

namespace ArckDan.MayDay.WebApi.Models.Acesso
{
    public class SenhaViewModel
    {
        #region propriedades

        public int? Id { get; set; }
        public int IdLogin { get; set; }
        public string Chave { get; set; }
        public DateTime Expiracao { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime? Alteracao { get; set; }

        #endregion
    }
}
