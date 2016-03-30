using Cake.Core;
using Cake.Core.IO;
using Cake.Core.IO.Arguments;
using Cake.DocFx.Helper;

namespace Cake.DocFx
{
    /// <summary>
    /// Commandline runner for docfx
    /// </summary>
    public class DocFxRunner : DocFxTool<DocFxSettings>
    {
        public DocFxRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) 
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Runs docfx for current folder with the given configuration.
        /// </summary>
        /// <param name="path">Optional path to config</param>
        /// <param name="settings"></param>
        public void Run(FilePath path, DocFxSettings settings)
        {
            Contract.NotNull(settings, nameof(settings));

            Run(settings, GetArguments(path, settings));
        }

        // ReSharper disable once UnusedParameter.Local
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
