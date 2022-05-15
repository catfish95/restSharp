using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestSharpTest.utils
{
    public class GetJsonSchema
    {
        public JSchema GetSchemaFromProject(string path)
        {
            using TextReader reader = File.OpenText(@path);
                return JSchema.Load(new JsonTextReader(reader));
        }
    }
}
