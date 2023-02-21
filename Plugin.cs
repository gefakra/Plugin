using NLog;
using NLog.LayoutRenderers.Wrappers;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Users.Plugin
{
    [Author(Name = "Medhurst Terry Smitham")]
    public class Plugin : IPluggable
    {
        private static HttpClient Client = new();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            Plugin.logger.Info("Loading employees");
            var item = new Clients().ProcessRepositoriesAsync(Client).Result;            
            Plugin.logger.Info(string.Format("Loaded {0} employees", (object)item.Count));
            return item.Cast<DataTransferObject>();           
        }
    }
}