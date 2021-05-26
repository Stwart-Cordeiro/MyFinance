using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Entities.Enums;

namespace Entities.Entities
{
    public class LogSistema
    {
        [Display(Name = "Código")]
        [Key]
        public string IdLogSistema { get; set; }

        [Display(Name = "Json Informação")]
        public string JsonInformacao { get; set; }
        
        [Display(Name = "Tipo Log")]
        public EnumTipoLog TipoLog { get; set; }
        
        [Display(Name = "Nome Controller")]
        public string NomeController { get; set; }
        
        [Display(Name = "Nome Action")]
        public string NomeAction { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}