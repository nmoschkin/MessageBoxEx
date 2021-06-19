using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTools.MessageBoxEx
{

    /// <summary>
    /// Enumeration of results returned from a <see cref="MessageBoxEx" /> dialog box.
    /// Where possible, these values correspond directly to the equivalent <see cref="DialogResult" /> values.
    /// </summary>
    public enum MessageBoxExResult
    {
        /// <summary>
        /// None
        /// </summary>
        None = DialogResult.None,
        /// <summary>
        /// OK
        /// </summary>
        OK = DialogResult.OK,

        /// <summary>
        /// Cancel
        /// </summary>
        Cancel = DialogResult.Cancel,

        /// <summary>
        /// Abort
        /// </summary>
        Abort = DialogResult.Abort,

        /// <summary>
        /// Retry
        /// </summary>
        Retry = DialogResult.Retry,

        /// <summary>
        /// Ignore
        /// </summary>
        Ignore = DialogResult.Ignore,

        /// <summary>
        /// Yes
        /// </summary>
        Yes = DialogResult.Yes,

        /// <summary>
        /// No
        /// </summary>
        No = DialogResult.No,

        /// <summary>
        /// All can be combined with any other flag (for future features)
        /// </summary>
        All = 0x80,

        /// <summary>
        /// Yes To All; a bitwise OR of Yes and All
        /// </summary>
        YesToAll = Yes | All,

        /// <summary>
        /// Custom result to be retrieved from the CustomResult parameter.
        /// </summary>
        Custom = 0x100
            
    }


}
