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
                Log("Сервер запущен");

                #region Output dispatchers listening
                foreach (Uri uri in host.BaseAddresses)
                { Log(uri.ToString()); }
                Log("");
                Log("Count and list of listening : " + host.ChannelDispatchers.Count.ToString());
                foreach (System.ServiceModel.Dispatcher.ChannelDispatcher dispatcher in host.ChannelDispatchers)
                {
                    Log("\t" + dispatcher.Listener.Uri.ToString() + " " + dispatcher.BindingName);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        void Log(object x)
        {
            Program.MainForm.Log(x.ToString());
        }

        public object process(object o)
        {
            Log(o);

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
                case "Login":
                    var a = db.tConsulters.Where(c => c.Login == s[1]).FirstOrDefault();
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
                        con.Login = s[4];
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
                        var test = db.tThemes.Where(c => c.Id == con.theme_id).FirstOrDefault();
                        if (test == null) throw new Exception("Нет такой темы");
                        if (add) db.tFAQ.InsertOnSubmit(con);
                        db.SubmitChanges();
                        return "Добавлено";
                    }
                    catch (Exception ex) { return ex.Message; }

                case "addTheme":
                    try
                    {
                        var con = db.tThemes.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
                        add = false;
                        if (con == null)
                        {
                            con = new Themes();
                            add = true;
                        }
                        con.Id = Convert.ToInt32(s[1]);
                        con.Theme = s[2];
                        con.difficulity = Convert.ToInt32(s[3]);
                        if (con.difficulity < 0) throw new Exception("Сложность должна быть >0");
                        con.standart_time = s[4];
                        string[] testN = s[4].Split('.');
                        if (testN.GetLength(0) != 3) throw new Exception("Формат срока не верен");
                        con.tarif_id = Convert.ToInt32(s[5]);
                        var test = db.tThemes.Where(c => c.Id == con.tarif_id).FirstOrDefault();
                        if (test == null) throw new Exception("Нет такого тарифа");
                        if (add) db.tThemes.InsertOnSubmit(con);
                        db.SubmitChanges();
                        return "Добавлено";
                    }
                    catch (Exception ex) { return ex.Message; }

                case "addTarif":
                    try
                    {
                        var con = db.tTarif.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
                        add = false;
                        if (con == null)
                        {
                            con = new Tarif();
                            add = true;
                        }

                        con.Id = Convert.ToInt32(s[1]);
                        con.cost = Convert.ToInt32(s[2]);
                        con.multipiller = Convert.ToInt32(s[3]);

                        if (add) db.tTarif.InsertOnSubmit(con);
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
                    res = "";
                    foreach (var a in db.tFAQ)
                    {
                        res += a.Id.ToString() + "\t" + a.question + "\t" + a.answer + "\t" + a.theme_id.ToString();
                        res+="\n";
                    }
                    return res;

                case 1: //personal reqest
                    res = "";
                    foreach (var a in db.tConsulters)
                    {
                        res += a.Id.ToString() + "\t" + a.firstname + "\t" + a.lastname + "\t" + a.Login + "\t" + a.password + "\t" + a.isBoss + "\t" + a.salary;
                        res += "\n";
                    }
                    return res; 

                case 2: //themes request
                    res = "";
                    foreach (var a in db.tThemes)
                    {
                        res += a.Id.ToString() + "\t" + a.Theme + "\t" + a.difficulity.ToString() + "\t" + a.standart_time.ToString() + "\t" + a.tarif_id.ToString();
                        res += "\n";
                    }
                    return res;

                case 3: //tarif request
                    res = "";
                    foreach(var a in db.tTarif)
                    {
                        res += a.Id.ToString() + "\t" + a.cost.ToString() + "\t" + a.multipiller.ToString();
                        res += "\n";
                    }
                    return res;
            }

            return null;
        }
    }
}
