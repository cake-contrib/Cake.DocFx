using Cake.Core.IO;

namespace Cake.DocFx.Tests.Build
{
    internal sealed class DocFxBuildRunnerFixture : DocFxFixture<DocFxBuildSettings>
    {
        public DocFxBuildRunnerFixture()
        {
        }

        public FilePath ConfigFilePath { get; set; }

        protected override void RunTool()
        {
            var tool = new DocFxBuildRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(ConfigFilePath, Settings);
        }
    }
}
