using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DocFx
{
    /// <summary>
    /// Base class for docfx tools
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public abstract class DocFxTool<TSettings> : Tool<TSettings> where TSettings : ToolSettings
    {
        protected DocFxTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) 
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>
        /// The name of the tool.
        /// </returns>
        protected override string GetToolName() => "DocFx";

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>
        /// The tool executable name.
        /// </returns>
        protected override IEnumerable<string> GetToolExecutableNames() => new[] {"docfx", "docfx.exe"};
    }
}
