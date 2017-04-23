using System.Collections.Generic;
using System.IO;

namespace DrComposer.Core.Composition
{
    public interface ICompositionSourceProvider
    {
        List<string> GetCompositionSources();
    }
}
