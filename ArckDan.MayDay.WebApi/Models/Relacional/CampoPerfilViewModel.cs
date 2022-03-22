using ArckDan.MayDay.WebApi.Models.Operacional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArckDan.MayDay.WebApi.Models.Relacional
{
    public class CampoPerfilViewModel
    {
        #region propriedades


        public int? Id { get; set; }

        [JsonIgnore]
        public int IdPerfil { get; set; }

        [JsonIgnore]
        public int IdCampo { get; set; }

        [NotMapped]
        public ICollection<CampoViewModel> Campo { get; set; }

        [NotMapped]
        public ICollection<PerfilViewModel> Perfil { get; set; }

        #endregion
    }
}
