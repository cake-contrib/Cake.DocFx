using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains settings used by <see cref="DocFxRunner"/>.
    /// </summary>
    public class DocFxSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the output folder. The default is _site, and is configured in the 'build' section of docfx.json.
        /// </summary>
        public DirectoryPath OutputPath { get; set; }
    }
}
