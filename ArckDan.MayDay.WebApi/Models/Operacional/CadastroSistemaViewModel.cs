using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArckDan.MayDay.WebApi.Models.Operacional
{
    public class CadastroSistemaViewModel
    {
        #region propriedades

        public int? Id { get; set; }
        public int IdLogin { get; set; }
        public int IdFormulario { get; set; }
        public string DadosUsuario { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime? Alteracao { get; set; }

        #endregion
    }
}
