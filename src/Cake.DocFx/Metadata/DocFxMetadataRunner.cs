using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx.Metadata
{
    /// <summary>
    /// Command line runner for the <c>docfx metadata</c> command.
    /// </summary>
    internal sealed class DocFxMetadataRunner : BaseLoggingDocFxRunner<DocFxMetadataSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxMetadataRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        public DocFxMetadataRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <inheritdoc/>
        protected override void GetArguments(ProcessArgumentBuilder builder, FilePath configFile, DocFxMetadataSettings settings)
        {
            // command
            builder.Append("metadata");

            // parameters
            if (settings.Projects != null && settings.Projects.Any())
                builder.Append(string.Join(",", settings.Projects.Select(val => "\"" + val.FullPath + "\"")));

            #region DupFinder Exclusion
            if (settings.OutputPath != null)
                builder.Append("-o \"{0}\"", settings.OutputPath.FullPath);

            #endregion

            if (settings.Force)
            {
                builder.Append("--force");
            }
        }

    }
}
