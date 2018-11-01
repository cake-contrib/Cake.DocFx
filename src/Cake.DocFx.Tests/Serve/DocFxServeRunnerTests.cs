using Xunit;

namespace Cake.DocFx.Tests.Serve
{
    public class DocFxServeRunnerTests
    {
        public sealed class TheRunMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new DocFxServeRunnerFixture
                {
                    Settings = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_Path_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxServeRunnerFixture
                {
                    Path = "./docs"
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve \"docs\"", result.Args);
            }

            [Fact]
            public void Should_Add_Hostname_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxServeRunnerFixture
                {
                    Settings = { Hostname = "192.168.1.4" }
                };

                // When
                var result = fixture.Run();
                
                // Then
                Assert.Equal("serve -n 192.168.1.4", result.Args);
            }

            [Fact]
            public void Should_Add_Port_To_Arguments_If_Set()
            {
                // Given
                var fixture = new DocFxServeRunnerFixture
                {
                    Settings = { Port = "9753" }
                };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("serve -p 9753", result.Args);
            }
        }
    }
}
