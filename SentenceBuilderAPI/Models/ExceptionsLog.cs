using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentenceBuilderAPI.Models
{
    public class ExceptionsLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExceptionId { get; set; }
        [Required]
        public string ExceptionMessage { get; set; }
        [Required]
        public string MethodName { get; set; }

        public DateTime ExceptionTime { get; set; }

    }
}
