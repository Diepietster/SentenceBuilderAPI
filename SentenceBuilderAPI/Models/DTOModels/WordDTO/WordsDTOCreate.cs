using System.ComponentModel.DataAnnotations;

namespace SentenceBuilderAPI.Models.DTOModels.WordDTO
{
    public class WordsDTOCreate
    {
        [Required]
        public int WordTypeId { get; set; }

        [Required]
        public string Word { get; set; }
    }
}
