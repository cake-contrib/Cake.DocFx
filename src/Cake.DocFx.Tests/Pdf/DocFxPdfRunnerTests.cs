using Xunit;

namespace Cake.DocFx.Tests.Pdf
{
    public class DocFxPdfRunnerTests
    {
        public sealed class TheRunMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DocFxPdfRunnerFixture
                {
                    Settings = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }


            [Fact]
            public void Should_Be_Pdf_Command()
            {
                // Given
                var fixture = new DocFxPdfRunnerFixture
                {
                    Settings = {}
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("pdf", result.Args);
            }

            [Fact]
            public void Should_Add_LogPath_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxPdfRunnerFixture
                {
                    Settings = { LogPath = @"c:\temp\docfx.log" }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("pdf -l \"c:/temp/docfx.log\"", result.Args);
            }

            [Theory]
            [InlineData(DocFxLogLevel.Error, "Error")]
            [InlineData(DocFxLogLevel.Warning, "Warning")]
            [InlineData(DocFxLogLevel.Info, "Info")]
            [InlineData(DocFxLogLevel.Verbose, "Verbose")]
            public void Should_Add_LogLevel_To_Arguments_If_Set(DocFxLogLevel logLevel, string expectedLevel)
            {
                // Given
                var fixture = new DocFxPdfRunnerFixture
                {
                    Settings = { LogLevel = logLevel }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("pdf --logLevel \"" + expectedLevel + "\"", result.Args);
            }

            [Fact]
            public void Should_Not_Add_LogLevel_To_Arguments_If_Default()
            {
                // Given
                var fixture = new DocFxPdfRunnerFixture
                {
                    Settings = { LogLevel = DocFxLogLevel.Default }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("pdf", result.Args);
            }

            [Fact]
            public void Should_Add_GlobalMetadata_To_Arguments_If_Not_Empty()
            {
                // Given
                var fixture = new DocFxPdfRunnerFixture();
                fixture.Settings.GlobalMetadata.Add("foo", "bar");

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("pdf --globalMetadata \"{\\\"foo\\\": \\\"bar\\\"}\"", result.Args);
            }

            [Fact]
            public void Should_Add_Name_To_Arguments_If_Not_Empty()
            {
                // Given
                var fixture = new DocFxPdfRunnerFixture();
                fixture.Settings.Name = "foo";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("pdf --name \"foo\"", result.Args);
            }
        }
    }
}
