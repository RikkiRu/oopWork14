using System;
using System.ServiceModel;

namespace ConnectLib
{
    public delegate object delegateForServer(object o);

    [ServiceContract]
    public interface pingInter
    {
        [OperationContract]
        string say(string data);
        [OperationContract]
        object oSend(object o);
    }

    public class Connection:pingInter
    {
        public static delegateForServer action;

        public object oSend (object o)
        {
            if(action!=null)
            return action(o);
            return "error";
        }

        public string say(string data)
        {
            string res = "OK, сообщение получено сервером";
            Console.WriteLine("Получено сообщение " + data);
            return res;
        }
    }

    public class cLogin
    {
        public string name;
        public string password;
    }
}
