using Cake.Core;
using Cake.Core.Annotations;
using Cake.DocFx.Helper;
using Cake.DocFx.Init;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to <see href="http://dotnet.github.io/docfx">DocFx</see>.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    [CakeNamespaceImport("Cake.DocFx.Build")]
    public static class DocFxInitAliases
    {
        /// <summary>
        /// Generate an initial <code>docfx.json</code> file.
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
        /// Generate an initial <code>docfx.json</code> file, with the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The DocFx settings.</param>
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