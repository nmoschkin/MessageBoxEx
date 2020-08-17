using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace DataTools.MessageBoxEx
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

#if DEBUG
            // Debugger.Launch();
#endif
            MessageBoxExConfig config;
            bool vs = true;

            try
            {

                List<char> chars = new List<char>();
                int ch;

                do
                {
                    ch = Console.Read();
                    if (ch != 26)
                    {
                        chars.Add((char)ch);
                    }
                    else
                    {
                        ch = Console.Read();
                        vs = ((char)ch) == '1' ? true : false;
                        break;
                    }

                } while (ch != -1);

                string json = new string(chars.ToArray());

                try
                {
                    var settings = new JsonSerializerSettings();
                    
                    settings.Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>(JsonError);
                    settings.NullValueHandling = NullValueHandling.Ignore;

                    config = JsonConvert.DeserializeObject<MessageBoxExConfig>(json, settings);
                }
                catch
                {
                    Environment.ExitCode = 0x1000;
                    Application.Exit();
                    return;
                }

                if (vs)
                    Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                json = null;

                var res = MessageBoxEx.Show(config);

                json = JsonConvert.SerializeObject(config);

                Console.Write(json);
                Environment.ExitCode = (int)res;
            }
            catch(Exception ex)
            {

                Console.Write(ex.Message);

            }

            Application.Exit();

            return;
        }

        static void JsonError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {

            var em = e;

        }   

    }
}
