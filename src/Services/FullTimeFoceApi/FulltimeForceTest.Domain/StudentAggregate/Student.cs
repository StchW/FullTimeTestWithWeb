using FulltimeForceTest.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FulltimeForceTest.Domain.StudentAggregate
{
    [Table("Student")]
    public class Student : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(TypeName = "bigint")]
        public long Id { get; set; }

        [Required]
        public double Note { get; set; }
    }
}
