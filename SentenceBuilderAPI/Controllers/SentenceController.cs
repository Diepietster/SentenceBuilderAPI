using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Actions.Interfaces;

namespace SentenceBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentenceController : ControllerBase
    {
        private readonly ISentenceActions _sentenceActions;

        public SentenceController(ISentenceActions sentenceActions)
        {
            _sentenceActions = sentenceActions;
        }

        [HttpGet("GetAllSentences")]
        public ActionResult<IEnumerable<Sentence>> GetAllSentences()
        {
            try
            {
                return _sentenceActions.GetAllSenctences();
            }
            catch (Exception)
            {
                //log error in db
                throw; 
            }
        }
    }
}
