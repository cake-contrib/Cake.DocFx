namespace Cake.DocFx
{
    /// <summary>
    /// Acceptable log levels for DocFx.
    /// </summary>
    public enum DocFxLogLevel
    {
        /// <summary>
        /// Default log level of DocFx.
        /// Same as <see cref="Info"/>.
        /// </summary>
        Default,

        /// <summary>
        /// Verbose logging.
        /// </summary>
        Verbose,

        /// <summary>
        /// Logs errors, warnings and informational messages. 
        /// </summary>
        Info,

        /// <summary>
        /// Logs errors and warnings.
        /// </summary>
        Warning,

        /// <summary>
        /// Logs only errors.
        /// </summary>
        Error
    }
}
