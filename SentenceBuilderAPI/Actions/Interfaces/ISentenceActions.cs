using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.BaseResponse;
using SentenceBuilderAPI.Models.DTOModels.SentenceDTO;

namespace SentenceBuilderAPI.Actions.Interfaces
{
    public interface ISentenceActions
    {
        ActionResult<BaseResponse<List<Sentence>>> GetAllSenctences();
        Task<BaseResponse> CreateSentence(SentenceDTOCreate sentence);
    }
}
