using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Entities.Enums;
using Entities.Notifications;

namespace Entities.Entities
{
    public class Transacoes : Notifies
    {
        [Key]
        public string IdTransacoes { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataTransacao { get; set; }

        [Display(Name = "Despesas")]
        public EnumTipoDespesas TipoDespesas { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal Valor { get; set; }

        [Display(Name = "Descrição")]
        [Column(TypeName = "varchar(200)")]
        public string Descricao { get; set; }
        
        [Display(Name = "Conta")]
        [ForeignKey("Contas")]
        [Column(Order = 1)]
        public string ContaId { get; set; }
        public virtual Contas Contas { get; set; }


        [Display(Name = "Plano de Conta")]
        [ForeignKey("PlanoContas")]
        [Column(Order = 1)]
        public string PlanoContaId { get; set; }
        public virtual PlanoContas PlanoContas { get; set; }

        [Display(Name = "Debito")]
        public bool Debito { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual Usuario Usuario { get; set; }


        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }

        [Display(Name = "Data Iniciao")]
        [NotMapped]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data Final")]
        [NotMapped]
        public DateTime DataFinal { get; set; }       
    }
}