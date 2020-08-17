using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Imaging;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// Configuration object to be passed to MessageBoxEx.Show() containing 
    /// parameters and customization options for the dialog box.
    /// </summary>
    public class MessageBoxExConfig
    {

        /// <summary>
        /// Sets a value indicating that the dialog box shall be the top-most window on the desktop
        /// until it is dismissed.
        /// </summary>
        public bool AlwaysOnTop { get; set; } = true;

        /// <summary>
        /// List of custom buttons.
        /// Default buttons arae only displayed if this list is empty.
        /// </summary>
        public List<MessageBoxExButton> CustomButtons { get; set; } = new List<MessageBoxExButton>();

        /// <summary>
        /// Specifies the message box type.
        /// </summary>
        public MessageBoxExType MessageBoxType { get; set; } = MessageBoxExType.OK;

        /// <summary>
        /// Specifies whether to mute alert sounds.
        /// </summary>
        public bool MuteSound { get; set; } = false;

        /// <summary>
        /// Play a custom sound when the dialog box opens, regardless of the default sound for the selected icon.
        /// </summary>
        public MessageBoxExIcons SoundIcon { get; set; } = MessageBoxExIcons.None;

        /// <summary>
        /// Specifies the icon displayed to the left of the message, in the message box.
        /// </summary>
        public MessageBoxExIcons Icon { get; set; } = MessageBoxExIcons.None;


        /// <summary>
        /// Specifies the custom icon to display.
        /// </summary>
        [JsonIgnore]
        public Bitmap CustomIcon { get; set; } = null;

        [JsonProperty("EncodedIcon")]
        internal string EncodedIcon
        {
            get
            {
                if (CustomIcon == null) return null;
                MemoryStream m = new MemoryStream();

                CustomIcon.Save(m, ImageFormat.Png);
                var conv = Convert.ToBase64String(m.ToArray());

                m.Dispose();
                return conv;
            }
            set
            {
                if (value == null)
                {
                    CustomIcon = null;
                    return;
                }

                MemoryStream m = new MemoryStream(Convert.FromBase64String(value));

                CustomIcon = (Bitmap)Image.FromStream(m);
                m.Dispose();
            }
        }

        /// <summary>
        /// Specifies the title of the dialog box.
        /// </summary>
        public string Title { get; set; } = null;


        /// <summary>
        /// Specifies the message to be displayed.
        /// </summary>
        public string Message { get; set; } = null;

        /// <summary>
        /// Toggle option text.  
        /// If this text is not null, either a URL or a check box will be displayed.
        /// The state of the toggle when the dialog closes can be found in the OptionResult property.
        /// In URL mode this can be any file or process that you have permission to start.
        /// </summary>
        public string OptionText { get; set; } = null;

        /// <summary>
        /// The mode of the option text. Default is checkbox.
        /// In Url mode the OptionText can be any file or process that you have permission to start.
        /// </summary>
        public OptionTextMode OptionMode { get; set; } = OptionTextMode.Checkbox;

        /// <summary>
        /// Specify whether or not clicking the Url dismisses the dialog box.
        /// The default result will be returned.
        /// </summary>
        public bool UrlClickDismiss { get; set; } = false;

        /// <summary>
        /// The URL linked to the option text.
        /// </summary>
        public string OptionTextUrl { get; set; } = null;

        /// <summary>
        /// The custom result of the button that was pressed.
        /// </summary>
        public object CustomResult { get; set; } = null;


        /// <summary>
        /// The state of the checkbox when the dialog box was closed.
        /// </summary>
        public bool OptionResult { get; set; } = false;


    }

}
