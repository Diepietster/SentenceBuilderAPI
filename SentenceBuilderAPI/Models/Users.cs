using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentenceBuilderAPI.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserKey { get; set; }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        [Required]
        public int UserRole { get; set; }
        [Required]
        public string UserEmail { get; set; }
    }
}
