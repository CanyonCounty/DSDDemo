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
            try
            {
                Application.Run(new frmMain());
                // HackForm is/was just used for testing ideas
                //Application.Run(new HackForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return; // Application object won't work here
            }
        }
    }
}
