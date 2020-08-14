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
    public enum MessageBoxExButtons
    {
        OK,
        OKCancel,
        YesNo,
        YesNoCancel,
        YesNoAll,
        YesNoAllCancel,
        AbortRetryIgnore,
        Custom

    }

    public enum MessageBoxExResult
    {
        No = 0,
        Cancel = 1,
        Abort = 2,
        Yes = 3,
        OK = 4,
        All = 5,
        Retry = 6,
        Ignore = 7,
        Custom = 8
    }

    public enum MessageBoxExIcons
    {
        None,
        Asterisk,
        Error,
        Exclamation,
        Hand,
        Information,
        Question,
        Shield,
        Warning	
    }

    public class MessageBoxExButton 
    { 
        public Bitmap Image { get; internal set; }

        public string Message { get; internal set; }

        public MessageBoxExResult Result { get; internal set; } = MessageBoxExResult.OK;

        public string CustomResult { get; internal set; } = null;

        public bool IsDefault { get; internal set; }

        internal System.Windows.Forms.Button Button { get; set; }

        public MessageBoxExButton(string caption, MessageBoxExResult result, bool isDefault = false)
        {
            Message = caption;
            Result = result;
            IsDefault = isDefault;
            CustomResult = null;
        }

        public MessageBoxExButton(string caption, string customResult, bool isDefault = false)
        {
            Message = caption;
            CustomResult = customResult;
            Result = MessageBoxExResult.Custom;
            IsDefault = isDefault;
        }

        public MessageBoxExButton(string caption, MessageBoxExResult result, Bitmap image, bool isDefault = false)
        {
            Message = caption;
            Result = result;
            IsDefault = isDefault;
            Image = image;

        }

        public MessageBoxExButton(string caption, string customResult, Bitmap image, bool isDefault = false)
        {
            Message = caption;
            CustomResult = customResult;
            Result = MessageBoxExResult.Custom;
            IsDefault = isDefault;
            Image = image;
        }


    }

    public static class MessageBoxEx
    {
        private static frmMsgBox form = new frmMsgBox();

        static MessageBoxEx()
        {
        }

        private static List<MessageBoxExButton> MakeButtons(MessageBoxExButtons b)
        {
            var btnOut = new List<MessageBoxExButton>();

            switch(b)
            {
                case MessageBoxExButtons.AbortRetryIgnore:

                    btnOut.Add(new MessageBoxExButton("&Abort", MessageBoxExResult.Abort));
                    btnOut.Add(new MessageBoxExButton("&Retry", MessageBoxExResult.Abort, true));
                    btnOut.Add(new MessageBoxExButton("&Ignore", MessageBoxExResult.Abort));
                    
                    break;

                case MessageBoxExButtons.OK:

                    btnOut.Add(new MessageBoxExButton("&OK", MessageBoxExResult.Abort, true));
                    break;

                case MessageBoxExButtons.OKCancel:

                    btnOut.Add(new MessageBoxExButton("&OK", MessageBoxExResult.Abort, true));
                    btnOut.Add(new MessageBoxExButton("&Cancel", MessageBoxExResult.Cancel, false));
                    
                    break;

                case MessageBoxExButtons.YesNo:

                    btnOut.Add(new MessageBoxExButton("&Yes", MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton("&No", MessageBoxExResult.No, false));

                    break;

                case MessageBoxExButtons.YesNoCancel:

                    btnOut.Add(new MessageBoxExButton("&Yes", MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton("&No", MessageBoxExResult.No, false));
                    btnOut.Add(new MessageBoxExButton("&Cancel", MessageBoxExResult.Cancel, false));

                    break;
                case MessageBoxExButtons.YesNoAll:

                    btnOut.Add(new MessageBoxExButton("&Yes", MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton("Yes To &All", MessageBoxExResult.All, false));
                    btnOut.Add(new MessageBoxExButton("&No", MessageBoxExResult.No, false));

                    break;

                case MessageBoxExButtons.YesNoAllCancel:

                    btnOut.Add(new MessageBoxExButton("&Yes", MessageBoxExResult.Yes, true));
                    btnOut.Add(new MessageBoxExButton("Yes To &All", MessageBoxExResult.All, false));
                    btnOut.Add(new MessageBoxExButton("&No", MessageBoxExResult.No, false));
                    btnOut.Add(new MessageBoxExButton("&Cancel", MessageBoxExResult.Cancel, false));

                    break;
            }

            return btnOut;
        }

        public static MessageBoxExResult Show(string message, string title, string optionText, IEnumerable<MessageBoxExButton> buttons, MessageBoxExIcons icon, out string customResult, out bool optionResult)
        {

            form.SetMessage(message);
            form.Text = title;
            form.SetButtons(buttons);
            form.SetIcon(GetIcon(icon));
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.SetOption(true, optionText);

            form.FormatBox();
            PlaySound(icon);

            form.ShowDialog();
                       
            customResult = form.CustomResult;
            optionResult = form.OptionResult; 

            return form.Result;

        }

        public static MessageBoxExResult Show(string message, string title, IEnumerable<MessageBoxExButton> buttons, MessageBoxExIcons icon, out string customResult)
        {
           
            form.SetMessage(message);
            form.Text = title;
            form.SetButtons(buttons);
            form.SetIcon(GetIcon(icon));
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.SetOption(false);

            form.FormatBox();
            PlaySound(icon);

            form.ShowDialog();
            customResult = form.CustomResult;

            return form.Result;

        }
        public static MessageBoxExResult Show(string message, string title, IEnumerable<MessageBoxExButton> buttons, out string customResult)
        {
            return Show(message, title, buttons, MessageBoxExIcons.None, out customResult);
        }

        public static MessageBoxExResult Show(string message, string title, MessageBoxExButtons buttons, MessageBoxExIcons icon)
        {
            var btns = MakeButtons(buttons);

            form.SetMessage(message);
            form.Text = title;
            form.SetButtons(btns);
            form.SetIcon(GetIcon(icon));
            form.SetOption(false);

            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            form.FormatBox();
            PlaySound(icon);

            form.ShowDialog();

            return form.Result;
        }

        public static MessageBoxExResult Show(string message, string title, string optionText, MessageBoxExButtons buttons, MessageBoxExIcons icon, out bool optionResult)
        {
            var btns = MakeButtons(buttons);

            form.SetMessage(message);
            
            form.Text = title;
            form.SetButtons(btns);
            form.SetIcon(GetIcon(icon));
            form.SetOption(true, optionText);
            
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            form.FormatBox();
            PlaySound(icon);

            form.ShowDialog();

            optionResult = form.OptionResult;

            return form.Result;
        }


        public static MessageBoxExResult Show(string message, string title, MessageBoxExButtons buttons)
        {
            return Show(message, title, buttons, MessageBoxExIcons.None);
        }

        public static MessageBoxExResult Show(string message)
        {
            return Show(message, null, MessageBoxExButtons.OK, MessageBoxExIcons.None);
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
                    return; 

                case MessageBoxExIcons.Shield:
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
