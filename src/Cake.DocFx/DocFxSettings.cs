using System;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx
{
    /// <summary>
    /// Obsolete use aliases from <see cref="DocFxBuildAliases"/> instead.
    /// </summary>
    public class DocFxSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the output folder. The default is _site, and is configured in the 'build' section of docfx.json.
        /// </summary>
        public DirectoryPath OutputPath { get; set; }
    }
}
