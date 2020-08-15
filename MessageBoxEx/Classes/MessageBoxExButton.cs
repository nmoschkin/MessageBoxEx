using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// Class that represents a button on the dialog box.
    /// </summary>
    public class MessageBoxExButton
    {
        /// <summary>
        /// Custom icon
        /// </summary>
        public Bitmap Image { get; set; }

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
        /// Note, if there is more than one default button set, the last one wins.
        /// </summary>
        public bool IsDefault { get; internal set; }

        internal System.Windows.Forms.Button Button { get; set; }

        /// <summary>
        /// Create a new standard button.
        /// </summary>
        /// <param name="caption">The button text</param>
        /// <param name="result">The button result</param>
        /// <param name="isDefault">Is the default button</param>
        public MessageBoxExButton(string caption, MessageBoxExResult result, bool isDefault = false)
        {
            Message = caption;
            Result = result;
            IsDefault = isDefault;
            CustomResult = null;
        }

        /// <summary>
        /// Createa a new custom button with a custom result value.
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
