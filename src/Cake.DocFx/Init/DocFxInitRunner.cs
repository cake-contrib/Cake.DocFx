using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.DocFx.Helper;

namespace Cake.DocFx.Init
{
    /// <summary>
    /// Command line runner for the <c>docfx init</c> command.
    /// </summary>
    internal sealed class DocFxInitRunner : DocFxTool<DocFxInitSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxInitRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public DocFxInitRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) 
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs DocFx generator with the given configuration.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(DocFxInitSettings settings)
        {
            Contract.NotNull(settings, nameof(settings));

            Run(settings, GetArguments(settings));
        }

        private ProcessArgumentBuilder GetArguments(DocFxInitSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // command
            builder.Append("init");
            builder.Append("-q");

            // parameters
            if (settings.OnlyConfigFile)
                builder.Append("-f");

            if (settings.OutputPath != null)
                builder.Append("-o \"{0}\"", settings.OutputPath.FullPath);

            return builder;
        }
    }
}
