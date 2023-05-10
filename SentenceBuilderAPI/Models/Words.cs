using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentenceBuilderAPI.Models
{
    public class Words
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WordId { get; set; }

        [Required]
        [ForeignKey("WordType")]
        public int WordTypeId { get; set; }

        public WordType WordType { get; set; }

        [Required]
        public string Word { get; set; }
    }
}
