using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace HProseFileTransferServer
{
    public class LogService
    {
        public static ILog Logger;
        static LogService()
        {
            log4net.Config.XmlConfigurator.Configure();
            Logger = log4net.LogManager.GetLogger("HProseFileTransferServerLogger");
        }
    }
}
