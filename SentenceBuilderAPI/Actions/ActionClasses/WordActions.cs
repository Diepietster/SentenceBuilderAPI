using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Data;
using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.DTOModels.WordDTO;

namespace SentenceBuilderAPI.Actions.ActionClasses
{
    public class WordActions: IWordActions
    {
        private readonly AppliationDbContext _db;

        public WordActions(AppliationDbContext db)
        {
            _db = db;
        }

        public ActionResult<IEnumerable<Words>> GetWordsByType(int wordTypeId)
        {
            try
            {
                var wordsByType = (from W in _db.Words
                                  join WT in _db.WordType on W.WordTypeId equals WT.WordTypeId
                                  where W.WordTypeId == wordTypeId
                                  select W).ToList();

                if(wordsByType == null)
                {
                    return null;
                }

                return wordsByType;
            }
            catch(Exception)
            {
                //Log error in db
                throw;
            }
        }

        public async Task<string> AddWord(WordsDTOCreate word)
        {
            try
            {
                Words newWord = new()
                {
                    Word = word.Word,
                    WordTypeId = word.WordTypeId
                };

                var addWord = await _db.Words.AddAsync(newWord);
                var saveChange = await _db.SaveChangesAsync();

                if(saveChange <= 0)
                {
                    return "Adding word failed";
                }

                return "Added word successfully";
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
