using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Drawing.Imaging;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// Class that represents a button on the dialog box.
    /// </summary>
    public class MessageBoxExButton
    {

        /// <summary>
        /// Collection of buttons for a drop-down menu.
        /// </summary>
        public List<MessageBoxExButton> DropDownMenuButtons { get; set; } = new List<MessageBoxExButton>();

        /// <summary>
        /// Specifies the custom icon to display.
        /// </summary>
        [JsonIgnore]
        public Bitmap Image { get; set; } = null;


        [JsonProperty("EncodedIcon")]
        internal string EncodedIcon
        {
            get
            {
                if (Image == null) return null;
                MemoryStream m = new MemoryStream();

                Image.Save(m, ImageFormat.Png);
                var conv = Convert.ToBase64String(m.ToArray());

                m.Dispose();
            
                return conv;
            }
            set
            {
                if (value == null)
                {
                    Image = null;
                    return;
                }

                MemoryStream m = new MemoryStream(Convert.FromBase64String(value));

                Image = (Bitmap)System.Drawing.Image.FromStream(m);
                m.Dispose();
            }
        }

        /// <summary>
        /// Button text
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// MessageBox result
        /// </summary>
        public MessageBoxExResult Result { get; set; } = MessageBoxExResult.OK;

        /// <summary>
        /// Custom result
        /// </summary>
        public object CustomResult { get; set; } = null;

        /// <summary>
        /// Marks this button as default.  
        /// Note, if there is more than one default button set, the first one wins.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Sets the placement for the drop-down menu.
        /// </summary>
        public DropDownPlacement DropDownPlacement { get; set; } = DropDownPlacement.None;

        internal PictureBox Container { get; set; }

        internal ContextMenu ContextMenu { get; set; }

        internal Control DropDown { get; set; }

        internal Control Button { get; set; }

        /// <summary>
        /// Create a new empty button.
        /// </summary>
        public MessageBoxExButton()
        {

        }

        /// <summary>
        /// Create a new standard button.
        /// </summary>
        /// <param name="caption">The button text</param>
        /// <param name="result">The button result</param>
        /// <param name="isDefault">Is the default button</param>
        /// 
        public MessageBoxExButton(string caption, MessageBoxExResult result, bool isDefault = false)
        {
            Message = caption;
            Result = result;
            IsDefault = isDefault;
            CustomResult = null;
        }

        /// <summary>
        /// Create a new custom button with a custom result value.
        /// </summary>
        /// <param name="caption">The button text</param>
        /// <param name="customResult">The custom result this button will return</param>
        /// <param name="isDefault">Is the default button</param>
        public MessageBoxExButton(string caption, object customResult, bool isDefault = false)
        {
            Message = caption;
            CustomResult = customResult;
            Result = MessageBoxExResult.Custom;
            IsDefault = isDefault;
        }

        /// <summary>
        /// Create a new standard button with an image.
        /// </summary>
        /// <param name="caption">The button text</param>
        /// <param name="result">The button result</param>
        /// <param name="image">The button image</param>
        /// <param name="isDefault">Is the default button</param>
        public MessageBoxExButton(string caption, MessageBoxExResult result, Bitmap image, bool isDefault = false)
        {
            Message = caption;
            Result = result;
            IsDefault = isDefault;
            Image = image;

        }

        /// <summary>
        /// Create a new custom button with an image.
        /// </summary>
        /// <param name="caption">The button text</param>
        /// <param name="customResult">The custom result this button will return</param>
        /// <param name="image">The button image</param>
        /// <param name="isDefault">Is the default button</param>
        public MessageBoxExButton(string caption, object customResult, Bitmap image, bool isDefault = false)
        {
            Message = caption;
            CustomResult = customResult;
            Result = MessageBoxExResult.Custom;
            IsDefault = isDefault;
            Image = image;
        }


    }

}
