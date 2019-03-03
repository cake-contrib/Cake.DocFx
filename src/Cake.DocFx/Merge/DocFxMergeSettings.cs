using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Collections.Generic;

namespace Cake.DocFx.Merge
{
    /// <summary>
    /// Contains settings used by <see cref="DocFxMergeRunner"/>.
    /// </summary>
    public class DocFxMergeSettings : BaseDocFxLogSettings
    {

        /// <summary>
        /// Gets global metadata.
        /// It overrides the globalMetadata settings from the config file.
        /// See <see cref="DocFxGlobalMetadata"/> for constants for metadata keys.
        /// </summary>
        public IDictionary<string, string> GlobalMetadata { get; } = new Dictionary<string, string>();
        
        /// <summary>
        /// Gets the TOC metadata names that need to be merged into the file.
        /// </summary>
        public IList<string> TocMetadata { get; } = new List<string>();

    }
}
