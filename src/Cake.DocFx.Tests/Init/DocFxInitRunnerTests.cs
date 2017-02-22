namespace Cake.DocFx.Tests.Init
{
    using Xunit;

    public class DocFxInitRunnerTests
    {
        public sealed class ThePackMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DocFxInitRunnerFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_Mandatory_Arguments()
            {
                // Given
                var fixture = new DocFxInitRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("init -q", result.Args);
            }

            [Fact]
            public void Should_Add_OnlyConfigFile_To_Arguments_If_Not_Null()
            {
                // Given
                var fixture = new DocFxInitRunnerFixture();
                fixture.Settings.OnlyConfigFile = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("init -q -f", result.Args);
            }

            [Fact]
            public void Should_Add_OutputPath_To_Arguments_If_Not_Null()
            {
                // Given
                var fixture = new DocFxInitRunnerFixture();
                fixture.Settings.OutputPath = @"c:\foo bar\";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("init -q -o \"c:/foo bar\"", result.Args);
            }
        }
    }
}
