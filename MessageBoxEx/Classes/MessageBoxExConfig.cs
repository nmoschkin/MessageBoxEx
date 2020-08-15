using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// Configuration object to be passed to MessageBoxEx.Show() containing 
    /// parameters and customization options for the dialog box.
    /// </summary>
    public class MessageBoxExConfig
    {

        /// <summary>
        /// List of custom buttons.
        /// Default buttons arae only displayed if this list is empty.
        /// </summary>
        public List<MessageBoxExButton> CustomButtons { get; set; } = new List<MessageBoxExButton>();

        /// <summary>
        /// Specifies the message box type.
        /// </summary>
        public MessageBoxExButtonSet MessageBoxType { get; set; } = MessageBoxExButtonSet.OK;

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
        public Bitmap CustomIcon { get; set; } = null;


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
        /// If this text is not null, either a url or a checkbox will be displayed.
        /// The state of the toggle when the dialog closes can be found in the OptionResult property.
        /// In Url mode this can be any file or process that you have permission to start.
        /// </summary>
        public string OptionText { get; set; } = null;

        /// <summary>
        /// The mode of the option text. Default is checkbox.
        /// In Url mode the OptionText can be any file or process that you have permission to start.
        /// </summary>
        public OptionTextMode OptionMode { get; set; } = OptionTextMode.Checkbox;

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
