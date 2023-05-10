﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.BaseResponse;

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
        public ActionResult<BaseResponse<List<WordType>>> GetAllWordTypes()
        {
            try
            {
                return _wordTypeActions.GetAllWordTypes();
            }
            catch(Exception ex) 
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "GetAllWordTypes"));
                return new BaseResponse<List<WordType>> { Success = false, Message = $"An error occured. Error: {ex.Message}" };
            }
        }
    }
}