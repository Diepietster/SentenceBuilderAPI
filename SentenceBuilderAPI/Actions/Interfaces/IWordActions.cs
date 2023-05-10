using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.BaseResponse;
using SentenceBuilderAPI.Models.DTOModels.WordDTO;

namespace SentenceBuilderAPI.Actions.Interfaces
{
    public interface IWordActions
    {
        ActionResult<BaseResponse<List<Words>>> GetWordsByType(int wordTypeId);
        Task<BaseResponse> AddWord(WordsDTOCreate word);
    }
}
