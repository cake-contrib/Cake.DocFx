using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.DocFx.Helper;

namespace Cake.DocFx
{
    /// <summary>
    /// Base class for all runners supporting logging.
    /// </summary>
    /// <typeparam name="T">Type of the runner settings.</typeparam>
    internal abstract class BaseLoggingDocFxRunner<T> : DocFxTool<T> where T : ToolSettings
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BaseLoggingDocFxRunner{T}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        public BaseLoggingDocFxRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs DocFx for the current folder with the given configuration.
        /// </summary>
        /// <param name="path">The optional path to the docfx.json config file.</param>
        /// <param name="settings">The settings.</param>
        public void Run(FilePath path, T settings)
        {
            Contract.NotNull(settings, nameof(settings));

            Run(settings, GetBaseArguments(path, settings));
        }

        /// <summary>
        /// Returns the arguments of the concrete runner.
        /// </summary>
        /// <param name="builder">Argument builder instance.</param>
        /// <param name="configFile">The optional path to the docfx.json config file.</param>
        /// <param name="settings">The settings.</param>
        protected abstract void GetArguments(ProcessArgumentBuilder builder, FilePath configFile, T settings);

        private ProcessArgumentBuilder GetBaseArguments(FilePath configFile, T settings)
        {
            var builder = new ProcessArgumentBuilder();

            GetArguments(builder, configFile, settings);

            var logSettings = settings as BaseDocFxLogSettings;
            if (logSettings != null)
            {
                if (logSettings.LogPath != null)
                    builder.Append("-l \"{0}\"", logSettings.LogPath.FullPath);

                if (logSettings.LogLevel != DocFxLogLevel.Default)
                    builder.Append("--logLevel \"{0}\"", logSettings.LogLevel);

                if (logSettings.RepositoryRoot != null)
                    builder.Append("--repositoryRoot \"{0}\"", logSettings.RepositoryRoot.FullPath);

                if (!string.IsNullOrWhiteSpace(logSettings.CorrelationId))
                    builder.Append("--correlationId {0}", logSettings.CorrelationId);

                if (logSettings.WarningsAsErrors)
                    builder.Append("--warningsAsErrors");
            }

            return builder;
        }
    }
}
