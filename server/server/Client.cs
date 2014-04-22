using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace HTTPServer {
	class ClientHandler {
		public ClientHandler(TcpClient client) {
			NetworkStream stream = client.GetStream();
			byte[] buffer = new byte[1024];
			stream.Read(buffer, 0, buffer.Length);
			char[] data = Encoding.ASCII.GetChars(buffer);
			string result = string.Empty;
			foreach (char ch in data)
				result += ch;
			buffer = Encoding.ASCII.GetBytes("Re: "+result);
			stream.Write(buffer, 0, buffer.Length);
			MessageBox.Show("Server received message: "+result);
			client.Close();
		}
	}
}
