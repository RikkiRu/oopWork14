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
        public connectionControl()
        {
            Connection.action = process;
            ServiceHost host = new ServiceHost(typeof(Connection), new Uri("http://localhost:8081/"));
            host.Open();
            Console.WriteLine("Сервер запущен");

            #region Output dispatchers listening
            foreach (Uri uri in host.BaseAddresses)
            { Console.WriteLine("\t{0}", uri.ToString()); }
            Console.WriteLine();
            Console.WriteLine("Count and list of listening : {0}", host.ChannelDispatchers.Count);
            foreach (System.ServiceModel.Dispatcher.ChannelDispatcher dispatcher in host.ChannelDispatchers)
            {
                Console.WriteLine("\t{0}, {1}", dispatcher.Listener.Uri.ToString(), dispatcher.BindingName);
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
