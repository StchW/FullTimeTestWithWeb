
using FulltimeForceTest.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FulltimeForceTest.Domain.WordPalindromaAggregate
{
    [Table("WordPalindroma")]
    public class WordPalindroma : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(TypeName = "bigint")]
        public long Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public bool IsPalindroma { get; set; }
    }
}
