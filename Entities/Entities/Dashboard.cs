using System.ComponentModel.DataAnnotations.Schema;
using Entities.Notifications;

namespace Entities.Entities
{
    [NotMapped]
    public class Dashboard : Notifies
    {
        [NotMapped]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Total { get; set; }
        [NotMapped]
        public string PlanoConta { get; set; }
    }
}