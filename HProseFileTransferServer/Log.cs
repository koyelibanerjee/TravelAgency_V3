using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace HProseFileTransferServer
{
    public class Log
    {
        public static ILog Logger;
        static Log()
        {
            log4net.Config.XmlConfigurator.Configure();
            Logger = log4net.LogManager.GetLogger("HProseFileTransferServerLogger");
        }
    }
}
