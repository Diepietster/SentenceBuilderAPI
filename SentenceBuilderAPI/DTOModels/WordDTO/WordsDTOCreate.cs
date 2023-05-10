using System.ComponentModel.DataAnnotations;

namespace SentenceBuilderAPI.DTOModels.WordDTO
{
    public class WordsDTOCreate
    {
        [Required]
        public int WordTypeId { get; set; }

        [Required]
        public string Word { get; set; }
    }
}
