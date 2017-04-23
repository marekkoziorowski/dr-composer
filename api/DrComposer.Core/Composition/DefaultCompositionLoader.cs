using DrComposer.Core.Composition.Configuration.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DrComposer.Core.Composition
{
    public class DefaultCompositionLoader : ICompositionLoader
    {
        private ICompositionSourceProvider compositionSourceProvider;
        private ICompositionParser compositionParser;
        private IFileReader fileReader;
        private IComposeVersionResolver composeVersionResolver;

        public DefaultCompositionLoader(
            ICompositionSourceProvider compositionSourceProvider, 
            ICompositionParser compositionParser, 
            IFileReader fileReader,
            IComposeVersionResolver composeVersionResolver
            )
        {
            this.compositionSourceProvider = compositionSourceProvider;
            this.compositionParser = compositionParser;
            this.fileReader = fileReader;
            this.composeVersionResolver = composeVersionResolver;
        }

        public List<Composition> LoadCompositions()
        {
            List<string> paths = compositionSourceProvider.GetCompositionSources();
            List<Composition> compositions = new List<Composition>();

            foreach(string path in paths)
            {
                if (!fileReader.Exists(path)) continue;

                string compositionText = fileReader.ReadAllText(path);
                Type compositionSourceModelType = composeVersionResolver.ResolveCompositionModelType(compositionText);

                BaseDockerComposeYml compositionSourceModel = compositionParser.Parse(compositionSourceModelType, compositionText);
                
                //composition.Source = path;
                //compositions.Add(composition);
            }

            return compositions;
        }
    }
}
