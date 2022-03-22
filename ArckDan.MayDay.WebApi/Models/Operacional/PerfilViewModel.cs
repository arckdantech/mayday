using System;

namespace ArckDan.MayDay.WebApi.Models.Operacional
{
    public class PerfilViewModel
    {
        #region propriedades
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte Ativo { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime? Alteracao { get; set; }

        #endregion
    }
}
