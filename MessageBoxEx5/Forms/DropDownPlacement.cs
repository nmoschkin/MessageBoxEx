using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// Specifies where the drop-down button goes.
    /// </summary>
    public enum DropDownPlacement
    {
        /// <summary>
        /// No drop-down menu.  Items in the DropDownMenu list are ignored.
        /// </summary>
        None,

        /// <summary>
        /// There is a down-arrow button placed immediately to the left of the button that will act as the trigger for the drop-down menu.
        /// </summary>
        Left,

        /// <summary>
        /// There is a down-arrow button placed immediately to the right of the button that will act as the trigger for the drop-down menu.
        /// </summary>
        Right
    }

}
