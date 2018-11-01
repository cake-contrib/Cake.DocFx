using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Helper;
using Cake.DocFx.Serve;

namespace Cake.DocFx
{
    /// <summary>
    /// Contains functionality related to serving websites using 
    /// <see href="http://dotnet.github.io/docfx">DocFx</see>.
    /// </summary>
    [CakeAliasCategory("DocFx")]
    [CakeNamespaceImport("Cake.DocFx.Serve")]
    public static class DocFxServeAliases
    {
        /// <summary>
        /// Serve a website from the current directory.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// DocFxServe();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Serve")]
        public static void DocFxServe(this ICakeContext context) => context.DocFxServe(null, null);

        /// <summary>
        /// Serve a website from the specified directory.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="path">The optional directory to serve.
        /// If no value is passed the the current working directory will be used.</param>
        /// <example>
        /// <code>
        /// DocFxServe("./docs");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Serve")]
        public static void DocFxServe(this ICakeContext context, DirectoryPath path)
            => context.DocFxServe(path, null);

        /// <summary>
        /// Serve a website from the specified directory with the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="path">The optional directory to serve.
        /// If no value is passed the the current working directory will be used.</param>
        /// <param name="settings">The optional DocFx settings. 
        /// If no settings are passed default settings are used.</param>
        /// <example>
        /// <code>
        /// DocFxServe("./docs", new DocFxServeSettings
        /// {
        ///     Hostname = "192.168.1.4",
        ///     Port = "9753"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Serve")]
        public static void DocFxServe(this ICakeContext context, DirectoryPath path, DocFxServeSettings settings)
        {
            Contract.NotNull(context, nameof(context));
            
            CreateRunner(context).Run(path, settings ?? new DocFxServeSettings());
        }

        /// <summary>
        /// Start serving a website from the current directory.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <example>
        /// <code>
        /// using (var process = DocFxServeStart("./docs")) 
        /// {
        ///     // Launch browser or other action based on the site
        ///     process.WaitForExit();
        /// }
        /// </code>
        /// </example>
        /// <returns>The process serving the website.</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("Serve")]
        public static IProcess DocFxServeStart(this ICakeContext context) => context.DocFxServeStart(null, null);

        /// <summary>
        /// Start serving a website from the specified directory.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="path">The optional directory to serve.
        /// If no value is passed the the current working directory will be used.</param>
        /// <example>
        /// <code>
        /// using (var process = DocFxServeStart("./docs"))
        /// {
        ///     // Launch browser or other action based on the site
        ///     process.WaitForExit();
        /// }
        /// </code>
        /// </example>
        /// <returns>The process serving the website.</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("Serve")]
        public static IProcess DocFxServeStart(this ICakeContext context, DirectoryPath path)
            => context.DocFxServeStart(path, null);

        /// <summary>
        /// Start serving a website from the specified directory with the specified settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="path">The optional directory to serve.
        /// If no value is passed the the current working directory will be used.</param>
        /// <param name="settings">The optional DocFx settings. 
        /// If no settings are passed default settings are used.</param>
        /// <example>
        /// <code>
        /// using (var process = DocFxServeStart("./docs", new DocFxServeSettings
        /// {
        ///     Hostname = "192.168.1.4",
        ///     Port = "9753"
        /// })) 
        /// {
        ///     // Launch browser or other action based on the site
        ///     process.WaitForExit();
        /// }
        /// </code>
        /// </example>
        /// <returns>The process serving the website.</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("Serve")]
        public static IProcess DocFxServeStart(this ICakeContext context, DirectoryPath path, DocFxServeSettings settings)
        {
            Contract.NotNull(context, nameof(context));
            
            return CreateRunner(context).RunProcess(path, settings ?? new DocFxServeSettings());
        }

        private static DocFxServeRunner CreateRunner(ICakeContext context) =>
            new DocFxServeRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
    }
}
