using DrComposer.Core.Composition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace DrComposer.Core.Tests.Composition
{
    [TestClass]
    public class DefaultCompositionLoaderTests
    {
        [TestMethod]
        public void LoadCompositions_ReturnsEmptyListIfNoSourceIsProvided()
        {
            var compositionSourceProviderMock = new Mock<ICompositionSourceProvider>();
            var compositionParserMock = new Mock<ICompositionParser>();
            var fileReaderMock = new Mock<IFileReader>();

            compositionSourceProviderMock.Setup(o => o.GetCompositionSources()).Returns(new List<string>());

            DefaultCompositionLoader toBeTested = new DefaultCompositionLoader(compositionSourceProviderMock.Object, compositionParserMock.Object, fileReaderMock.Object);
            List<DrComposer.Core.Composition.Composition> result = toBeTested.LoadCompositions();

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void LoadCompositions_ReturnsListWithItemsExistingOnSpecificPath()
        {
            string testPath1 = @"C:\\path1";
            string testPath2 = @"C:\\path2";

            var compositionSourceProviderMock = new Mock<ICompositionSourceProvider>();
            var compositionParserMock = new Mock<ICompositionParser>();
            var fileReaderMock = new Mock<IFileReader>();

            fileReaderMock.Setup(o => o.Exists(testPath1)).Returns(false);
            fileReaderMock.Setup(o => o.Exists(testPath2)).Returns(true);
            fileReaderMock.Setup(o => o.ReadAllText(It.IsAny<string>())).Returns(string.Empty);

            compositionParserMock.Setup(o => o.Parse(It.IsAny<Type>(), It.IsAny<string>())).Returns(new DrComposer.Core.Composition.Composition());

            compositionSourceProviderMock.Setup(o => o.GetCompositionSources()).Returns(new List<string> { testPath1, testPath2 });


            DefaultCompositionLoader toBeTested = new DefaultCompositionLoader(compositionSourceProviderMock.Object, compositionParserMock.Object, fileReaderMock.Object);
            List<DrComposer.Core.Composition.Composition> result = toBeTested.LoadCompositions();

            Assert.IsTrue(result.Any() && result.Count == 1 && result[0].Source == testPath2);
        }

    }
}
