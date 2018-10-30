using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.DocFx.Helper;
using System.Linq;

namespace Cake.DocFx.Merge
{
    /// <summary>
    /// Command line runner for the <c>docfx merge</c> command.
    /// </summary>
    internal sealed class DocFxMergeRunner : DocFxTool<DocFxMergeSettings>
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

        /// <summary>
        /// Runs DocFx merge with the given configuration.
        /// </summary>
        /// <param name="path">The optional path to the docfx.json config file.</param>
        /// <param name="settings">The settings.</param>
        public void Run(FilePath path, DocFxMergeSettings settings)
        {
            Contract.NotNull(settings, nameof(settings));

            Run(settings, GetArguments(path, settings));
        }

        private ProcessArgumentBuilder GetArguments(FilePath configFile, DocFxMergeSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // command
            builder.Append("merge");

            // parameters
            if (configFile != null)
                builder.Append("\"{0}\"", configFile.FullPath);

            if (!string.IsNullOrWhiteSpace(settings.CorrelationId))
                builder.Append("--correlationId {0}", settings.CorrelationId);

            if (settings.GlobalMetadata?.Any() == true)
                builder.Append(
                    "--globalMetadata \"{{{0}}}\"",
                    string.Join(", ", settings.GlobalMetadata.Select(x => $"\\\"{x.Key}\\\": \\\"{x.Value}\\\"")));

            if (settings.LogPath != null)
                builder.Append("-l \"{0}\"", settings.LogPath.FullPath);

            if (settings.LogLevel != DocFxLogLevel.Default)
                builder.Append("--logLevel \"{0}\"", settings.LogLevel);

            if (settings.RepositoryRoot != null)
                builder.Append("--repositoryRoot \"{0}\"", settings.RepositoryRoot.FullPath);

            if (settings.TocMetadata?.Any() == true)
                builder.Append("--tocMetadata \"{0}\"", string.Join(",", settings.TocMetadata));

            if (settings.WarningsAsErrors)
                builder.Append("--warningsAsErrors");

            return builder;
        }
    }
}
