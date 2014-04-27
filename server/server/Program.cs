using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace server
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
       

        static public Form1 MainForm;
         [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //classConsole.AllocConsole();
            MainForm = new Form1();
            
            Application.Run(MainForm);
        }
    }
}
