using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.RepresentationModel.Serialization;

namespace YamlDotNet.Samples
{
    public class DeserializeYamlStreamIntoKnownType
	{
        private const string Document = @"---
Name: hello
List:
  - dfghjkl
  - 456789fd    
Fields: {
  key1: value 1
        sdf
        456789sdfghjk,
  key_2: value 222
}
";
        public class Product
        {
            public string Name { get; set; }
            public IList<string> List { get; set; }
            public Dictionary<string, string> Fields { get; set; }
        }

		public void Run(string[] args)
		{
			// Setup the input
			var input = new StringReader(Document);

			// Load the stream
            //var yaml = new YamlStream();
            //yaml.Load(input);

		    var serializer = new YamlSerializer<Product>();
		    var result = serializer.Deserialize(input);


            var dumpSerializer = new Serializer();
            dumpSerializer.Serialize(Console.Out, result);

            //Console.WriteLine(result);
            //// Examine the stream
            //var mapping =
            //    (YamlMappingNode)yaml.Documents[0].RootNode;

            //foreach (var entry in mapping.Children)
            //{
            //    Console.WriteLine(((YamlScalarNode)entry.Key).Value);
            //}
		}
	}
}
