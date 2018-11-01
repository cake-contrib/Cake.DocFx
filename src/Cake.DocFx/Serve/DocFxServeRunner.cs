using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.DocFx.Helper;

namespace Cake.DocFx.Serve
{
    /// <summary>
    /// Command line runner for the <c>docfx serve</c> command.
    /// </summary>
    internal sealed class DocFxServeRunner : DocFxTool<DocFxServeSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocFxServeRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        public DocFxServeRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs DocFx for the specified directory.
        /// </summary>
        /// <param name="path">The directory to serve.</param>
        /// <param name="settings">The settings.</param>
        public void Run(DirectoryPath path, DocFxServeSettings settings)
        {
            Contract.NotNull(settings, nameof(settings));

            Run(settings, GetArguments(path, settings));
        }

        /// <summary>
        /// Runs DocFx for the specified directory.
        /// </summary>
        /// <param name="path">The optional path to the directory to serve.
        /// If no value is passed the the current working directory will be used.</param>
        /// <param name="settings">The settings.</param>
        public IProcess RunProcess(DirectoryPath path, DocFxServeSettings settings)
        {
            Contract.NotNull(settings, nameof(settings));

            return RunProcess(settings, GetArguments(path, settings));
        }

        private ProcessArgumentBuilder GetArguments(DirectoryPath path, DocFxServeSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // command
            builder.Append("serve");

            // parameters
            if (path != null)
                builder.Append("\"{0}\"", path.FullPath);

            if (!string.IsNullOrWhiteSpace(settings.Hostname))
                builder.Append("-n {0}", settings.Hostname);

            if (!string.IsNullOrWhiteSpace(settings.Port))
                builder.Append("-p {0}", settings.Port);

            return builder;
        }
    }
}
