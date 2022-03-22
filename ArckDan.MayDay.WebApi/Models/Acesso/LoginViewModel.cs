using System;

namespace ArckDan.MayDay.WebApi.Models.Acesso
{
    public class LoginViewModel
    {
        #region propriedades

        public int? Id { get; set; }

        public int IdUsuario { get; set; }

        public string ChaveUsuario { get; set; }

        public DateTime Inclusao { get; set; }

        public DateTime? Alteracao { get; set; }

        #endregion
    }
}
