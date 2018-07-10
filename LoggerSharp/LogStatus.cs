using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerSharp
{
    /// <summary>
    /// The status IDs for LoggerSharp that allows use of status in the logger.
    /// </summary>
    public enum LogStatus
    {
        /// <summary>
        /// Turns off any logging.
        /// </summary>
        OFF = -5,
        /// <summary>
        /// Marks the output as [DEBUG][SEVERE].
        /// </summary>
        DEBUG_SEVERE = -4,
        /// <summary>
        /// Marks the output as [DEBUG][ERROR].
        /// </summary>
        DEBUG_ERROR = -3,
        /// <summary>
        /// Marks the output as [DEBUG][WARNING].
        /// </summary>
        DEBUG_WARNING = -2,
        /// <summary>
        /// Marks the output as [DEBUG][INFO].
        /// </summary>
        DEBUG_INFO = -1,
        /// <summary>
        /// Marks the output as [INFO].
        /// </summary>
        INFO = 0,
        /// <summary>
        /// Marks the output as [WARNING].
        /// </summary>
        WARNING = 1,
        /// <summary>
        /// Marks the output as [ERROR].
        /// </summary>
        ERROR = 2,
        /// <summary>
        /// Marks the output as [SEVERE].
        /// </summary>
        SEVERE = 3
    }
}
