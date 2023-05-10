using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.BaseResponse;
using SentenceBuilderAPI.Models.DTOModels.WordDTO;

namespace SentenceBuilderAPI.Actions.Interfaces
{
    public interface IWordActions
    {
        Task<BaseResponse<List<Words>>> GetWordsByType(int wordTypeId);
        Task<BaseResponse> AddWord(WordsDTOCreate word);
    }
}
