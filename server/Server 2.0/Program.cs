using System;
using System.Windows.Forms;

namespace Server_2._0 {
	static class Program {
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		public static Server server = new Server();
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new StartForm());
		}
	}
}
