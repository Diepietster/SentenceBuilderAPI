using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.DTOModels.WordDTO;
using SentenceBuilderAPI.Models;

namespace SentenceBuilderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordActions _wordActions;

        public WordsController(IWordActions wordActions)
        {
            _wordActions = wordActions;
        }

        [HttpGet("GetAllWordsByType/{wordTypeId}")]
        public ActionResult<IEnumerable<Words>> GetAllWordsByType(int wordTypeId)
        {
            try
            {
                return _wordActions.GetWordsByType(wordTypeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("AddWord")]
        public async Task<string> AddWord([FromBody] WordsDTOCreate word)
        {
            try
            {
                return await _wordActions.AddWord(word); 
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
