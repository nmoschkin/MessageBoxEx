using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Media;

namespace DataTools.MessageBoxEx
{
    

    /// <summary>
    /// Enhanced Windows Desktop MessageBox replacement
    /// </summary>
    public static class MessageBoxEx
    {
        private static frmMsgBox form = new frmMsgBox();

        /// <summary>
        /// Static constructor.
        /// </summary>
        static MessageBoxEx()
        {

        }

        /// <summary>
        /// Internal code to generate standard message box buttons for a specific type of message box.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private static List<MessageBoxExButton> MakeButtons(MessageBoxExButtonSet b)
        {
            var btnOut = new List<MessageBoxExButton>();

            switch(b)
            {
                case MessageBoxExButtonSet.AbortRetryIgnore:

                    btnOut.Add(new MessageBoxExButton("&Abort", MessageBoxExResult.Abort));
                    btnOut.Add(new MessageBoxExButton("&Retry", MessageBoxExResult.Abort, true));
                    btnOut.Add(new MessageBoxExButton("&Ignore", MessageBoxExResult.Abort));
                    
                    break;

                case MessageBoxExButtonSet.OK:

                    btnOut.Add(new MessageBoxExButton("&OK", MessageBoxExResult.Abort, true));
                    break;

                case MessageBoxExButtonSet.OKCancel:

                    btnOut.Add(new MessageBoxExButton("&OK", MessageBoxExResult.Abort, true));
                    btnOut.Add(new MessageBoxExButton("&Cancel", MessageBoxExResult.Cancel, false));
                    
                    break;

                case MessageBoxExButtonSet.YesNo:

                    btnOut.Add(new MessageBoxExButton("&Yes", MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton("&No", MessageBoxExResult.No, false));

                    break;

                case MessageBoxExButtonSet.YesNoCancel:

                    btnOut.Add(new MessageBoxExButton("&Yes", MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton("&No", MessageBoxExResult.No, false));
                    btnOut.Add(new MessageBoxExButton("&Cancel", MessageBoxExResult.Cancel, false));

                    break;
                case MessageBoxExButtonSet.YesNoAll:

                    btnOut.Add(new MessageBoxExButton("&Yes", MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton("Yes To &All", MessageBoxExResult.YesToAll, false));
                    btnOut.Add(new MessageBoxExButton("&No", MessageBoxExResult.No, false));

                    break;

                case MessageBoxExButtonSet.YesNoAllCancel:

                    btnOut.Add(new MessageBoxExButton("&Yes", MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton("Yes To &All", MessageBoxExResult.YesToAll, false));
                    btnOut.Add(new MessageBoxExButton("&No", MessageBoxExResult.No, false));
                    btnOut.Add(new MessageBoxExButton("&Cancel", MessageBoxExResult.Cancel, false));

                    break;
            }

            return btnOut;
        }


        /// <summary>
        /// Shows a message box according to a MessageBoxExConfig object.
        /// Custom return values will be found in the config object after the dialog box closes.
        /// This method allows more flexibility in how your dialog box behaves.
        /// </summary>
        /// <param name="config">The MessageBoxExConfig object to use to configure the dialog box.</param>
        /// <returns></returns>
        public static MessageBoxExResult Show(MessageBoxExConfig config)
        {

            form.SetMessage(config.Message);
            form.Text = config.Title;

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
                    form.SetUrl(true, config.OptionText, config.OptionTextUrl);
                }

            }

            form.OptionResult = config.OptionResult;
            form.FormatBox();
            
            if (!config.MuteSoud)
                PlaySound(config.Icon);
            
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.ShowDialog();

            config.CustomResult = form.CustomResult;
            config.OptionResult = form.OptionResult;

            return form.Result;


        }

        /// <summary>
        /// Creates a message box with custom buttons, custom icon, and an option toggle.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="optionText">Text of the option checkmark</param>
        /// <param name="buttons">An IEnumerable of MessageBoxExButton objects.</param>
        /// <param name="icon">The custom icon for the box.</param>
        /// <param name="customResult">The result of the button that was pressed.</param>
        /// <param name="optionResult">The result of the optio toggle.</param>
        /// <returns></returns>
        public static MessageBoxExResult Show(string message, string title, string optionText, IEnumerable<MessageBoxExButton> buttons, Bitmap icon, out object customResult, out bool optionResult)
        {

            form.SetMessage(message);
            form.Text = title;
            form.SetButtons(buttons);
            form.SetIcon(icon);
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.SetOption(true, optionText);
            form.OptionResult = false;

            form.FormatBox();
            form.ShowDialog();
                       
            customResult = form.CustomResult;
            optionResult = form.OptionResult; 

            return form.Result;

        }

        /// <summary>
        /// Creates a message box with custom buttons, custom icon, and an option toggle.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="optionText">Text of the option checkmark</param>
        /// <param name="buttons">An IEnumerable of MessageBoxExButton objects.</param>
        /// <param name="icon">The standard icon for the box.</param>
        /// <param name="customResult">The result of the button that was pressed.</param>
        /// <param name="optionResult">The result of the option toggle.</param>
        /// <returns></returns>
        public static MessageBoxExResult Show(string message, string title, string optionText, IEnumerable<MessageBoxExButton> buttons, MessageBoxExIcons icon, out object customResult, out bool optionResult)
        {

            form.SetMessage(message);
            form.Text = title;
            form.SetButtons(buttons);
            form.SetIcon(GetIcon(icon));
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.SetOption(true, optionText);
            form.OptionResult = false;

            form.FormatBox();
            PlaySound(icon);

            form.ShowDialog();

            customResult = form.CustomResult;
            optionResult = form.OptionResult;

            return form.Result;

        }


        /// <summary>
        /// Shows a message box with a message, title, custom buttons, and a standard icon.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="buttons">An IEnumerable of MessageBoxExButton objects.</param>
        /// <param name="icon">The stamdard icon for the box.</param>
        /// <param name="customResult">The result of the button that was pressed.</param>
        /// <returns></returns>
        public static MessageBoxExResult Show(string message, string title, IEnumerable<MessageBoxExButton> buttons, MessageBoxExIcons icon, out object customResult)
        {
           
            form.SetMessage(message);
            form.Text = title;
            form.SetButtons(buttons);
            form.SetIcon(GetIcon(icon));
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.SetOption(false);
            form.OptionResult = false;

            form.FormatBox();
            PlaySound(icon);

            form.ShowDialog();
            customResult = form.CustomResult;

            return form.Result;

        }


        /// <summary>
        /// Shows a message box with a message, title, standard buttons, and a standard icon.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="buttons">An IEnumerable of MessageBoxExButton objects.</param>
        /// <param name="icon">The stamdard icon for the box.</param>
        /// <returns></returns>

        public static MessageBoxExResult Show(string message, string title, MessageBoxExButtonSet buttons, MessageBoxExIcons icon)
        {
            var btns = MakeButtons(buttons);

            form.SetMessage(message);
            form.Text = title;
            form.SetButtons(btns);
            form.SetIcon(GetIcon(icon));
            form.SetOption(false);
            form.OptionResult = false;

            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            form.FormatBox();
            PlaySound(icon);

            form.ShowDialog();

            return form.Result;
        }

        /// <summary>
        /// Shows a message box with a message, title, standard buttons, a standard icon, and an option toggle.
        /// </summary>
        /// <param name="message">Text to display in the dialog box</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="optionText">Option toggle button message.</param>
        /// <param name="buttons">An IEnumerable of MessageBoxExButton objects.</param>
        /// <param name="icon">The stamdard icon for the box.</param>
        /// <param name="optionResult">The result of the option toggle button.</param>
        /// <returns></returns>
        public static MessageBoxExResult Show(string message, string title, string optionText, MessageBoxExButtonSet buttons, MessageBoxExIcons icon, out bool optionResult)
        {
            var btns = MakeButtons(buttons);

            form.SetMessage(message);
            
            form.Text = title;
            form.SetButtons(btns);
            form.SetIcon(GetIcon(icon));
            form.SetOption(true, optionText);
            form.OptionResult = false;

            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            form.FormatBox();
            PlaySound(icon);

            form.ShowDialog();

            optionResult = form.OptionResult;

            return form.Result;
        }


        /// <summary>
        /// Show a standard box with a message, a title.
        /// </summary>
        /// <param name="message">Text to display in the box</param>
        /// <param name="title">The title of the dialog box</param>
        /// <param name="buttons">The buttons to show</param>
        /// <returns></returns>
        public static MessageBoxExResult Show(string message, string title, MessageBoxExButtonSet buttons)
        {
            return Show(message, title, buttons, MessageBoxExIcons.None);
        }

        /// <summary>
        /// Show a box with a message and OK button
        /// </summary>
        /// <param name="message">Text to display in the box</param>
        /// <returns></returns>
        public static MessageBoxExResult Show(string message)
        {
            return Show(message, null, MessageBoxExButtonSet.OK, MessageBoxExIcons.None);
        }

        private static void PlaySound(MessageBoxExIcons icon)
        {
            switch (icon)
            {
                case MessageBoxExIcons.Asterisk:

                    System.Media.SystemSounds.Asterisk.Play();
                    return;

                case MessageBoxExIcons.Error:

                    System.Media.SystemSounds.Exclamation.Play();
                    return;

                case MessageBoxExIcons.Exclamation:
                    System.Media.SystemSounds.Asterisk.Play();
                    return;

                case MessageBoxExIcons.Hand:
                    return;

                case MessageBoxExIcons.Information:
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
