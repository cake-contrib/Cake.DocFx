using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Build;
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
        /// Obsolete. Use <see cref="DocFxBuildAliases.DocFxBuild(ICakeContext)"/> instead.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [Obsolete("Use DocFxBuild instead.")]
        public static void DocFx(this ICakeContext context)
            => context.DocFx(null, null);

        /// <summary>
        /// Obsolete. Use <see cref="DocFxBuildAliases.DocFxBuild(ICakeContext, FilePath)"/> instead.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [Obsolete("Use DocFxBuild instead.")]
        public static void DocFx(this ICakeContext context, FilePath configFile)
            => context.DocFx(configFile, null);

        /// <summary>
        /// Obsolete. Use <see cref="DocFxBuildAliases.DocFxBuild(ICakeContext, DocFxBuildSettings)"/> instead.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The DocFx settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [Obsolete("Use DocFxBuild instead.")]
        public static void DocFx(this ICakeContext context, DocFxSettings settings)
            => context.DocFx(null, settings);

        /// <summary>
        /// Obsolete. Use <see cref="DocFxBuildAliases.DocFxBuild(ICakeContext, FilePath, DocFxBuildSettings)"/> instead.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="configFile">The path to the docfx.json config file.</param>
        /// <param name="settings">The DocFx settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [Obsolete("Use DocFxBuild instead.")]
        public static void DocFx(this ICakeContext context, FilePath configFile, DocFxSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxSettings();

            context.DocFxBuild(
                configFile, 
                new DocFxBuildSettings
                {
                    OutputPath = settings.OutputPath
                });
        }
    }
}