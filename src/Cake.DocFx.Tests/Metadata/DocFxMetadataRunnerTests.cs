using Xunit;

namespace Cake.DocFx.Tests.Metadata
{
    public class DocFxMetadataRunnerTests
    {
        public sealed class TheRunMethod
        {
            [Fact]
            public void Should_Add_LogPath_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxMetadataRunnerFixture
                {
                    Settings = { LogPath = @"c:\temp\docfx.log" }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("metadata -l \"c:/temp/docfx.log\"", result.Args);
            }

            [Theory]
            [InlineData(DocFxLogLevel.Error, "Error")]
            [InlineData(DocFxLogLevel.Warning, "Warning")]
            [InlineData(DocFxLogLevel.Info, "Info")]
            [InlineData(DocFxLogLevel.Verbose, "Verbose")]
            public void Should_Add_LogLevel_To_Arguments_If_Set(DocFxLogLevel logLevel, string expectedLevel)
            {
                // Given
                var fixture = new DocFxMetadataRunnerFixture
                {
                    Settings = { LogLevel = logLevel }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("metadata --logLevel \"" + expectedLevel + "\"", result.Args);
            }

            [Fact]
            public void Should_Not_Add_LogLevel_To_Arguments_If_Default()
            {
                // Given
                var fixture = new DocFxMetadataRunnerFixture
                {
                    Settings = { LogLevel = DocFxLogLevel.Default }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("metadata", result.Args);
            }
        }
    }
}
