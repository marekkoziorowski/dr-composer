using System;

namespace DrComposer.Core.Composition
{
    public interface IComposeVersionResolver
    {
        Type ResolveCompositionModelType(string content);
    }
}
