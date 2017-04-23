using DrComposer.Core.Composition.Configuration.Common;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DrComposer.Core.Composition
{
    public class DefaultComposeVersionResolver : IComposeVersionResolver
    {
        public Type ResolveCompositionModelType(string compositionText)
        {
            if (string.IsNullOrWhiteSpace(compositionText))
            {
                return typeof(Configuration.v1.DockerComposeYml);
            }

            Deserializer deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .IgnoreUnmatchedProperties()
                .Build();

            BaseDockerComposeYml src = deserializer.Deserialize<BaseDockerComposeYml>(compositionText);

            if (string.IsNullOrWhiteSpace(src.Version))
            {
                return typeof(Configuration.v1.DockerComposeYml);
            }

            Dictionary<string, Type> versions = new Dictionary<string, Type>();
            versions.Add(DockerComposeVersions.v1, typeof(Configuration.v1.DockerComposeYml));
            versions.Add(DockerComposeVersions.v1dot0, typeof(Configuration.v1.DockerComposeYml));
            versions.Add(DockerComposeVersions.v2, typeof(Configuration.v2.DockerComposeYml));
            versions.Add(DockerComposeVersions.v2dot0, typeof(Configuration.v2.DockerComposeYml));
            versions.Add(DockerComposeVersions.v2dot1, typeof(Configuration.v2.DockerComposeYml));
            versions.Add(DockerComposeVersions.v3, typeof(Configuration.v3.DockerComposeYml));
            versions.Add(DockerComposeVersions.v3dot0, typeof(Configuration.v3.DockerComposeYml));
            versions.Add(DockerComposeVersions.v3dot1, typeof(Configuration.v3.DockerComposeYml));


            if (!versions.ContainsKey(src.Version))
            {
                return typeof(Configuration.v1.DockerComposeYml);
            }

            return versions[src.Version];
        }
    }
}
