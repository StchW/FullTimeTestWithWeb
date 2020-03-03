using FulltimeForceTest.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FulltimeForceTest.Domain.EmployeeAggregate
{
    [Table("Employee")]
    public class Employee : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(TypeName = "bigint")]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Antiquity { get; set; }
        [Required]
        public double PriceHour { get; set; }
        [Required]
        public double TotalGrossCharge { get; set; }
        [Required]
        public double TotalDiscounts { get; set; }
        [Required]
        public double NetoPayment { get; set; }
    }
}
