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
       

        static public Form_main MainForm;
         [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //classConsole.AllocConsole();
            MainForm = new Form_main();
            
            Application.Run(MainForm);
        }
    }
}
