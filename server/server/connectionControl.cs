using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ConnectLib;
using dbLib;
using HelpersLib;

namespace server
{
    class connectionControl
    {
        dbBind db;
        static ServiceHost host;
        Control control;

        public connectionControl(string adress, dbBind db, Control ctrl)
        {
            try
            {
                this.control = ctrl;
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
                    log("|" + dispatcher.Listener.Uri.ToString() + " " + dispatcher.BindingName);
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
            string[] s = x.Split('~');
            bool add = false;
            switch(s[0])
            {
                case "login":
                    var a = db.tConsulters.Where(c => c.Login == s[1]).FirstOrDefault();
                    if (a != null && a.Password == s[2]) return a.ID+"~"+a.IsBoss;
                    return -1;

                case "addCons":
                    try
                    {
                        var con = db.tConsulters.Where(c => c.ID == Convert.ToInt32(s[1])).FirstOrDefault();
                        add = false;
                        if (con == null)
                        {
                            con = new Consulters();
                            add = true;
                        }

                        con.ID = Convert.ToInt32(s[1]);
						con.Firstname = s[2];
                        con.Lastname = s[3];
                        con.Login = s[4];
                        con.Password = s[5];
                        con.IsBoss = Convert.ToInt32(s[6]); 
                        con.Salary = Convert.ToInt32(s[7]);
                        if(add) db.tConsulters.InsertOnSubmit(con);
                        db.SubmitChanges();
                        return "Добавлено";
                    }
                    catch (Exception ex) { return ex.Message; }

                case "addFAQ":
                    try
                    {
                        var con = db.tFAQ.Where(c => c.ID == Convert.ToInt32(s[1])).FirstOrDefault();
                        add = false;
                        if (con == null)
                        {
                            con = new FAQ();
                            add = true;
                        }
                        
                        con.ID = Convert.ToInt32(s[1]);
                        con.Question = s[2];
                        con.Answer = s[3];
                        con.ThemeID = Convert.ToInt32(s[4]);
                        var test = db.tThemes.Where(c => c.ID == con.ThemeID).FirstOrDefault();
                        if (test == null) throw new Exception("Нет такой темы");
                        if (add) db.tFAQ.InsertOnSubmit(con);
                        db.SubmitChanges();
                        return "Добавлено";
                    }
                    catch (Exception ex) { return ex.Message; }

                case "addTheme":
                    try
                    {
                        var con = db.tThemes.Where(c => c.ID == Convert.ToInt32(s[1])).FirstOrDefault();
                        add = false;
                        if (con == null)
                        {
                            con = new Themes();
                            add = true;
                        }
                        con.ID = Convert.ToInt32(s[1]);
                        con.Theme = s[2];
                        con.Difficulty = Convert.ToInt32(s[3]);
                        if (con.Difficulty < 0) throw new Exception("Сложность должна быть >0");
                        con.StandartTime = s[4];
                        string[] testN = s[4].Split('.');
                        if (testN.GetLength(0) != 3) throw new Exception("Формат срока не верен");
                        con.TarifID = Convert.ToInt32(s[5]);
                        var test = db.tThemes.Where(c => c.ID == con.TarifID).FirstOrDefault();
                        if (test == null) throw new Exception("Нет такого тарифа");
                        if (add) db.tThemes.InsertOnSubmit(con);
                        db.SubmitChanges();
                        return "Добавлено";
                    }
                    catch (Exception ex) { return ex.Message; }

                case "addTarif":
                    try
                    {
                        var con = db.tTarif.Where(c => c.ID == Convert.ToInt32(s[1])).FirstOrDefault();
                        add = false;
                        if (con == null)
                        {
                            con = new Tarif();
                            add = true;
                        }

                        con.ID = Convert.ToInt32(s[1]);
                        con.Cost = Convert.ToInt32(s[2]);
                        con.Multipiller = Convert.ToInt32(s[3]);

                        if (add) db.tTarif.InsertOnSubmit(con);
                        db.SubmitChanges();
                        return "Добавлено";
                    }
                    catch (Exception ex) { return ex.Message; }

                case "reqQ":
                    try
                    {
                        QA ar = control.getQA(Convert.ToInt32(s[1]));
                        if (ar == null) return null;
                        var t = db.tThemes.Where(c => c.ID == ar.ThemeID).FirstOrDefault();
                        if (t == null) throw new Exception("Не нашлась тема при запросе вопроса");
                        int diff = control.getDiff(ar);
                        return ar.ID + "|" + t.Theme + "|" + diff.ToString() + "|" + ar.Question + "|" + ar.StartTime.ToString() + "|" + ar.EndTime.ToString() + "|";
                    }
                    catch (Exception ex) { log(ex.Message); return null; }

                case "setQ":
                    try
                    {
                        control.setQAanswer(Convert.ToInt32(s[1]), s[2], s[3]);
                        return "Отправлено";
                    }
                    catch (Exception ex) { return ex.Message; }

                case "someQA":
                    //try
                    {
                        QA f = db.tFQA.Where(c => c.ID == Convert.ToInt32(s[1])).FirstOrDefault();
                        return control.getSomeQA(f, Convert.ToBoolean(s[2]));
                    }
                    //catch (Exception ex) { return ex.Message; }


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
                        res += a.ID.ToString() + "|" + a.Question + "|" + a.Answer + "|" + a.ThemeID.ToString();
                        res+="~";
                    }
                    return res;

                case 1: //personal reqest
                    res = "";
                    foreach (var a in db.tConsulters)
                    {
						res += a.ID.ToString() + "|" + a.Firstname + "|" + a.Lastname + "|" + a.Login + "|" + a.Password + "|" + a.IsBoss + "|" + a.Salary;
                        res += "~";
                    }
                    return res; 

                case 2: //themes request
                    res = "";
                    foreach (var a in db.tThemes)
                    {
                        res += a.ID.ToString() + "|" + a.Theme + "|" + a.Difficulty.ToString() + "|" + a.StandartTime.ToString() + "|" + a.TarifID.ToString();
                        res += "~";
                    }
                    return res;

                case 3: //tarif request
                    res = "";
                    foreach(var a in db.tTarif)
                    {
                        res += a.ID.ToString() + "|" + a.Cost.ToString() + "|" + a.Multipiller.ToString();
                        res += "~";
                    }
                    return res;
            }

            return null;
        }
    }
}
