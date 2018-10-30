using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Helper;
using Cake.DocFx.Merge;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to merging base API files using 
    /// <see href="http://dotnet.github.io/docfx">DocFx</see>.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    [CakeNamespaceImport("Cake.DocFx.Merge")]
    public static class DocFxMergeAliases
    {
        /// <summary>
        /// Merge base API in YAML files and toc files for the <c>docfx.json</c> file in the current working directory.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// DocFxMerge();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Merge")]
        public static void DocFxMerge(this ICakeContext context) => context.DocFxMerge(null, null);

        /// <summary>
        /// Merge base API in YAML files and toc files for a specific <c>docfx.json</c> file.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The optional path to a DocFx config file.
        /// If no value is passed the docfx.json file in the current working directory will be used.</param>
        /// <example>
        /// <code>
        /// DocFxMerge("./docs/docfx.json");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Merge")]
        public static void DocFxMerge(this ICakeContext context, FilePath configFile)
            => context.DocFxMerge(configFile, null);

        /// <summary>
        /// Merge base API in YAML files and toc files for the <c>docfx.json</c> file in the current working
        /// directory using the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The optional DocFx settings. 
        /// If no settings are passed default settings are used.</param>
        /// <example>
        /// <code>
        /// DocFxMerge(new DocFxMergeSettings
        /// {
        ///     TocMetadata = { "platform" },
        ///     WarningsAsErrors = true
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Merge")]
        public static void DocFxMerge(this ICakeContext context, DocFxMergeSettings settings)
            => context.DocFxMerge(null, settings);

        /// <summary>
        /// Merge base API in YAML files and toc files for a specific <c>docfx.json</c> file using the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The optional path to a DocFx config file.
        /// If no value is passed the docfx.json file in the current working directory will be used.</param>
        /// <param name="settings">The optional DocFx settings. 
        /// If no settings are passed default settings are used.</param>
        /// <example>
        /// <code>
        /// DocFxMerge("./docs/docfx.json", new DocFxMergeSettings
        /// {
        ///     TocMetadata = { "platform" },
        ///     WarningsAsErrors = true
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Merge")]
        public static void DocFxMerge(this ICakeContext context, FilePath configFile, DocFxMergeSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxMergeSettings();

            var runner = new DocFxMergeRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(configFile, settings);
        }
    }
}
