using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx.Pdf
{
    /// <summary>
    /// Command line runner for the <c>docfx pdf</c> command.
    /// </summary>
    internal sealed class DocFxPdfRunner : BaseLoggingDocFxRunner<DocFxPdfSettings>
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

        /// <inheritdoc/>
        protected override void GetArguments(ProcessArgumentBuilder builder, FilePath configFile, DocFxPdfSettings settings)
        {
            // command
            builder.Append("pdf");

            // parameters
            #region DupFinder Exclusion
            if (configFile != null)
                builder.Append("\"{0}\"", configFile.FullPath);

            if (settings.OutputPath != null)
                builder.Append("-o \"{0}\"", settings.OutputPath.FullPath);

            if (settings.TemplateFolder != null)
                builder.Append("-t \"{0}\"", settings.TemplateFolder.FullPath);

            if (settings.GlobalMetadata.Any())
                builder.Append(
                    "--globalMetadata \"{{{0}}}\"",
                    string.Join(", ", settings.GlobalMetadata.Select(x => $"\\\"{x.Key}\\\": \\\"{x.Value}\\\"")));

            if (settings.Name != null)
                builder.Append("--name \"{0}\"", settings.Name);
            #endregion
        }

    }
}
