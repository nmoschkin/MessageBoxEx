using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// Indicate which button configuraton to use.
    /// </summary>
    public enum MessageBoxExButtonSet
    {
        /// <summary>
        /// OK button
        /// </summary>
        OK,

        /// <summary>
        /// OK and Cancel buttons
        /// </summary>
        OKCancel,

        /// <summary>
        /// Yes and No buttons
        /// </summary>
        YesNo,

        /// <summary>
        /// Yes, No, and Cancel buttons
        /// </summary>
        YesNoCancel,

        /// <summary>
        /// Yes, No, and Yes To All buttons
        /// </summary>
        YesNoAll,

        /// <summary>
        /// Yes, No, Yes To All, and Cancel buttons
        /// </summary>
        YesNoAllCancel,

        /// <summary>
        /// Abort, Retry, and Ignore buttons
        /// </summary>
        AbortRetryIgnore,

        /// <summary>
        /// Custom buttons defined by the user
        /// </summary>
        Custom = 0x100

    }

}
