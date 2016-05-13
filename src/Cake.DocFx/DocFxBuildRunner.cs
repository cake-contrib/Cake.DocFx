using Cake.Core;
using Cake.Core.IO;
using Cake.DocFx.Helper;

namespace Cake.DocFx
{
    /// <summary>
    /// Command line runner for the 'docfx build' command.
    /// </summary>
    public sealed class DocFxBuildRunner : DocFxTool<DocFxBuildSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxBuildRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        public DocFxBuildRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) 
            : base(fileSystem, environment, processRunner, globber)
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
            if (configFile != null)
                builder.Append("\"{0}\"", configFile.FullPath);

            if (settings.OutputPath != null)
                builder.Append("-o \"{0}\"", settings.OutputPath.FullPath);

            if (settings.TemplateFolder != null)
                builder.Append("-t \"{0}\"", settings.TemplateFolder.FullPath);

            return builder;
        }
    }
}
