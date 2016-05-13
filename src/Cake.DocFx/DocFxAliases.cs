using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Helper;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to <see href="http://dotnet.github.io/docfx">DocFx</see>.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    public static class DocFxAliases
    {
        /// <summary>
        /// Builds DocFx API metadata and markdown files.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// DocFx();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
        public static void DocFx(this ICakeContext context)
            => context.DocFx(null, null);

        /// <summary>
        /// Builds markdown and API documentation using DocFx.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        /// <example>
        /// <code>
        /// DocFx("./docs/docfx.json");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
        public static void DocFx(this ICakeContext context, FilePath configFile)
            => context.DocFx(configFile, null);

        /// <summary>
        /// Builds markdown and API documentation using DocFx, with the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The DocFx settings.</param>
        /// <example>
        /// <code>
        /// DocFx(new DocFxSettings()
        /// {
        ///     OutputPath = "./artifacts/docs"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
        public static void DocFx(this ICakeContext context, DocFxSettings settings)
            => context.DocFx(null, settings);

        /// <summary>
        /// Builds markdown and API documentation using DocFx, with the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        /// <param name="settings">The DocFx settings.</param>
        /// <example>
        /// <code>
        /// DocFx("./docs/docfx.json", new DocFxSettings()
        /// {
        ///     OutputPath = "./artifacts/docs"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
        public static void DocFx(this ICakeContext context, FilePath configFile, DocFxSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxSettings();

            var runner = new DocFxRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run(configFile, settings);
        }

        /// <summary>
        /// Builds markdown only using DocFx. This will not build API documentation.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// DocFxBuild();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
        public static void DocFxBuild(this ICakeContext context) => context.DocFxBuild(null, null);

        /// <summary>
        /// Builds markdown only using DocFx. This will not build API documentation.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        /// <example>
        /// <code>
        /// DocFxBuild("./docs/docfx.json");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
        public static void DocFxBuild(this ICakeContext context, FilePath configFile)
            => context.DocFxBuild(configFile, null);

        /// <summary>
        /// Builds markdown only using DocFx, with the specified settings. This will not build API documentation.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The DocFx settings.</param>
        /// <example>
        /// <code>
        /// DocFxBuild(new DocFxBuildSettings()
        /// {
        ///     OutputPath = "./artifacts/docs",
        ///     TemplateFolder = "default"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
        public static void DocFxBuild(this ICakeContext context, DocFxBuildSettings settings)
            => context.DocFxBuild(null, settings);

        /// <summary>
        /// Builds markdown only using DocFx, with the specified settings. This will not build API documentation.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        /// <param name="settings">The DocFx settings.</param>
        /// <example>
        /// <code>
        /// DocFxBuild("./docs/docfx.json", new DocFxBuildSettings()
        /// {
        ///     OutputPath = "./artifacts/docs",
        ///     TemplateFolder = "default"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
        public static void DocFxBuild(this ICakeContext context, FilePath configFile, DocFxBuildSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxBuildSettings();

            var runner = new DocFxBuildRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run(configFile, settings);
        }

        /// <summary>
        /// Extract API documentation using DocFx.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// DocFxMetadata();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
        public static void DocFxMetadata(this ICakeContext context)
            => context.DocFxMetadata((DocFxMetadataSettings) null);

        /// <summary>
        /// Extract API documentation using DocFx.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        /// <example>
        /// <code>
        /// DocFxMetadata("./docs/docfx.json");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Documentation")]
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
        [CakeAliasCategory("Documentation")]
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
        [CakeAliasCategory("Documentation")]
        public static void DocFxMetadata(this ICakeContext context, DocFxMetadataSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxMetadataSettings();

            var runner = new DocFxMetadataRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run(settings);
        }
    }
}