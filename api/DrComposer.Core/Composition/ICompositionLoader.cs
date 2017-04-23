using System.Collections.Generic;

namespace DrComposer.Core.Composition
{
    public interface ICompositionLoader
    {
        List<Composition> LoadCompositions();
    }
}
