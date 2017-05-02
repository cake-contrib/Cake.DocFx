using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx.Init
{
    /// <summary>
    /// Contains settings used by <see cref="DocFxInitRunner"/>.
    /// </summary>
    public class DocFxInitSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets a flag indicating if only the <code>docfx.json</code> file should be generated.
        /// In this case no project folder will be generated.
        /// </summary>
        public bool OnlyConfigFile { get; set; }

        /// <summary>
        /// Gets or sets the output folder of the config file.
        /// If not specified, the config file will be saved to a new folder <code>docfx_project</code>.
        /// </summary>
        public DirectoryPath OutputPath { get; set; }
    }
}