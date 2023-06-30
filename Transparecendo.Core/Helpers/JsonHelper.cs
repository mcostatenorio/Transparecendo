using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Transparecendo.Core.Helpers
{
    public class JsonHelper
    {
        public static string GetFirstPropertyAtRootLevel(string propertyName, string json)
        {
            using (var stringReader = new StringReader(json))
            using (var reader = new JsonTextReader(stringReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName && reader.Value != null
                        && (string)reader.Value == propertyName)
                    {
                        reader.Read();
                        return reader.ValueType == typeof(string) ? reader.Value.ToString() : JRaw.Create(reader).ToString();
                    }
                }
                return string.Empty;
            }
        }

        public T? GetFirstInstanceAtRootLevel<T>(string propertyName, string json)
        {
            using (var stringReader = new StringReader(json))
            using (var reader = new JsonTextReader(stringReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName && reader.Value != null
                        && (string)reader.Value == propertyName)
                    {
                        reader.Read();

                        var serializer = new JsonSerializer();
                        return serializer.Deserialize<T>(reader);
                    }
                }
                return default(T);
            }
        }
    }
}