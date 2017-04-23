using System;
using System.Collections.Generic;
using System.Linq;

namespace DrComposer.Core.Composition
{
    public class EnvironmentVariableCompositionSourceProvider : ICompositionSourceProvider
    {
        public List<string> GetCompositionSources()
        {
            string compositionSources = Environment.GetEnvironmentVariable(EnvironmentVariableNames.CompositionSources);

            if (string.IsNullOrWhiteSpace(compositionSources))
            {
                return new List<string>();
            }

            return compositionSources
                .Split(new string[] { ",", ";", "|", " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToList();
        }
    }
}
