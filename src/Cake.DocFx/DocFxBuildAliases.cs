using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Helper;
using Cake.DocFx.Build;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to building websites using 
    /// <see href="http://dotnet.github.io/docfx">DocFx</see>.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    [CakeNamespaceImport("Cake.DocFx.Build")]
    public static class DocFxBuildAliases
    {
        /// <summary>
        /// Generate client-only website combining API in YAML files and conceptual files
        /// for the <c>docfx.json</c> file in the current working directory.
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
        /// Generate client-only website combining API in YAML files and conceptual files
        /// for a specific <c>docfx.json</c> file.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The optional path to a DocFx config file.
        /// If no value is passed the docfx.json file in the current working directory will be used.</param>
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
        /// Generate client-only website combining API in YAML files and conceptual files 
        /// for the <c>docfx.json</c> file in the current working directory using the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The optional DocFx settings. 
        /// If no settings are passed default settings are used.</param>
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
        /// Generate client-only website combining API in YAML files and conceptual files
        /// for a specific <c>docfx.json</c> file using the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The optional path to a DocFx config file.
        /// If no value is passed the docfx.json file in the current working directory will be used.</param>
        /// <param name="settings">The optional DocFx settings. 
        /// If no settings are passed default settings are used.</param>
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