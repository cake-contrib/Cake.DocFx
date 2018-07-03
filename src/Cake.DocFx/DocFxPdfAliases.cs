using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Helper;
using Cake.DocFx.Pdf;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to creating PDF files using <see href="http://dotnet.github.io/docfx">DocFx</see>.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    [CakeNamespaceImport("Cake.DocFx.Pdf")]
    public static class DocFxPdfAliases
    {
        /// <summary>
        /// Generates a PDF document for the <c>docfx.json</c> file in the current working directory.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// DocFxPdf();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pdf")]
        public static void DocFxPdf(this ICakeContext context)
            => context.DocFxPdf(null, null);

        /// <summary>
        /// Generates a PDF document for a specific <c>docfx.json</c> file.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The optional path to a DocFx config file.
        /// If no value is passed the docfx.json file in the current working directory will be used.</param>
        /// <example>
        /// <code>
        /// DocFxPdf("./docs/docfx.json");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pdf")]
        public static void DocFxPdf(this ICakeContext context, FilePath configFile)
            => context.DocFxPdf(configFile, null);

        /// <summary>
        /// Generates a PDF document for the <c>docfx.json</c> file in the current working directory
        /// using the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The optional DocFx settings. 
        /// If no settings are passed default settings are used.</param>
        /// <example>
        /// <code>
        /// DocFxPdf(new DocFxPdfSettings()
        /// {
        ///     OutputPath = "./artifacts/docs",
        ///     TemplateFolder = "default"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pdf")]
        public static void DocFxPdf(this ICakeContext context, DocFxPdfSettings settings)
            => context.DocFxPdf(null, settings);

        /// <summary>
        /// Generates a PDF document for a specific <c>docfx.json</c> file using the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The optional path to a DocFx config file.
        /// If no value is passed the docfx.json file in the current working directory will be used.</param>
        /// <param name="settings">The optional DocFx settings. 
        /// If no settings are passed default settings are used.</param>
        /// <example>
        /// <code>
        /// DocFxPdf("./docs/docfx.json", new DocFxPdfSettings()
        /// {
        ///     OutputPath = "./artifacts/docs",
        ///     TemplateFolder = "default"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pdf")]
        public static void DocFxPdf(this ICakeContext context, FilePath configFile, DocFxPdfSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxPdfSettings();

            var runner = new DocFxPdfRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(configFile, settings);
        }
    }
}