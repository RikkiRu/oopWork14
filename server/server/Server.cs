using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace HTTPServer {
    class Server {

		TcpListener listner;

		public Server(int port) {
			listner = new TcpListener(IPAddress.Any, port);
			listner.Start();
			while (true)
				new ClientHandler(listner.AcceptTcpClient());
		}
		~Server() {
			if (listner != null)
				listner.Stop();
		}
    }
}
