using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.DocFx.Build;
using Cake.DocFx.Helper;
using Cake.DocFx.Metadata;

namespace Cake.DocFx
{
    /// <summary>
    ///     Contains functionality related to <see href="http://dotnet.github.io/docfx/index.html">DocFx</see>
    /// </summary>
    [CakeAliasCategory("DocFx")]
    public static class DocFxAliases
    {
        #region DocFx

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFx(this ICakeContext context)
            => context.DocFx(null, null);

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFx(this ICakeContext context, FilePath configFile)
            => context.DocFx(configFile, null);

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFx(this ICakeContext context, DocFxSettings settings)
            => context.DocFx(null, settings);

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFx(this ICakeContext context, FilePath configFile, DocFxSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxSettings();

            var runner = new DocFxRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Globber);
            runner.Run(configFile, settings);
        }

        #endregion

        #region DocFxBuild

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFxBuild(this ICakeContext context) => context.DocFxBuild(null, null);

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFxBuild(this ICakeContext context, FilePath configFile)
            => context.DocFxBuild(configFile, null);

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFxBuild(this ICakeContext context, DocFxBuildSettings settings)
            => context.DocFxBuild(null, settings);

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFxBuild(this ICakeContext context, FilePath configFile, DocFxBuildSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxBuildSettings();

            var runner = new DocFxBuildRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Globber);
            runner.Run(configFile, settings);
        }

        #endregion

        #region DocFxMetadata

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFxMetadata(this ICakeContext context)
            => context.DocFxMetadata((DocFxMetadataSettings) null);

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFxMetadata(this ICakeContext context, FilePath configFile)
        {
            context.DocFxMetadata(new DocFxMetadataSettings
            {
                Projects = new[] {configFile}
            });
        }

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFxMetadata(this ICakeContext context, IEnumerable<FilePath> files)
        {
            context.DocFxMetadata(new DocFxMetadataSettings
            {
                Projects = files
            });
        }

        [CakeAliasCategory("Documentation")]
        [CakeMethodAlias]
        public static void DocFxMetadata(this ICakeContext context, DocFxMetadataSettings settings)
        {
            Contract.NotNull(context, nameof(context));

            settings = settings ?? new DocFxMetadataSettings();

            var runner = new DocFxMetadataRunner(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Globber);
            runner.Run(settings);
        }

        #endregion
    }
}