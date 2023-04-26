using DataAccess.DBContext;
using DataAccess.Entities;
using DataAccess.Helpers;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace CoreServicesApp.Utils
{
    public class LogUtils
    {
        public static string GetActualAsyncMethodName([CallerMemberName] string name = "") => name;

        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly IConfiguration _configuration;

        public LogUtils(IBackgroundTaskQueue taskQueue, IConfiguration config)
        {
            _taskQueue = taskQueue;
            _configuration = config;
        }

        //#region llamada a servicio para registro de logs
        public async void LogRegister(DataLog log)
        {
            await _taskQueue.QueueBackgroundWorkItemAsync(
              token => SaveLogAsync(log)
              );
        }

        /// <summary>
        /// Servicio para Guardar Log
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="token"></param>
        public async ValueTask SaveLogAsync(DataLog Data)
        {
            try
            {
                DsSysLogSystem log = new DsSysLogSystem
                {
                    User = Data.user,
                    Action = Data.action,
                    Service = Data.service,
                    Description = Data.description,
                    InnerException = Data.innerExeption,
                    Priority = Data.priority,
                    DateRegister = DateTime.Now
                };

                using (ChicoteIoContext chicoteTestContext = new ChicoteIoContext(_configuration.GetConnectionString("ConectionChicote")))
                {
                    chicoteTestContext.DsSysLogSystems.Add(log);
                    await chicoteTestContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //#endregion

    }
}
