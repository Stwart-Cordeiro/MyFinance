using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Entities.Enums;
using Entities.Notifications;

namespace Entities.Entities
{
    public class Contas : Notifies
    {
        public string Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }

        [Display(Name = "Status")]
        public EnumStatus Status { get; set; }

        [Display(Name = "Tipo Despesas")]
        public EnumTipoDespesas TipoDespesas { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual Usuario Usuario { get; set; }


        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }
    }
}