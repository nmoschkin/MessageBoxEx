using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTools.MessageBoxEx;

namespace TestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);

            bool vs = false;

            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (arg.ToLower() == "/vs")
                    {
                        vs = true;
                        
                    }
                }
            }

            if (!vs)
            {
                var res = MessageBoxEx.Show("Enable Visual Styles?", "Visual Styles", MessageBoxExType.YesNo, MessageBoxExIcons.Question);
                
                if (res == MessageBoxExResult.Yes)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath, "/vs");
                    Application.Exit();

                    return;
                }
            }

            if (vs) Application.EnableVisualStyles();

            Application.Run(new Form1());
        }
    }
}
