using System.ComponentModel.DataAnnotations;

namespace SentenceBuilderAPI.Models.DTOModels.SentenceDTO
{
    public class SentenceDTOCreate
    {
        [Required]
        public string SentenceDesc { get; set; }
    }
}
