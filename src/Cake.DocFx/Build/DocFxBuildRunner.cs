using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.DocFx.Helper;

namespace Cake.DocFx.Build
{
    /// <summary>
    /// Command line runner for the <c>docfx build</c> command.
    /// </summary>
    internal sealed class DocFxBuildRunner : DocFxTool<DocFxBuildSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxBuildRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        public DocFxBuildRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) 
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs DocFx for the current folder with the given configuration.
        /// </summary>
        /// <param name="path">The optional path to the docfx.json config file.</param>
        /// <param name="settings">The settings.</param>
        public void Run(FilePath path, DocFxBuildSettings settings)
        {
            Contract.NotNull(settings, nameof(settings));

            Run(settings, GetArguments(path, settings));
        }

        private ProcessArgumentBuilder GetArguments(FilePath configFile, DocFxBuildSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // command
            builder.Append("build");

            // parameters
            #region DupFinder Exclusion
            if (configFile != null)
                builder.Append("\"{0}\"", configFile.FullPath);

            if (settings.OutputPath != null)
                builder.Append("-o \"{0}\"", settings.OutputPath.FullPath);

            if (settings.LogPath != null)
                builder.Append("-l \"{0}\"", settings.LogPath.FullPath);

            if (settings.LogLevel != DocFxLogLevel.Default)
                builder.Append("--logLevel \"{0}\"", settings.LogLevel);

            if (settings.TemplateFolder != null)
                builder.Append("-t \"{0}\"", settings.TemplateFolder.FullPath);

            if (settings.GlobalMetadata.Any())
                builder.Append(
                    "--globalMetadata \"{{{0}}}\"",
                    string.Join(", ", settings.GlobalMetadata.Select(x => $"\\\"{x.Key}\\\": \\\"{x.Value}\\\"")));

            if (settings.Serve)
            {
                builder.Append("--serve");
            }
            #endregion

            if (settings.Force)
            {
                builder.Append("--force");
            }

            if (settings.WarningsAsErrors)
            {
                builder.Append("--warningsAsErrors");
            }

            return builder;
        }
    }
}
