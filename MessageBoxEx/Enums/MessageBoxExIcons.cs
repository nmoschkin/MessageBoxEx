using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// MessageBoxEx Icon Types
    /// </summary>
    public enum MessageBoxExIcons
    {
        /// <summary>
        /// None
        /// </summary>
        None,

        /// <summary>
        /// Asterisk
        /// </summary>
        Asterisk,

        /// <summary>
        /// Error
        /// </summary>
        Error,

        /// <summary>
        /// Exclamation
        /// </summary>
        Exclamation,

        /// <summary>
        /// Hand
        /// </summary>
        Hand,

        /// <summary>
        /// Information
        /// </summary>
        Information,

        /// <summary>
        /// Question
        /// </summary>
        Question,

        /// <summary>
        /// Shield
        /// </summary>
        Shield,

        /// <summary>
        /// Warning
        /// </summary>
        Warning,

        /// <summary>
        /// User provides the icon.  It will be sized to fit in the box.
        /// </summary>
        Custom = 0x100
    }


}
