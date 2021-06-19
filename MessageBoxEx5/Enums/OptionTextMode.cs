using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// The modes to be used for the OptionTextMode parameter in MessageBoxExConfig.
    /// </summary>
    public enum OptionTextMode
    {
        /// <summary>
        /// Causes the option text to behave as a checkbox 
        /// whose result will be available to the caller.
        /// </summary>
        Checkbox,

        /// <summary>
        /// Causes the option text to behave as a URL
        /// that will open when clicked.
        /// </summary>
        Url
    }
}
