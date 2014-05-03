using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace client
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
       
        public static FormMain fm;

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAutorisation());
        }
    }
}
