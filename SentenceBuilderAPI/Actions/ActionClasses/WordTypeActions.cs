using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Data;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.BaseResponse;

namespace SentenceBuilderAPI.Actions.ActionClasses
{
    public class WordTypeActions : IWordTypeActions
    {
        private readonly ApplicationDbContext _db;
        private readonly IExceptionsLogActions _exceptionsLogActions;

        public WordTypeActions(ApplicationDbContext db, IExceptionsLogActions exceptionsLogActions)
        {
            _db = db;
            _exceptionsLogActions = exceptionsLogActions;
        }

        public ActionResult<BaseResponse<List<WordType>>> GetAllWordTypes()
        {
            try
            {
                var response = new BaseResponse<List<WordType>>();
                var getAllWordTypes = _db.WordType;

                if (getAllWordTypes == null)
                {
                    response.Success = false;
                    response.Message = "could not get all word types.";
                    return response;
                }

                response.Success = true;
                response.Message = "Successfully retrieved all word types.";
                response.Data = getAllWordTypes.ToList();
                return response;
            }
            catch(Exception ex)
            {
                _ = Task.Run(async () => await _exceptionsLogActions.LogException(ex.Message, "GetAllWordTypes"));
                return new BaseResponse<List<WordType>> { Message = $"An error occured. Error: {ex.Message}", Success = false};
            }
        }
    }
}
