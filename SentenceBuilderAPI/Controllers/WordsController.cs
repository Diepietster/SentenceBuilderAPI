﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Models;
using System;
using SentenceBuilderAPI.Models.BaseResponse;
using SentenceBuilderAPI.Models.DTOModels.WordDTO;
using System.Net;

namespace SentenceBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordActions _wordActions;
        private readonly IExceptionsLogActions _exceptionsLogActions;

        public WordsController(IWordActions wordActions, IExceptionsLogActions exceptionsLogActions)
        {
            _wordActions = wordActions;
            _exceptionsLogActions = exceptionsLogActions;
        }

        [HttpGet("GetAllWordsByType/{wordTypeId}")]
        [ProducesResponseTypeAttribute((int)HttpStatusCode.OK, Type = typeof(BaseResponse<List<Words>>))]
        public async Task<BaseResponse<List<Words>>> GetAllWordsByType(int wordTypeId)
        {
            try
            {
                return await _wordActions.GetWordsByType(wordTypeId);
            }
            catch (Exception ex)
            {
                _ = Task.Run(async() => await _exceptionsLogActions.LogException(ex.Message, "GetAllWordsByType"));
                return new BaseResponse<List<Words>> { Message = $"An error occured. Error: {ex.Message}", Success = false };
            }
        }

        [HttpPost("AddWord")]
        [ProducesResponseTypeAttribute((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<BaseResponse> AddWord([FromBody] WordsDTOCreate word)
        {
            try
            {
                return await _wordActions.AddWord(word); 
            }
            catch(Exception ex)
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "AddWord"));
                return new BaseResponse { Message = $"An error occured. Error: {ex.Message}", Success = false };
            }
        }
    }
}
