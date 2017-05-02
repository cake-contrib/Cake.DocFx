using Cake.Core;
using Cake.Core.Annotations;
using Cake.DocFx.Helper;
using Cake.DocFx.Init;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to creating new <see href="http://dotnet.github.io/docfx">DocFx</see>
    /// projects.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    [CakeNamespaceImport("Cake.DocFx.Build")]
    public static class DocFxInitAliases
    {
        /// <summary>
        /// Generate an initial <c>docfx.json</c> file.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// DocFxInit();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Init")]
        public static void DocFxInit(this ICakeContext context)
            => context.DocFxInit((DocFxInitSettings)null);

        /// <summary>
        /// Generate an initial <c>docfx.json</c> file, with the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The optional DocFx settings. 
        /// If no settings are passed default settings are used.</param>
        /// <example>
        /// <code>
        /// DocFxInit(new DocFxInitSettings()
        /// {
        ///     OutputPath = "./docs"
        /// });
        /// </code>
        /// </example>
        /// <example>
        /// <code>
        /// DocFxInit(new DocFxInitSettings()
        /// {
        ///     OutputPath = "./docs",
        ///     OnlyConfigFile = true
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Init")]
        public static void DocFxInit(this ICakeContext context, DocFxInitSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxInitSettings();

            var runner = new DocFxInitRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }
    }
}