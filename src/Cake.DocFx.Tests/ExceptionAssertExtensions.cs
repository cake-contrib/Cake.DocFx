using System;
using Xunit;

namespace Cake.DocFx.Tests
{
    public static class ExceptionAssertExtensions
    {
        public static void IsArgumentNullException(this Exception exception, string parameterName)
        {
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal(parameterName, ((ArgumentNullException)exception).ParamName);
        }
    }
}
