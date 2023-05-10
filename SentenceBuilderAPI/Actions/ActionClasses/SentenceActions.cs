using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Data;
using SentenceBuilderAPI.Models;

namespace SentenceBuilderAPI.Actions.ActionClasses
{
    public class SentenceActions: ISentenceActions
    {
        private readonly AppliationDbContext _db;

        public SentenceActions(AppliationDbContext db)
        {
            _db = db;
        }

        public ActionResult<IEnumerable<Sentence>> GetAllSenctences()
        {
            try
            {
                var sentences = _db.Sentences;

                if(sentences == null)
                {
                    return null;
                }

                return sentences;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
