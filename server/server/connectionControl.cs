using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ConnectLib;

namespace server
{
    class connectionControl
    {
        public connectionControl(string adress)
        {
            Connection.action = process;
            ServiceHost host = new ServiceHost(typeof(Connection), new Uri(adress));
            host.Open();
            log("Сервер запущен");

            #region Output dispatchers listening
            foreach (Uri uri in host.BaseAddresses)
            { log(uri.ToString()); }
            log("");
            log("Count and list of listening : "+host.ChannelDispatchers.Count.ToString());
            foreach (System.ServiceModel.Dispatcher.ChannelDispatcher dispatcher in host.ChannelDispatchers)
            {
                log("\t"+dispatcher.Listener.Uri.ToString()+" "+dispatcher.BindingName);
            }
            #endregion
        }

        void log(string x)
        {
            Program.MainForm.log(x);
        }

        public object process(object o)
        {
            if(o is string)
            {
                return "string recived";
            }
            return "error";
        }
    }
}
