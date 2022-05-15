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
        public JsonSchema GetSchemaFromProject(string path)
        {
            using TextReader reader = File.OpenText(@path);
                return JsonSchema.Read(new JsonTextReader(reader));
        }
    }
}
