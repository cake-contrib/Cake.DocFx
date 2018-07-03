using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.DocFx.Helper;

namespace Cake.DocFx.Pdf
{
    /// <summary>
    /// Command line runner for the <c>docfx pdf</c> command.
    /// </summary>
    internal sealed class DocFxPdfRunner : DocFxTool<DocFxPdfSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxPdfRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public DocFxPdfRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) 
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs DocFx generator with the given configuration.
        /// </summary>
        /// <param name="configFile">The optional path to the docfx.json config file.</param>
        /// <param name="settings">The settings.</param>
        public void Run(FilePath configFile, DocFxPdfSettings settings)
        {
            Contract.NotNull(settings, nameof(settings));

            Run(settings, GetArguments(configFile, settings));
        }

        private ProcessArgumentBuilder GetArguments(FilePath configFile, DocFxPdfSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // command
            builder.Append("pdf");

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

            if (settings.Name != null)
                builder.Append("--name \"{0}\"", settings.Name);
            #endregion

            return builder;
        }
    }
}
