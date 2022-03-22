using System;
using System.Collections.Generic;
using System.Text;

namespace ArckDan.MayDay.Domain.Models.Operacional
{
    public class FormularioConfiguracao
    {
        #region propriedades

        public int? Id { get; set; } = null!;

        public string Nome { get; set; }

        public string Tag { get; set; }

        public DateTime Inclusao { get; set; }

        public DateTime? Alteracao { get; set; }

        #endregion
    }
}
