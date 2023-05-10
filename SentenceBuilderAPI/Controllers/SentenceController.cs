using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Models.BaseResponse;
using SentenceBuilderAPI.Models.DTOModels.SentenceDTO;

namespace SentenceBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentenceController : ControllerBase
    {
        private readonly ISentenceActions _sentenceActions;
        private readonly IExceptionsLogActions _exceptionsLogActions;

        public SentenceController(ISentenceActions sentenceActions, IExceptionsLogActions exceptionsLogActions)
        {
            _sentenceActions = sentenceActions;
            _exceptionsLogActions = exceptionsLogActions;
        }

        [HttpGet("GetAllSentences")]
        public async Task<BaseResponse<List<Sentence>>> GetAllSentences()
        {
            try
            {
                return await _sentenceActions.GetAllSenctences();
            }
            catch (Exception ex)
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "GetAllSentences"));
                return new BaseResponse<List<Sentence>> { Message = $"An error occured. Error: {ex.Message}", Success = false}; 
            }
        }

        [HttpPost("CreateSentence")]
        public async Task<BaseResponse> CreateSentence([FromBody] SentenceDTOCreate sentenceDTO)
        {
            try
            {
                return await _sentenceActions.CreateSentence(sentenceDTO);
            }
            catch (Exception ex)
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "CreateSentence"));
                return new BaseResponse { Success = false, Message = $"An error occured. Error: {ex.Message}" };
            }
        }
    }
}
