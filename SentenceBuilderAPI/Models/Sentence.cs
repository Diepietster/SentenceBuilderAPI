using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentenceBuilderAPI.Models
{
    public class Sentence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SentenceId { get; set; }

        [Required]
        public string SentenceDesc { get; set; }

        [Required]
        public DateTime SentenceCreatedOn { get; set; }
    }
}
