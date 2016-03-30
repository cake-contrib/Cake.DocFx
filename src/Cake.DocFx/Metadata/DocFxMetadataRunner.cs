using System.Linq;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.DocFx.Metadata
{
    /// <summary>
    /// Commandline runner for docfx metadata
    /// </summary>
    public sealed class DocFxMetadataRunner : DocFxTool<DocFxMetadataSettings>
    {
        public DocFxMetadataRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) 
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Runs docfx for current folder with the given configuration.
        /// </summary>
        /// <param name="settings"></param>
        public void Run(DocFxMetadataSettings settings)
        {
            Run(settings, GetArguments(settings));
        }

        private ProcessArgumentBuilder GetArguments(DocFxMetadataSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // command
            builder.Append("metadata");

            // parameters
            if (settings.Projects != null && settings.Projects.Any())
                builder.Append(string.Join(",", settings.Projects.Select(val => val.FullPath)));

            if (settings.OutputPath != null)
                builder.Append("-o \"{0}\"", settings.OutputPath.FullPath);

            return builder;
        }
    }
}
