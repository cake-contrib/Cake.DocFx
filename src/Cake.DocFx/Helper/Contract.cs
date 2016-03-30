using System;

namespace Cake.DocFx.Helper
{
    internal static class Contract
    {
        /// <summary>
        /// Checks if param is not null and otherwise throws exception.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="paramName"></param>
        internal static void NotNull(object parameter, string paramName)
        {
            if(parameter == null)
                throw new ArgumentNullException(paramName);
        }
    }
}
