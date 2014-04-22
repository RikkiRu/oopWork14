using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConnectLib
{
    [ServiceContract]
    public interface pingInter
    {
        [OperationContract]
        string say(string data);
    }

    public class Connection:pingInter
    {
        public string say(string data)
        {
            string res = "OK, сообщение получено сервером";
            Console.WriteLine("Получено сообщение " + data);
            return res;
        }
    }
}
