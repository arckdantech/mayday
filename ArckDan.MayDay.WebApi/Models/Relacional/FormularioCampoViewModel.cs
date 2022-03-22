using System;

namespace ArckDan.MayDay.WebApi.Models.Relacional
{
    public class FormularioCampoViewModel
    {
        #region propriedades

        public int? Id { get; private set; } = null!;
        public int IdFormulario { get; private set; }
        public int IdCampo { get; private set; }
        public DateTime Inclusao { get; private set; }
        public DateTime? Alteracao { get; private set; } = null!;

        #endregion
    }
}
