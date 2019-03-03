using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Helper;
using Cake.DocFx.Metadata;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to extracting API metadata using
    /// <see href="http://dotnet.github.io/docfx">DocFx</see>.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    [CakeNamespaceImport("Cake.DocFx.Metadata")]
    public static class DocFxMetadataAliases
    {
        /// <summary>
        /// Extract API documentation using DocFx for the <c>docfx.json</c> file 
        /// in the current working directory.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// DocFxMetadata();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Metadata")]
        public static void DocFxMetadata(this ICakeContext context)
            => context.DocFxMetadata((DocFxMetadataSettings) null);

        /// <summary>
        /// Extract API documentation using DocFx for a specific <c>docfx.json</c> file.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        /// <example>
        /// <code>
        /// DocFxMetadata("./docs/docfx.json");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Metadata")]
        public static void DocFxMetadata(this ICakeContext context, FilePath configFile)
        {
            context.DocFxMetadata(new DocFxMetadataSettings
            {
                Projects = new[] {configFile}
            });
        }

        /// <summary>
        /// Extract API documentation using DocFx, with the specified project/source files or search patterns.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="files">The project or source files, or search patterns.</param>
        /// <example>
        /// <code>
        /// var files = GetFiles("./src/**/*.csproj");
        /// DocFxMetadata(files);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Metadata")]
        public static void DocFxMetadata(this ICakeContext context, IEnumerable<FilePath> files)
        {
            context.DocFxMetadata(new DocFxMetadataSettings
            {
                Projects = files
            });
        }

        /// <summary>
        /// Extract API documentation using DocFx, with the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The DocFx settings.</param>
        /// <example>
        /// <code>
        /// DocFxMetadata(new DocFxMetadataSettings()
        /// {
        ///     OutputPath = "./artifacts/docs"
        /// });
        /// </code>
        /// </example>
        /// <example>
        /// <code>
        /// DocFxMetadata(new DocFxMetadataSettings()
        /// {
        ///     OutputPath = "./artifacts/docs",
        ///     Projects = GetFiles("./src/**/*.csproj")
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Metadata")]
        public static void DocFxMetadata(this ICakeContext context, DocFxMetadataSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxMetadataSettings();

            var runner = new DocFxMetadataRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(null, settings);
        }
    }
}