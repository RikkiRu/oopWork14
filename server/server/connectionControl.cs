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
                    var a = db.tConsulters.Where(c => c.login == s[1]).FirstOrDefault();
                    if (a != null && a.password == s[2]) return a.Id+"~"+a.isBoss;
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

                case "reqQ":
                    try
                    {
                        QA ar = control.getQA(Convert.ToInt32(s[1]));
                        if (ar == null) return null;
                        var t = db.tThemes.Where(c => c.Id == ar.theme_id).FirstOrDefault();
                        if (t == null) throw new Exception("Не нашлась тема при запросе вопроса");
                        int diff = control.getDiff(ar);
                        return ar.Id + "|" + t.Theme + "|" + diff.ToString() + "|" + ar.question + "|" + ar.start_time.ToString() + "|" + ar.end_time.ToString() + "|";
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
                        QA f = db.tFQA.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
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
                        res += a.Id.ToString() + "|" + a.question + "|" + a.answer + "|" + a.theme_id.ToString();
                        res+="~";
                    }
                    return res;

                case 1: //personal reqest
                    res = "";
                    foreach (var a in db.tConsulters)
                    {
                        res += a.Id.ToString() + "|" + a.firstname + "|" + a.lastname + "|" + a.login + "|" + a.password + "|" + a.isBoss + "|" + a.salary;
                        res += "~";
                    }
                    return res; 

                case 2: //themes request
                    res = "";
                    foreach (var a in db.tThemes)
                    {
                        res += a.Id.ToString() + "|" + a.Theme + "|" + a.difficulity.ToString() + "|" + a.standart_time.ToString() + "|" + a.tarif_id.ToString();
                        res += "~";
                    }
                    return res;

                case 3: //tarif request
                    res = "";
                    foreach(var a in db.tTarif)
                    {
                        res += a.Id.ToString() + "|" + a.cost.ToString() + "|" + a.multipiller.ToString();
                        res += "~";
                    }
                    return res;
            }

            return null;
        }
    }
}
