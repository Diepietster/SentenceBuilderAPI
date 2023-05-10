﻿using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Data;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.BaseResponse;
using SentenceBuilderAPI.Models.DTOModels.SentenceDTO;

namespace SentenceBuilderAPI.Actions.ActionClasses
{
    public class SentenceActions: ISentenceActions
    {
        private readonly ApplicationDbContext _db;
        private readonly IExceptionsLogActions _exceptionsLogActions;

        public SentenceActions(ApplicationDbContext db, IExceptionsLogActions exceptionsLogActions)
        {
            _db = db;
            _exceptionsLogActions = exceptionsLogActions;
        }

        public ActionResult<BaseResponse<List<Sentence>>> GetAllSenctences()
        {
            try
            {
                var response = new BaseResponse<List<Sentence>>();
                var sentences = _db.Sentences;

                if(sentences == null)
                {
                    response.Success = false;
                    response.Message = "Could not retrieve all messages";
                    return response;
                }

                response.Success = true;
                response.Message = "Successully retrieved all messages.";
                response.Data = sentences.ToList();
                return response;
            }
            catch(Exception ex)
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "GetAllSenctences"));
                return new BaseResponse<List<Sentence>> { Message = $"An error occured. Error: {ex.Message}", Success = false};
            }
        }

        public async Task<BaseResponse> CreateSentence(SentenceDTOCreate sentence)
        {
            try
            {
                var response = new BaseResponse();

                Sentence newSentence = new Sentence() { 
                    SentenceDesc = sentence.SentenceDesc,
                    SentenceCreatedOn = DateTime.Now
                };

                var addSentence = await _db.AddAsync(newSentence);
                var savedChanges = await _db.SaveChangesAsync();

                if(savedChanges <= 0)
                {
                    response.Success = false;
                    response.Message = "Could not create sentence.";
                    return response;
                }

                response.Success = true;
                response.Message = "Successfully created sentence.";
                return response;
            }
            catch(Exception ex)
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "CreateSentence"));
                return new BaseResponse { Message = $"An error occured. Error: {ex.Message}", Success = false};
            }
        }
    }
}
