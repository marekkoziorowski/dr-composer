using DrComposer.Core.Composition.Configuration;
using DrComposer.Core.Composition.Configuration.Common;
using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DrComposer.Core.Composition
{
    public class DefaultCompositionParser : ICompositionParser
    {
        public BaseDockerComposeYml Parse(Type resultType, string compositionText)
        {
            Deserializer deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .IgnoreUnmatchedProperties()
                .Build();

            BaseDockerComposeYml result = deserializer.Deserialize(compositionText, resultType) as BaseDockerComposeYml;
            return result;
        }
    }
}
