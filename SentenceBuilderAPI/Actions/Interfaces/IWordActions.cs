using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.DTOModels.WordDTO;
using SentenceBuilderAPI.Models;

namespace SentenceBuilderAPI.Actions.Interfaces
{
    public interface IWordActions
    {
        ActionResult<IEnumerable<Words>> GetWordsByType(int wordTypeId);
        Task<string> AddWord(WordsDTOCreate word);
    }
}
