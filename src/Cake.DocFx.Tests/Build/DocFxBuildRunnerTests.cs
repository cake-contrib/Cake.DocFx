namespace Cake.DocFx.Tests.Build
{
    using Xunit;

    public class DocFxBuildRunnerTests
    {
        public sealed class ThePackMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DocFxBuildRunnerFixture
                {
                    Settings = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_GlobalMetadata_To_Arguments_If_Not_Empty()
            {
                // Given
                var fixture = new DocFxBuildRunnerFixture();
                fixture.Settings.GlobalMetadata.Add("foo", "bar");

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build --globalMetadata \"{\\\"foo\\\": \\\"bar\\\"}\"", result.Args);
            }

            [Fact]
            public void Should_Add_Serve_To_Arguments_If_True()
            {
                // Given
                var fixture = new DocFxBuildRunnerFixture
                {
                    Settings = {Serve = true}
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build --serve", result.Args);
            }
        }
    }
}
