using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTools.MessageBoxEx
{
    public enum MessageBoxExIcons
    {
        None,
        Asterisk,
        Error,
        Exclamation,
        Hand,
        Information,
        Question,
        Shield,
        Warning,

        /// <summary>
        /// User provides the icon.  It will be sized to fit in the box.
        /// </summary>
        Custom = 0x100
    }


}
