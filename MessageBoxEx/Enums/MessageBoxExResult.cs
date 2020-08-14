using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTools.MessageBoxEx
{

    /// <summary>
    /// Message box results.
    /// </summary>
    [Flags]
    public enum MessageBoxExResult
    {
        /// <summary>
        /// Converts to false when cast to bool
        /// </summary>
        No = 0,

        /// <summary>
        /// Does not convert to false when cast to bool
        /// </summary>
        Cancel = 8,

        /// <summary>
        /// Converts to false when cast to bool
        /// </summary>
        Abort = 0,

        /// <summary>
        /// Converts to true when cast to bool
        /// </summary>
        Yes = 1,

        /// <summary>
        /// Converts to true when cast to bool
        /// </summary>
        OK = 1,

        /// <summary>
        ///  Converts to true when cast to bool
        /// </summary>
        Retry = 1,

        /// <summary>
        /// All can be combined with any other flag (for future features).
        /// </summary>
        All = 2,

        /// <summary>
        /// A bitwise OR of Yes and All
        /// </summary>
        YesToAll = 3,

        /// <summary>
        /// Converts to true when cast to bool
        /// </summary>
        Ignore = 4,

        /// <summary>
        /// Custom result to be retrieved from the CustomResult parameter.
        /// </summary>
        Custom = 0x100
    }


}
