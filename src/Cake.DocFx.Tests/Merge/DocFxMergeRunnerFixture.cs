using Cake.Core.IO;
using Cake.DocFx.Merge;

namespace Cake.DocFx.Tests.Merge
{
    internal sealed class DocFxMergeRunnerFixture : DocFxFixture<DocFxMergeSettings>
    {
        public DocFxMergeRunnerFixture()
        {
        }

        public FilePath ConfigFilePath { get; set; }

        protected override void RunTool()
        {
            var tool = new DocFxMergeRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(ConfigFilePath, Settings);
        }
    }
}
