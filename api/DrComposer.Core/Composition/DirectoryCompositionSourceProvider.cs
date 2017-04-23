using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DrComposer.Core.Composition
{
    public class DirectoryCompositionSourceProvider : ICompositionSourceProvider
    {
        public List<string> GetCompositionSources()
        {
            string compositionSourceDirectory = Environment.GetEnvironmentVariable(EnvironmentVariableNames.CompositionSourceDirectory);

            if (string.IsNullOrWhiteSpace(compositionSourceDirectory))
            {
                compositionSourceDirectory = "/compositions";
            }

            return Directory.GetFiles(compositionSourceDirectory, "*.yml", SearchOption.AllDirectories).ToList();
        }
    }
}
