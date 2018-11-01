using Cake.Core.IO;
using Cake.DocFx.Serve;

namespace Cake.DocFx.Tests.Serve
{
    internal sealed class DocFxServeRunnerFixture : DocFxFixture<DocFxServeSettings>
    {
        public DocFxServeRunnerFixture()
        {
        }

        public DirectoryPath Path { get; set; }

        protected override void RunTool()
        {
            var tool = new DocFxServeRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Path, Settings);
        }
    }
}
