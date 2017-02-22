namespace Cake.DocFx.Tests.Init
{
    internal sealed class DocFxInitRunnerFixture : DocFxFixture<DocFxInitSettings>
    {
        public DocFxInitRunnerFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new DocFxInitRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}
