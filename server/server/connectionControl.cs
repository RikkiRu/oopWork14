using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ConnectLib;
using dbLib;

namespace server
{
    class connectionControl
    {
        dbBind db;
        static ServiceHost host;

        public connectionControl(string adress, dbBind db)
        {
            try
            {
                this.db = db;
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
            log(o);

            if(o is string)
            {
                return stringProcess(o.ToString());
            }

            if(o is int)
            {
                return intProcess(Convert.ToInt32(o));
            }

            
            return 0;
        }

        public object stringProcess(string x)
        {
            string[] s = x.Split('\n');
            switch(s[0])
            {
                case "login":
                    var a = db.tConsulters.Where(c => c.login == s[1]).FirstOrDefault();
                    if (a != null && a.password == s[2]) return a.isBoss;
                    return -1;
            }
            return null;
        }

        public object intProcess(int x)
        {
            switch (x)
            {
                case 0:
                    string res="";
                    foreach (var a in db.tFAQ)
                    {
                        res += a.Id.ToString() + "\t" + a.question + "\t" + a.answer + "\t" + a.theme_id.ToString();
                        res+="\n";
                    }
                    return res; //FAQ rquest
            }

            return null;
        }
    }
}
