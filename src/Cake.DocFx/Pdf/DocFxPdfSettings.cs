using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Collections.Generic;

namespace Cake.DocFx.Pdf
{
    /// <summary>
    /// Contains settings used by <see cref="DocFxPdfRunner"/>.
    /// </summary>
    public class DocFxPdfSettings : BaseDocFxLogSettings
    {
        /// <summary>
        /// Gets or sets the output base directory.
        /// </summary>
        public DirectoryPath OutputPath { get; set; }

        /// <summary>
        /// Gets or sets the template path to use.
        /// </summary>
        public DirectoryPath TemplateFolder { get; set; }

        /// <summary>
        /// Gets global metadata.
        /// It overrides the globalMetadata settings from the config file.
        /// See <see cref="DocFxGlobalMetadata"/> for constants for metadata keys.
        /// </summary>
        public Dictionary<string, string> GlobalMetadata { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the name of the generated PDF.
        /// </summary>
        public string Name { get; set; }
    }
}