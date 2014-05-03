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
            bool add = false;

            switch(s[0])
            {
                case "login":
                    var a = db.tConsulters.Where(c => c.login == s[1]).FirstOrDefault();
                    if (a != null && a.password == s[2]) return a.isBoss;
                    return -1;

                case "addCons":
                    try
                    {
                        var con = db.tConsulters.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
                        add = false;
                        if (con == null)
                        {
                            con = new Consulters();
                            add = true;
                        }

                        con.Id = Convert.ToInt32(s[1]);
                        con.firstname = s[2];
                        con.lastname = s[3];
                        con.login = s[4];
                        con.password = s[5];
                        con.isBoss = Convert.ToInt32(s[6]); 
                        con.salary = Convert.ToInt32(s[7]);
                        if(add) db.tConsulters.InsertOnSubmit(con);
                        db.SubmitChanges();
                        return "Добавлено";
                    }
                    catch (Exception ex) { return ex.Message; }

                case "addFAQ":
                    try
                    {
                        var con = db.tFAQ.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
                        add = false;
                        if (con == null)
                        {
                            con = new FAQ();
                            add = true;
                        }
                        
                        con.Id = Convert.ToInt32(s[1]);
                        con.question = s[2];
                        con.answer = s[3];
                        con.theme_id = Convert.ToInt32(s[4]);
                        if (add) db.tFAQ.InsertOnSubmit(con);
                        db.SubmitChanges();
                        return "Добавлено";
                    }
                    catch (Exception ex) { return ex.Message; }
            }
            return "Не обработано";
        }

        public object intProcess(int x)
        {
            string res = "";
            switch (x)
            {
                case 0: //FAQ rquest
                    foreach (var a in db.tFAQ)
                    {
                        res += a.Id.ToString() + "\t" + a.question + "\t" + a.answer + "\t" + a.theme_id.ToString();
                        res+="\n";
                    }
                    return res;

                case 1: //personal reqest
                    foreach (var a in db.tConsulters)
                    {
                        res += a.Id.ToString() + "\t" + a.firstname + "\t" + a.lastname + "\t" + a.login + "\t" + a.password + "\t" + a.isBoss + "\t" + a.salary;
                        res += "\n";
                    }
                    return res; 
            }

            return null;
        }
    }
}
