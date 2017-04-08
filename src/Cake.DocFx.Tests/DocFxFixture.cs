namespace Cake.DocFx.Tests
{
    using Core.IO;
    using Core.Tooling;
    using Testing.Fixtures;

    internal abstract class DocFxFixture<TSettings> : DocFxFixture<TSettings, ToolFixtureResult>
        where TSettings : ToolSettings, new()
    {
        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
    }

    internal abstract class DocFxFixture<TSettings, TFixtureResult> : ToolFixture<TSettings, TFixtureResult>
        where TSettings : ToolSettings, new()
        where TFixtureResult : ToolFixtureResult
    {
        protected DocFxFixture()
            : base("docfx.exe")
        {
        }
    }
}
