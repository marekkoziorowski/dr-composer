using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrComposer.Core.Composition;
using System.Collections.Generic;
using System.Linq;

namespace DrComposer.Core.Tests
{
    [TestClass]
    public class EnvironmentVariableCompositionSourceProviderTests
    {
        [TestMethod]
        public void GetCompositionSources_ReturnsEmptyListWhenVariableIsNotSet()
        {
            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetCompositionSources_ReturnsEmptyListWhenVariableIsNull()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, null);

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetCompositionSources_ReturnsEmptyListWhenVariableIsEmpty()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, String.Empty);

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetCompositionSources_ReturnsEmptyListWhenVariableIsWhiteSpace()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, "   ");

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetCompositionSources_ReturnsNotEmptyListWhenVariableIsSet()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, "TEST_VALUE");

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCompositionSources_SplitsVariableByComma()
        {
            string testValue = "a,b,c";
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, testValue);

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void GetCompositionSources_SplitsVariableBySemicolon()
        {
            string testValue = "a;b;c";
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, testValue);

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void GetCompositionSources_SplitsVariableByPipe()
        {
            string testValue = "a|b|c";
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, testValue);

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void GetCompositionSources_SplitsVariableBySpace()
        {
            string testValue = "a b c";
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, testValue);

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void GetCompositionSources_SplitsVariableByAnyFromCommaSemicolonPipeOrSpace()
        {
            string testValue = "a,b;c|d e";
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, testValue);

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsTrue(result.Count == 5);
        }

        [TestMethod]
        public void GetCompositionSources_SplitsVariableByAnyFromCommaSemicolonPipeOrSpace_Mixed()
        {
            string testValue = "a ,b|;   c|;d e";
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, testValue);

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsTrue(result.Count == 5);
        }

        [TestMethod]
        public void GetCompositionSources_ReturnsDistinctSplittedValues()
        {
            string testValue = "a ,a|;   a|;b c";
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, testValue);

            EnvironmentVariableCompositionSourceProvider toBeTested = new EnvironmentVariableCompositionSourceProvider();
            List<string> result = toBeTested.GetCompositionSources();

            Assert.IsTrue(result.Count == 3 && result[0] == "a" && result[1] == "b" && result[2] == "c");
        }



        [TestCleanup]
        public void CleanupTests()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableNames.CompositionSources, null);
        }
    }
}
