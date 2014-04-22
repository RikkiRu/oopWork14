using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace client {
	class Client {
		TcpClient client;
		public Client(int port) {
			try {
				client = new TcpClient("127.0.0.1", 80);
				string input = "God Lord, It's working!";
				byte[] buffer = Encoding.ASCII.GetBytes(input);
				NetworkStream stream = client.GetStream();
				stream.Write(buffer, 0, buffer.Length);
				buffer = new byte[1024];
				stream.Read(buffer, 0, buffer.Length);
				char[] data = Encoding.ASCII.GetChars(buffer);
				string result = string.Empty;
				foreach (char ch in data)
					result += ch;
				MessageBox.Show("Client received message: " + result);
				stream.Close();
				client.Close();
			} catch (SocketException e) {
				MessageBox.Show(e.Message);
			}

		}
	}
}
