using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Transparecendo.Core.Helpers
{
    /// <summary>
    /// Métodos para auxiliar com xml
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Transforma uma objeto em xml
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? Serialize(object value)
        {
            if (value == null)
                return null;

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { CheckCharacters = false, Indent = false, OmitXmlDeclaration = true }))
                {
                    new XmlSerializer(value.GetType()).Serialize(xmlWriter, value, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
                }

                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Transforma um xml em um objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? Deserialize<T>(string value) where T : class
        {
            return Deserialize(value, typeof(T)) as T;
        }

        /// <summary>
        /// Transforma um xml em um objeto
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object? Deserialize(string value, Type type)
        {
            if (value == null)
                return null;

            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                return new XmlSerializer(type).Deserialize(memoryStream);
            }
        }
    }
}