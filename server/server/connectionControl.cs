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
        static ServiceHost host;

        public connectionControl(string adress)
        {
            try
            {
                Connection.action = process;
                host = new ServiceHost(typeof(Connection), new Uri(adress));
                host.Open();
                log("Сервер запущен");

                #region Output dispatchers listening
                foreach (Uri uri in host.BaseAddresses)
                { log(uri.ToString()); }
                log("");
                log("Count and list of listening : " + host.ChannelDispatchers.Count.ToString());
                foreach (System.ServiceModel.Dispatcher.ChannelDispatcher dispatcher in host.ChannelDispatchers)
                {
                    log("\t" + dispatcher.Listener.Uri.ToString() + " " + dispatcher.BindingName);
                }
                #endregion
            }
            catch (Exception ex)
            {
                log(ex.Message);
            }
        }

        void log(object x)
        {
            Program.MainForm.log(x.ToString());
        }

        public object process(object o)
        {
            if(o is string)
            {
                
            }

            log(o);
            return 0;
        }
    }
}
