using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DSDDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            // HackForm is/was just used for testing ideas
            //Application.Run(new HackForm());
        }
    }
}
