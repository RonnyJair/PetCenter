using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;


namespace PetCenter.Common.Utilities
{
    public class EventLogger
    {
        
        public static void EscribirLog(string texto) {

            log4net.Config.XmlConfigurator.Configure();
            ILog logger = LogManager.GetLogger(typeof(EventLogger));
            BasicConfigurator.Configure();
            logger.Debug(texto.ToUpper());
        }

    }
}

