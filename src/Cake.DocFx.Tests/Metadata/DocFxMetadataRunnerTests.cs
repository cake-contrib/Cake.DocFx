using Cake.Core.IO;
using System.Collections.Generic;
using Xunit;

namespace Cake.DocFx.Tests.Metadata
{
    public class DocFxMetadataRunnerTests
    {
        public sealed class TheRunMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DocFxMetadataRunnerFixture
                {
                    Settings = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_Project_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxMetadataRunnerFixture
                {
                    Settings = { Projects = new List<FilePath> { @"c:\temp\docfx.json" }  }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("metadata \"c:/temp/docfx.json\"", result.Args);
            }

            [Fact]
            public void Should_Add_Project_With_Space_In_Path_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxMetadataRunnerFixture
                {
                    Settings = { Projects = new List<FilePath> { @"c:\foo bar\docfx.json" } }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("metadata \"c:/foo bar/docfx.json\"", result.Args);
            }

            [Fact]
            public void Should_Add_Multiple_Projects_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxMetadataRunnerFixture
                {
                    Settings =
                    {
                        Projects = new List<FilePath>
                        {
                            @"c:\temp\foo.csproj",
                            @"c:\temp\bar.csproj"
                        }
                    }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("metadata \"c:/temp/foo.csproj\",\"c:/temp/bar.csproj\"", result.Args);
            }

            [Fact]
            public void Should_Add_OutputPath_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxMetadataRunnerFixture
                {
                    Settings = { OutputPath = @"c:\temp\api" }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("metadata -o \"c:/temp/api\"", result.Args);
            }

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

            [Fact]
            public void Should_Add_Force_To_Arguments_If_True()
            {
                // Given
                var fixture = new DocFxMetadataRunnerFixture
                {
                    Settings = {Force = true}
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("metadata --force", result.Args);
            }
        }
    }
}
