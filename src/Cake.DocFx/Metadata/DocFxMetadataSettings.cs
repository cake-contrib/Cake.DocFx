using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx.Metadata
{
    /// <summary>
    /// Contains settings used by <see cref="DocFxMetadataRunner"/>.
    /// </summary>
    public class DocFxMetadataSettings : ToolSettings
    {
        /// <summary>
        ///     Specifies the projects to have metadata extracted. There are several approaches to extract language metadata.
        ///     1. From a supported project file or project file list
        ///         Supported project file extensions include .csproj, .vbproj, .sln.
        ///     2. From a supported source code file or source code file list
        ///         Supported source code file extensions include .cs and .vb. Files can be combined using , as seperator and search
        ///     pattern.
        ///     3. From docfx.json file. If the argument is not specified, docfx.exe will try reading docfx.json under current
        ///     directory.
        /// </summary>
        public IEnumerable<FilePath> Projects { get; set; }

        /// <summary>
        /// Gets or sets the output folder. The default is api, and is configured in the 'metadata' section of docfx.json.
        /// </summary>
        public DirectoryPath OutputPath { get; set; }
    }
}