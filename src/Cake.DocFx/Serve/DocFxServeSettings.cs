using Cake.Core.Tooling;

namespace Cake.DocFx.Serve
{
    /// <summary>
    /// Contains settings used by <see cref="DocFxServeRunner"/>.
    /// </summary>
    public class DocFxServeSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the hostname on which to serve the content. Defaults to 'localhost'.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets the local port on which to serve the content. Defaults to '8080'.
        /// </summary>
        public string Port { get; set; }
    }
}
