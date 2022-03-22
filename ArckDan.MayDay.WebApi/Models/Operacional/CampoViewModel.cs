using System;

namespace ArckDan.MayDay.WebApi.Models.Operacional
{
    public class CampoViewModel
    {
        #region propriedades

        public int? Id { get; set; }
        public string Nome { get; set; }
        public string NomeTecnico { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int Tamanho { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime? Alteracao { get; set; }

        #endregion
    }
}
