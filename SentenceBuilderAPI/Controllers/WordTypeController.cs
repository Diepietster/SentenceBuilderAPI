using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.BaseResponse;
using System.Net;

namespace SentenceBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordTypeController : ControllerBase
    {
        private readonly IWordTypeActions _wordTypeActions;
        private readonly IExceptionsLogActions _exceptionsLogActions;

        public WordTypeController(IWordTypeActions wordTypeActions, IExceptionsLogActions exceptionsLogActions)
        {
            _exceptionsLogActions = exceptionsLogActions;
            _wordTypeActions = wordTypeActions;
        }

        [HttpGet("GetAllWordTypes")]
        [ProducesResponseTypeAttribute((int)HttpStatusCode.OK, Type = typeof(BaseResponse<List<WordType>>))]
        public async Task<BaseResponse<List<WordType>>> GetAllWordTypes()
        {
            try
            {
                return await _wordTypeActions.GetAllWordTypes();
            }
            catch(Exception ex) 
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "GetAllWordTypes"));
                return new BaseResponse<List<WordType>> { Success = false, Message = $"An error occured. Error: {ex.Message}" };
            }
        }
    }
}
