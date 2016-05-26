using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains settings used by <see cref="DocFxBuildRunner"/>.
    /// </summary>
    public class DocFxBuildSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the output folder. The default is _site, and is configured in the 'build' 
        /// section of docfx.json.
        /// </summary>
        public DirectoryPath OutputPath { get; set; }

        /// <summary>
        /// Gets or sets the template path to use. If not specified, the default template configured 
        /// in the 'build' section of docfx.json will be used.
        /// </summary>
        public DirectoryPath TemplateFolder { get; set; }
    }
}