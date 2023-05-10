using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Data;
using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Models.BaseResponse;
using SentenceBuilderAPI.Models.DTOModels.WordDTO;

namespace SentenceBuilderAPI.Actions.ActionClasses
{
    public class WordActions: IWordActions
    {
        private readonly ApplicationDbContext _db;
        private readonly IExceptionsLogActions _exceptionsLogActions;

        public WordActions(ApplicationDbContext db, IExceptionsLogActions exceptionsLogActions)
        {
            _db = db;
            _exceptionsLogActions = exceptionsLogActions;
        }

        public ActionResult<BaseResponse<List<Words>>> GetWordsByType(int wordTypeId)
        {
            try
            {
                var response = new BaseResponse<List<Words>>();
                var wordsByType = (from W in _db.Words
                                  join WT in _db.WordType on W.WordTypeId equals WT.WordTypeId
                                  where W.WordTypeId == wordTypeId
                                  select W).ToList();

                if(wordsByType == null)
                {
                    response.Success = false;
                    response.Message = "Could not retrieve words.";
                    return response;
                }

                response.Success = true;
                response.Message = "Successfully retrieved all words";
                response.Data = wordsByType;
                return response;
            }
            catch(Exception ex)
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "GetWordsByType"));
                return new BaseResponse<List<Words>> { Message = $"An error occured. Error: {ex.Message}", Success = false};
            }
        }

        public async Task<BaseResponse> AddWord(WordsDTOCreate word)
        {
            try
            {
                var response = new BaseResponse();
                Words newWord = new()
                {
                    Word = word.Word,
                    WordTypeId = word.WordTypeId
                };

                var addWord = await _db.Words.AddAsync(newWord);
                var saveChange = await _db.SaveChangesAsync();

                if(saveChange <= 0)
                {
                    response.Success = false;
                    response.Message = "Could not add word";
                    return response;
                }

                response.Success = true;
                response.Message = "Successfully added word";
                return response;
            }
            catch(Exception ex)
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "AddWord"));
                return new BaseResponse { Message = $"An error occured. Error: {ex.Message}", Success = false}; 
            }
        }
    }
}
