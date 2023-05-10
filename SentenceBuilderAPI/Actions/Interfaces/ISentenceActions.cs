using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Models;

namespace SentenceBuilderAPI.Actions.Interfaces
{
    public interface ISentenceActions
    {
        ActionResult<IEnumerable<Sentence>> GetAllSenctences();
    }
}
