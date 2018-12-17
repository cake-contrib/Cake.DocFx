using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx.Build
{
    /// <summary>
    /// Command line runner for the <c>docfx build</c> command.
    /// </summary>
    internal sealed class DocFxBuildRunner : BaseLoggingDocFxRunner<DocFxBuildSettings>
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

        /// <inheritdoc/>
        protected override void GetArguments(ProcessArgumentBuilder builder, FilePath configFile, DocFxBuildSettings settings)
        {
            // command
            builder.Append("build");

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

            if (settings.Serve)
            {
                builder.Append("--serve");
            }
            #endregion

            if (settings.Force)
            {
                builder.Append("--force");
            }

        }

    }
}
