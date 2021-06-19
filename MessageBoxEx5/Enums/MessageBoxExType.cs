using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// <see cref="MessageBoxEx"/> message box types (a collection of standard buttons.)  
    /// Where possible, these values correspond directly to the equivalent <see cref="MessageBoxButtons" /> values.
    /// </summary>
    public enum MessageBoxExType

    {
        /// <summary>
        /// OK button
        /// </summary>
        OK = MessageBoxButtons.OK,

        /// <summary>
        /// OK and Cancel buttons
        /// </summary>
        OKCancel = MessageBoxButtons.OKCancel,

        /// <summary>
        /// Abort, Retry, and Ignore buttons
        /// </summary>
        AbortRetryIgnore = MessageBoxButtons.AbortRetryIgnore,

        /// <summary>
        /// Yes, No, and Cancel buttons
        /// </summary>
        YesNoCancel = MessageBoxButtons.YesNoCancel,

        /// <summary>
        /// Yes and No buttons
        /// </summary>
        YesNo = MessageBoxButtons.YesNo,

        /// <summary>
        /// Abort, Retry, and Ignore buttons
        /// </summary>
        RetryCancel = MessageBoxButtons.RetryCancel,

        /// <summary>
        /// Yes, No, and Yes To All buttons
        /// </summary>
        YesNoAll,

        /// <summary>
        /// Yes, No, Yes To All, and Cancel buttons
        /// </summary>
        YesNoAllCancel,

        /// <summary>
        /// Custom buttons defined by the user
        /// </summary>
        Custom = 0x100

    }

}
