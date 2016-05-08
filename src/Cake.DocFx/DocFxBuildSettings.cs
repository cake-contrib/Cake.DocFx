using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx
{
    /// <summary>
    /// Settings used for docfx build calls.
    /// </summary>
    public class DocFxBuildSettings : ToolSettings
    {
        /// <summary>
        /// Optional OutputPath argument.
        /// 
        /// The default output folder is _site/ folder
        /// </summary>
        public DirectoryPath OutputPath { get; set; }

        /// <summary>
        /// Optional TemplateFolder argument
        /// 
        /// If specified, use the template from template folder
        /// </summary>
        public DirectoryPath TemplateFolder { get; set; }
    }
}