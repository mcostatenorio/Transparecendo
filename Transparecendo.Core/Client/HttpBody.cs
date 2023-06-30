using System.Text;
using Newtonsoft.Json;
using System.Web;
using Transparecendo.Core.Helpers;

namespace Transparecendo.Core.Client
{
    public class HttpBody
    {
        /// <summary>
        /// Transforma a request na estrutura para envio no http
        /// </summary>
        /// <param name="data">Parâmetros que serão passados no body (casos POST, PUT ou PATCH).</param>
        /// <param name="mediaType">ContentType da chamada</param>
        /// <param name="request">Texto da request gerado no output para log</param>
        /// <returns></returns>
        public virtual (HttpContent?, string) ParseRequest(object? data, string mediaType)
        {
            string? request = null;
            if (data == null)
                return (null, string.Empty);

            switch (mediaType)
            {
                case MediaTypeConstants.APP_XML:
                    request = XmlHelper.Serialize(data) ?? string.Empty;
                    return (new StringContent(request, Encoding.UTF8, mediaType), request);
                case MediaTypeConstants.FORM_ENCODED:
                    request = JsonConvert.SerializeObject(data);
                    var list = data as IEnumerable<KeyValuePair<string, string>> ?? new List<KeyValuePair<string, string>>();
                    return (new FormUrlEncodedContent(list), request);
                default:
                    request = JsonConvert.SerializeObject(data);
                    return (new StringContent(request, Encoding.UTF8, mediaType), request);
            }
        }

        /// <summary>
        /// Transforma a response em texto
        /// </summary>
        /// <typeparam name="T">Tipo de retorno esperado.</typeparam>
        /// <param name="data">Body da response</param>
        /// <param name="mediaType">Tipo informado na response</param>
        /// <returns></returns>
        public virtual T? ParseResponse<T>(string? data, string? mediaType) where T : class
        {
            if (data == null)
                return null;


            switch (mediaType)
            {
                case MediaTypeConstants.APP_XML:
                    return XmlHelper.Deserialize<T>(data);

                case MediaTypeConstants.FORM_ENCODED:
                    var collection = HttpUtility.ParseQueryString(data);

                    Dictionary<string, string> ret = new Dictionary<string, string>(collection.Count);
                    foreach (string item in collection.Keys)
                        ret.Add(item, collection[item] ?? string.Empty);

                    return ret as T;

                default:
                    return JsonConvert.DeserializeObject<T>(data);
            }
        }
    }
}