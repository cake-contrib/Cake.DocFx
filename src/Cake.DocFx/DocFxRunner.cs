using Cake.Core;
using Cake.Core.IO;
using Cake.DocFx.Helper;

namespace Cake.DocFx
{
    /// <summary>
    /// Command line runner for the 'docfx' command.
    /// </summary>
    public class DocFxRunner : DocFxTool<DocFxSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        public DocFxRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) 
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Runs DocFx for the current folder with the given configuration.
        /// </summary>
        /// <param name="path">Optional path to config</param>
        /// <param name="settings"></param>
        public void Run(FilePath path, DocFxSettings settings)
        {
            Contract.NotNull(settings, nameof(settings));

            Run(settings, GetArguments(path, settings));
        }
        
        private ProcessArgumentBuilder GetArguments(FilePath configFile, DocFxSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // parameters
            if (configFile != null)
                builder.Append("\"{0}\"", configFile.FullPath);

            if (settings.OutputPath != null)
                builder.Append("-o \"{0}\"", settings.OutputPath.FullPath);

            return builder;
        }
    }
}
