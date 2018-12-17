using Cake.Core.IO;
using Cake.DocFx.Metadata;

namespace Cake.DocFx.Tests.Metadata
{
    internal sealed class DocFxMetadataRunnerFixture : DocFxFixture<DocFxMetadataSettings>
    {
        public DocFxMetadataRunnerFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new DocFxMetadataRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(null, Settings);
        }
    }
}
