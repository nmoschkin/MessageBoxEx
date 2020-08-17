using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Media;
using System.Reflection;
using DataTools.MessageBoxEx.Resources;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.IO;

namespace DataTools.MessageBoxEx
{

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal unsafe struct DxStruct
    {

        public MessageBoxExResult result;
        public int CustomResult;
        public bool OptionResult;
        public int jDataLen;
        public char* jData;
        public bool vs;
    }

    /// <summary>
    /// Enhanced Windows Desktop MessageBox replacement
    /// </summary>
    public static class MessageBoxEx
    {
        private static frmMsgBox form = new frmMsgBox();

        static MessageBoxEx()
        {
            ResourceTextConfig = new ResourceTextConfig("DataTools.MessageBoxEx.Resources.AppResources", Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Gets the current localized text resources configuration.
        /// </summary>
        public static ResourceTextConfig ResourceTextConfig { get; set; }

        private static List<MessageBoxExButton> MakeButtons(MessageBoxExType b)
        {
            if (ResourceTextConfig == null)
            {
                ResourceTextConfig = new ResourceTextConfig("DataTools.MessageBoxEx.Resources.AppResources", Assembly.GetCallingAssembly());
            }

            var rtc = ResourceTextConfig;
            var btnOut = new List<MessageBoxExButton>();
            
            switch(b)
            {
                case MessageBoxExType.AbortRetryIgnore:

                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Abort), MessageBoxExResult.Abort));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Retry), MessageBoxExResult.Retry, true));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Ignore), MessageBoxExResult.Ignore));

                    break;

                case MessageBoxExType.OK:

                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.OK), MessageBoxExResult.OK, true));
                    break;

                case MessageBoxExType.OKCancel:

                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.OK), MessageBoxExResult.OK, true));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Cancel), MessageBoxExResult.Cancel, false));
                    
                    break;

                case MessageBoxExType.YesNo:

                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Yes), MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.No), MessageBoxExResult.No, false));

                    break;

                case MessageBoxExType.YesNoCancel:

                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Yes), MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.No), MessageBoxExResult.No, false));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Cancel), MessageBoxExResult.Cancel, false));

                    break;
                case MessageBoxExType.YesNoAll:

                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Yes), MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.YesToAll), MessageBoxExResult.YesToAll, false));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.No), MessageBoxExResult.No, false));

                    break;

                case MessageBoxExType.YesNoAllCancel:

                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Yes), MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.YesToAll), MessageBoxExResult.YesToAll, false));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.No), MessageBoxExResult.No, false));
                    btnOut.Add(new MessageBoxExButton(rtc.GetText(MessageBoxExResult.Cancel), MessageBoxExResult.Cancel, false));

                    break;
            }

            return btnOut;
        }

        /// <summary>
        /// Start the message box out-of-process to change visual styles.
        /// </summary>
        /// <param name="config">The <see cref="MessageBoxExConfig" /> object to use to configure the dialog box.</param>
        /// <param name="visualStyles">Whether to enable Visual Styles by calling <see cref="System.Windows.Forms.Application.EnableVisualStyles()" />.</param>
        /// <returns>A <see cref="MessageBoxExResult" /> value</returns>
        public static MessageBoxExResult ShowInNewProcess(MessageBoxExConfig config, bool visualStyles = true)
        {
            int i;
            MessageBoxExResult result;
            bool wasStd;

            List<object> stashed = new List<object>();

            if (config.CustomButtons?.Count > 0)
            {
                wasStd = false;
                i = 0;

                foreach (var btn in config.CustomButtons)
                {

                    if (btn.CustomResult != null)
                    {
                        stashed.Add(btn.CustomResult);
                        btn.CustomResult = i++;
                    }

                    if (btn.DropDownMenuButtons?.Count > 0)
                    {
                        foreach (var btn2 in btn.DropDownMenuButtons)
                        {
                            if (btn2.CustomResult != null)
                            {
                                stashed.Add(btn2.CustomResult);
                                btn2.CustomResult = i++;
                            }
                        }
                    }

                }
            }
            else
            {
                wasStd = true;
                config.CustomButtons = MakeButtons(config.MessageBoxType);
            }


            try 
            {
                string json;
                
                json = JsonConvert.SerializeObject(config);


                using (Process proc = new Process())
                {
                    proc.StartInfo.FileName = "MsgExHelper.exe";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardInput = true;
                    
                    proc.Start();

                    proc.StandardInput.Write(json + (char)26 + (visualStyles ? '1' : '0'));

                    json = null;
                    json = proc.StandardOutput.ReadToEnd();
                    proc.WaitForExit();

                    result = (MessageBoxExResult)proc.ExitCode;
                    proc.Dispose();
                }

                var newConfig = JsonConvert.DeserializeObject<MessageBoxExConfig>(json);

                config.CustomResult = stashed.Count > 0 ? stashed[int.Parse(newConfig.CustomResult.ToString())] : null;
                config.OptionResult = newConfig.OptionResult;

                if (wasStd) config.CustomButtons.Clear();

                stashed.Clear();
                
                GC.Collect(0);
                return result;
            }
            catch
            {
                return MessageBoxExResult.None;
            }

        }


        /// <summary>
        /// Shows a message box according to a <see cref="MessageBoxExConfig" /> object.
        /// Custom return values will be found in the <see cref="MessageBoxExConfig" /> object after the dialog box closes.
        /// This method allows more flexibility in how your dialog box behaves.
        /// </summary>
        /// <param name="config">The <see cref="MessageBoxExConfig" /> object to use to configure the dialog box.</param>
        /// <returns>A <see cref="MessageBoxExResult" /> value</returns>
        public static MessageBoxExResult Show(MessageBoxExConfig config)
        {
            form.SetMessage(config.Message /*, config.HtmlMessage */);
            form.Text = config.Title;

            form.TopMost = config.AlwaysOnTop;

            if (config.CustomButtons != null && config.CustomButtons.Count > 0)
            {
                form.SetButtons(config.CustomButtons);
            }
            else
            {
                form.SetButtons(MakeButtons(config.MessageBoxType));
            }

            if (config.CustomIcon != null)
            {
                form.SetIcon(config.CustomIcon);
            }
            else
            {
                form.SetIcon(GetIcon(config.Icon));
            }
            
            if (string.IsNullOrEmpty(config.OptionText))
            {
                form.SetUrl(false);
                form.SetOption(false);
            }
            else
            {
                if (config.OptionMode == OptionTextMode.Checkbox)
                {
                    form.SetOption(true, config.OptionText);
                }
                else
                {
                    form.SetUrl(true, config.OptionText, config.OptionTextUrl, config.UrlClickDismiss);
                }

            }

            form.OptionResult = config.OptionResult;
            form.FormatBox();
            
            if (!config.MuteSound)
                PlaySound(config.Icon);
            
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.ShowDialog();

            config.Dismissed = form.Dismissed;
            config.CustomResult = form.CustomResult;
            config.OptionResult = form.OptionResult;

            return form.Result;

        }

        /// <summary>
        /// Creates a message box with custom buttons, custom icon, and an option toggle.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="optionText">Text of the option checkbox</param>
        /// <param name="buttons">An <see cref="IEnumerable{T}" /> of <see cref="MessageBoxExButton" /> objects</param>
        /// <param name="icon">The custom icon for the box.</param>
        /// <param name="customResult">The result of the button that was pressed</param>
        /// <param name="optionResult">The result of the option toggle</param>
        /// <returns>A <see cref="MessageBoxExResult" /> value</returns>
        public static MessageBoxExResult Show(string message, string title, string optionText, IEnumerable<MessageBoxExButton> buttons, Bitmap icon, out object customResult, out bool optionResult)
        {

            var cfg = new MessageBoxExConfig()
            {
                Message = message,
                Title = title,
                OptionText = optionText,
                OptionMode = OptionTextMode.Checkbox,
                Icon = MessageBoxExIcons.Custom,
                CustomIcon = icon,
                MessageBoxType = MessageBoxExType.Custom
            };

            foreach (var button in buttons)
            {
                cfg.CustomButtons.Add(button);
            }

            var ret = Show(cfg);

            customResult = cfg.CustomResult;
            optionResult = cfg.OptionResult;

            return ret;

        }

        /// <summary>
        /// Creates a message box with custom buttons, custom icon, and an option toggle.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="optionText">Text of the option checkbox</param>
        /// <param name="buttons">An <see cref="IEnumerable{T}" /> of <see cref="MessageBoxExButton" /> objects</param>
        /// <param name="icon">A standard <see cref="MessageBoxExIcons" /> value</param>
        /// <param name="customResult">The result of the button that was pressed</param>
        /// <param name="optionResult">The result of the option toggle</param>
        /// <returns>A <see cref="MessageBoxExResult" /> value</returns>
        public static MessageBoxExResult Show(string message, string title, string optionText, IEnumerable<MessageBoxExButton> buttons, MessageBoxExIcons icon, out object customResult, out bool optionResult)
        {

            var cfg = new MessageBoxExConfig()
            {
                Message = message,
                Title = title,
                OptionText = optionText,
                OptionMode = OptionTextMode.Checkbox,
                Icon = icon,
                MessageBoxType = MessageBoxExType.Custom
            };

            foreach (var button in buttons)
            {
                cfg.CustomButtons.Add(button);
            }

            var ret = Show(cfg);

            customResult = cfg.CustomResult;
            optionResult = cfg.OptionResult;

            return ret;

        }


        /// <summary>
        /// Shows a message box with a message, title, custom buttons, and a standard icon.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="buttons">An <see cref="IEnumerable{T}" /> of <see cref="MessageBoxExButton" /> objects</param>
        /// <param name="icon">A standard <see cref="MessageBoxExIcons" /> value</param>
        /// <param name="customResult">The result of the button that was pressed</param>
        /// <returns>A <see cref="MessageBoxExResult" /> value</returns>
        public static MessageBoxExResult Show(string message, string title, IEnumerable<MessageBoxExButton> buttons, MessageBoxExIcons icon, out object customResult)
        {
            var cfg = new MessageBoxExConfig()
            {
                Message = message,
                Title = title,
                Icon = icon,
                MessageBoxType = MessageBoxExType.Custom
            };
            
            foreach (var button in buttons)
            {
                cfg.CustomButtons.Add(button);
            }

            var ret = Show(cfg);
            customResult = cfg.CustomResult;

            return ret;
        }


        /// <summary>
        /// Shows a message box with a message, title, standard buttons, and a standard icon.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="type">A standard <see cref="MessageBoxExType" /> value</param>
        /// <param name="icon">A standard <see cref="MessageBoxExIcons" /> value.</param>
        /// <returns>A <see cref="MessageBoxExResult" /> value</returns>

        public static MessageBoxExResult Show(string message, string title, MessageBoxExType type, MessageBoxExIcons icon)
        {
            var cfg = new MessageBoxExConfig()
            {
                Message = message,
                Title = title,
                Icon = icon,
                MessageBoxType = type
            };

            return Show(cfg);
        }

        /// <summary>
        /// Shows a message box with a message, title, standard buttons, a standard icon, and an option toggle.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="optionText">Option toggle button message</param>
        /// <param name="type">A standard <see cref="MessageBoxExType" /> value</param>
        /// <param name="icon">A standard <see cref="MessageBoxExIcons" /> value</param>
        /// <param name="optionResult">The result of the option toggle button</param>
        /// <returns>A <see cref="MessageBoxExResult" /> value</returns>
        public static MessageBoxExResult Show(string message, string title, string optionText, MessageBoxExType type, MessageBoxExIcons icon, out bool optionResult)
        {
            var cfg = new MessageBoxExConfig()
            {
                Message = message,
                Title = title,
                OptionText = optionText,
                OptionMode = OptionTextMode.Checkbox,
                Icon = icon,
                MessageBoxType = type
            };

            var ret = Show(cfg);

            optionResult = cfg.OptionResult;
            return ret;
        }


        /// <summary>
        /// Show a standard box with a message, a title.
        /// </summary>
        /// <param name="message">Text to display in the box</param>
        /// <param name="title">The title of the dialog box</param>
        /// <param name="type">A standard <see cref="MessageBoxExType" /> value</param>
        /// <returns>A <see cref="MessageBoxExResult" /> value</returns>
        public static MessageBoxExResult Show(string message, string title, MessageBoxExType type)
        {
            var cfg = new MessageBoxExConfig()
            {
                Message = message,
                Title = title,
                MessageBoxType = type
            };

            return Show(cfg);
        }

        /// <summary>
        /// Show a box with a message and OK button
        /// </summary>
        /// <param name="message">Text to display in the box</param>
        /// <returns>A <see cref="MessageBoxExResult" /> value</returns>
        public static MessageBoxExResult Show(string message)
        {
            var cfg = new MessageBoxExConfig()
            {
                Message = message,
                MessageBoxType = MessageBoxExType.OK
            };

            return Show(cfg);
        }

        private static void PlaySound(MessageBoxExIcons icon)
        {
            switch (icon)
            {
                case MessageBoxExIcons.Asterisk:

                    System.Media.SystemSounds.Asterisk.Play();
                    return;

                case MessageBoxExIcons.Error:

                    System.Media.SystemSounds.Beep.Play();
                    return;

                case MessageBoxExIcons.Exclamation:
                    System.Media.SystemSounds.Exclamation.Play();
                    return;

                case MessageBoxExIcons.Question:
                    SystemSounds.Question.Play();
                    return; 

                case MessageBoxExIcons.Shield:
                    SystemSounds.Exclamation.Play();
                    return;

                case MessageBoxExIcons.Warning:
                    System.Media.SystemSounds.Exclamation.Play();
                    return;

            }


        }

        private static System.Drawing.Bitmap GetIcon(MessageBoxExIcons icon)
        {
            switch (icon)
            {
                case MessageBoxExIcons.Asterisk:
                    
                    return SystemIcons.Asterisk.ToBitmap();

                case MessageBoxExIcons.Error:

                    return SystemIcons.Error.ToBitmap();

                case MessageBoxExIcons.Exclamation:

                    return SystemIcons.Exclamation.ToBitmap();

                case MessageBoxExIcons.Hand:

                    return SystemIcons.Hand.ToBitmap();

                case MessageBoxExIcons.Information:

                    return SystemIcons.Information.ToBitmap();

                case MessageBoxExIcons.Question:

                    return SystemIcons.Question.ToBitmap();

                case MessageBoxExIcons.Shield:

                    return SystemIcons.Shield.ToBitmap();

                case MessageBoxExIcons.Warning:

                    return SystemIcons.Warning.ToBitmap();
            }

            return null;
        }




    }
}
