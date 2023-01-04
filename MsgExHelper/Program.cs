using Newtonsoft.Json;

using System;
using System.Linq;

// Uncomment to enable attach to debugger.
// using System.Diagnostics;

using System.Windows.Forms;

namespace DataTools.MessageBoxEx
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
#if DEBUG
                // Uncomment to enable attach to debugger.
                // Debugger.Launch();
#endif
                MessageBoxExConfig config;
                bool vs = true;
                string json;

                int buffLen = 8192;
                char[] chars = new char[buffLen];
                int ch;
                int c = 0;

                do
                {
                    ch = Console.Read();
                    if (ch == -1) break;

                    if (ch != 26)
                    {
                        chars[c] = (char)ch;
                        c++;

                        if (c >= buffLen)
                        {
                            buffLen *= 2;
                            Array.Resize(ref chars, buffLen);
                        }
                    }
                    else
                    {
                        ch = Console.Read();
                        vs = ((char)ch) == '1' ? true : false;

                        break;
                    }
                } while (ch != -1);

                // Array.Resize(ref chars, c);
                json = new string(chars);

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
                {
                    Application.EnableVisualStyles();
                }
                Application.SetCompatibleTextRenderingDefault(false);

                json = null;

                var res = MessageBoxEx.Show(config);

                json = JsonConvert.SerializeObject(config);

                Console.Write(json);
                Environment.ExitCode = (int)res;
                Application.Exit();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private static void JsonError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {
            var em = e;
        }
    }
}