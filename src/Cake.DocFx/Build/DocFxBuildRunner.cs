using Cake.Core;
using Cake.Core.IO;
using Cake.DocFx.Helper;

namespace Cake.DocFx.Build
{
    /// <summary>
    /// Commandline Runner for docfx build
    /// </summary>
    public sealed class DocFxBuildRunner : DocFxTool<DocFxBuildSettings>
    {
        public DocFxBuildRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) 
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Runs docfx for current folder with the given configuration.
        /// </summary>
        /// <param name="path">Optional path to config</param>
        /// <param name="settings"></param>
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
