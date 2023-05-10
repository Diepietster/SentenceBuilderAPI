using Microsoft.AspNetCore.Mvc;
using SentenceBuilderAPI.Actions.Interfaces;
using SentenceBuilderAPI.Data;
using SentenceBuilderAPI.Models;

namespace SentenceBuilderAPI.Actions.ActionClasses
{
    public class LogExceptionActions : IExceptionsLogActions
    {
        private readonly ApplicationDbContext _db;

        public LogExceptionActions(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task LogException(string exceptionMessage, string methodName)
        {
            try
            {
                ExceptionsLog exceptionsLog = new ExceptionsLog() 
                {
                    ExceptionMessage = exceptionMessage,
                    MethodName = methodName,
                    ExceptionTime = DateTime.Now
                };

                await _db.ExceptionLogs.AddAsync(exceptionsLog);
                await _db.SaveChangesAsync();
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
