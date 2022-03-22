using System;

namespace ArckDan.MayDay.WebApi.Models.Operacional
{
    public class FormularioViewModel
    {
        #region propriedades

        public int? Id { get; set; }
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime? Alteracao { get; set; }

        #endregion
    }
}
