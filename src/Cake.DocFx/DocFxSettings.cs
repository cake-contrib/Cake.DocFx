using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx
{
    public class DocFxSettings : ToolSettings
    {
        /// <summary>
        ///     Optional argument.
        ///     The default output folder is _site/ folder
        /// </summary>
        public DirectoryPath OutputPath { get; set; }
    }
}
