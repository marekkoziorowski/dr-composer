using DrComposer.Core.Composition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrComposer.Core.Tests.Composition
{
    [TestClass]
    public class DefaultComposeVersionResolverTests
    {
        [TestMethod]
        public void ResolveCompositionModelType_ReturnsDefaultV1IfCompositionTextIsNull()
        {
            string testValue = null;

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v1.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsDefaultV1IfCompositionTextIsEmpty()
        {
            string testValue = string.Empty;

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v1.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsDefaultV1IfCompositionTextIsWhiteSpace()
        {
            string testValue = "   ";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v1.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsDefaultV1IfCompositionTextHasNoVersionProvided()
        {
            string testValue = $"line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v1.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsDefaultV1IfCompositionTextHasNotSupportedVersionProvided()
        {
            string testValue = $"version: '99.0'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v1.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsV1IfVersion1Provided()
        {
            string testValue = $"version: '{DockerComposeVersions.v1}'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v1.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsV1IfVersion1dot0Provided()
        {
            string testValue = $"version: '{DockerComposeVersions.v1dot0}'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v1.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsV2IfVersion2Provided()
        {
            string testValue = $"version: '{DockerComposeVersions.v2}'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v2.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsV2IfVersion2dot0Provided()
        {
            string testValue = $"version: '{DockerComposeVersions.v2dot0}'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v2.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsV2IfVersion2dot1Provided()
        {
            string testValue = $"version: '{DockerComposeVersions.v2dot1}'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v2.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsV3IfVersion3Provided()
        {
            string testValue = $"version: '{DockerComposeVersions.v3}'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v3.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsV3IfVersion3dot0Provided()
        {
            string testValue = $"version: '{DockerComposeVersions.v3dot0}'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v3.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsV3IfVersion3dot1Provided()
        {
            string testValue = $"version: '{DockerComposeVersions.v3dot1}'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v3.DockerComposeYml));
        }

        [TestMethod]
        public void ResolveCompositionModelType_ReturnsCorrectVersionIfVersionIsNotAtTheFirstLine()
        {
            string testValue = $"description: 'Some description'{Environment.NewLine}version: '{DockerComposeVersions.v3dot1}'{Environment.NewLine}{Environment.NewLine}line1:{Environment.NewLine}  - line2{Environment.NewLine}";

            DefaultComposeVersionResolver toBeTested = new DefaultComposeVersionResolver();
            Type result = toBeTested.ResolveCompositionModelType(testValue);

            Assert.AreEqual(result, typeof(Core.Composition.Configuration.v3.DockerComposeYml));
        }
    }
}
