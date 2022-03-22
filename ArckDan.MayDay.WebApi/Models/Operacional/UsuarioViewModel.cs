using ArckDan.MayDay.WebApi.Models.Sistema;
using System;

namespace ArckDan.MayDay.WebApi.Models.Operacional
{
    public class UsuarioViewModel
    {
        #region propriedades

        public int? Id { get; set; }
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime? Alteracao { get; set; }

        #endregion
    }
}
