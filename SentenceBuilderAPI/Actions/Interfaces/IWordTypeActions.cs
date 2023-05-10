using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.BaseResponse;

namespace SentenceBuilderAPI.Actions.Interfaces
{
    public interface IWordTypeActions
    {
        ActionResult<BaseResponse<List<WordType>>> GetAllWordTypes();
    }
}
