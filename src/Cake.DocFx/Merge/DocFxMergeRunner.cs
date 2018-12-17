using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Linq;

namespace Cake.DocFx.Merge
{
    /// <summary>
    /// Command line runner for the <c>docfx merge</c> command.
    /// </summary>
    internal sealed class DocFxMergeRunner : BaseLoggingDocFxRunner<DocFxMergeSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxMergeRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        public DocFxMergeRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <inheritdoc/>
        protected override void GetArguments(ProcessArgumentBuilder builder, FilePath configFile, DocFxMergeSettings settings)
        {
            // command
            builder.Append("merge");

            // parameters
            if (configFile != null)
                builder.Append("\"{0}\"", configFile.FullPath);

            if (settings.GlobalMetadata?.Any() == true)
                builder.Append(
                    "--globalMetadata \"{{{0}}}\"",
                    string.Join(", ", settings.GlobalMetadata.Select(x => $"\\\"{x.Key}\\\": \\\"{x.Value}\\\"")));

            if (settings.TocMetadata?.Any() == true)
                builder.Append("--tocMetadata \"{0}\"", string.Join(",", settings.TocMetadata));
        }

    }
}
