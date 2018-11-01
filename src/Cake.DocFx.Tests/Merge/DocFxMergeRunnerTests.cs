using System;
using Xunit;

namespace Cake.DocFx.Tests.Merge
{
    public sealed class DocFxMergeRunnerTests
    {
        public sealed class TheRunMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DocFxMergeRunnerFixture
                {
                    Settings = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_ConfigFilePath_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxMergeRunnerFixture
                {
                    ConfigFilePath = @"c:\temp\docfx.json"
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("merge \"c:/temp/docfx.json\"", result.Args);
            }

            [Fact]
            public void Should_Add_CorrelationId_To_Arguments_If_Set()
            {
                // Given
                var correlationId = Guid.NewGuid().ToString();
                var fixture = new DocFxMergeRunnerFixture
                {
                    Settings = { CorrelationId = correlationId }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal($"merge --correlationId {correlationId}", result.Args);
            }

            [Fact]
            public void Should_Add_GlobalMetadata_To_Arguments_If_Not_Empty()
            {
                // Given
                var fixture = new DocFxMergeRunnerFixture
                {
                    Settings = { GlobalMetadata = { ["foo"] = "bar" } }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("merge --globalMetadata \"{\\\"foo\\\": \\\"bar\\\"}\"", result.Args);
            }

            [Fact]
            public void Should_Add_LogPath_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxMergeRunnerFixture
                {
                    Settings = { LogPath = @"c:\temp\docfx.log" }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("merge -l \"c:/temp/docfx.log\"", result.Args);
            }

            [Theory]
            [InlineData(DocFxLogLevel.Error, "Error")]
            [InlineData(DocFxLogLevel.Warning, "Warning")]
            [InlineData(DocFxLogLevel.Info, "Info")]
            [InlineData(DocFxLogLevel.Verbose, "Verbose")]
            public void Should_Add_LogLevel_To_Arguments_If_Set(DocFxLogLevel logLevel, string expectedLevel)
            {
                // Given
                var fixture = new DocFxMergeRunnerFixture
                {
                    Settings = { LogLevel = logLevel }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("merge --logLevel \"" + expectedLevel + "\"", result.Args);
            }

            [Fact]
            public void Should_Not_Add_LogLevel_To_Arguments_If_Default()
            {
                // Given
                var fixture = new DocFxMergeRunnerFixture
                {
                    Settings = { LogLevel = DocFxLogLevel.Default }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("merge", result.Args);
            }

            [Fact]
            public void Should_Add_RepositoryRoot_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxMergeRunnerFixture
                {
                    Settings = { RepositoryRoot = @"c:\temp\repo" }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("merge --repositoryRoot \"c:/temp/repo\"", result.Args);
            }

            [Fact]
            public void Should_Add_TocMetadata_To_Arguments_If_Any()
            {
                // Given
                var fixture = new DocFxMergeRunnerFixture
                {
                    Settings = { TocMetadata = { "platform", "version" } }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("merge --tocMetadata \"platform,version\"", result.Args);
            }

            [Fact]
            public void Should_Add_WarningsAsErrors_To_Arguments_If_True()
            {
                // Given
                var fixture = new DocFxMergeRunnerFixture
                {
                    Settings = { WarningsAsErrors = true }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("merge --warningsAsErrors", result.Args);
            }
        }
    }
}
