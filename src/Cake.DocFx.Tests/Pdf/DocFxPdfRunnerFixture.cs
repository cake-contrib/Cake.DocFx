using Cake.Core.IO;
using Cake.DocFx.Pdf;

namespace Cake.DocFx.Tests.Pdf
{
    internal sealed class DocFxPdfRunnerFixture : DocFxFixture<DocFxPdfSettings>
    {
        public DocFxPdfRunnerFixture()
        {
        }

        public FilePath ConfigFilePath { get; set; }

        protected override void RunTool()
        {
            var tool = new DocFxPdfRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(ConfigFilePath, Settings);
        }
    }
}
