using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Helper;
using Cake.DocFx.Build;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to <see href="http://dotnet.github.io/docfx">DocFx</see>.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    [CakeNamespaceImport("Cake.DocFx.Build")]
    public static class DocFxBuildAliases
    {
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
        [CakeAliasCategory("Build")]
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
        [CakeAliasCategory("Build")]
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
        [CakeAliasCategory("Build")]
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
        [CakeAliasCategory("Build")]
        public static void DocFxBuild(this ICakeContext context, FilePath configFile, DocFxBuildSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxBuildSettings();

            var runner = new DocFxBuildRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(configFile, settings);
        }
    }
}