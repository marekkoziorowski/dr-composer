using DrComposer.Core.Composition.Configuration.Common;
using System;

namespace DrComposer.Core.Composition
{
    public interface ICompositionParser
    {
        BaseDockerComposeYml Parse(Type resultType, string compositionText);
    }
}
