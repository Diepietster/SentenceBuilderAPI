using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.BaseResponse;

namespace SentenceBuilderAPI.Actions.Interfaces
{
    public interface IWordTypeActions
    {
        Task<BaseResponse<List<WordType>>> GetAllWordTypes();
    }
}
