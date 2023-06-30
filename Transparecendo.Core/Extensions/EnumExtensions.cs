using System.ComponentModel;
using System.Reflection;
using Transparecendo.Core.Services;

namespace Transparecendo.Core.Extensions
{
    /// <summary>
    /// Operações auxiliares para manipulação de enumeradores.
    /// </summary>
    internal static class EnumExtension
    {
        /// <summary>
        /// Obtém o valor do atributo 'Description' decorado em um valor de um enumerador.
        /// </summary>
        /// <param name="enumType">Tipo do enumerador.</param>
        /// <param name="value">Item do enumerador.</param>
        /// <returns>Descrição do enumerador.</returns>
        public static string? GetDescription(Type enumType, object value)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.ToString() == null)
                return value.ToString();

            var fi = enumType.GetField(value.ToString() ?? "");

            if (fi == null)
                return value.ToString();

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes == null || attributes.Length == 0)
            {
                return value.ToString();
            }

            return attributes[0].Description;
        }

        /// <summary>
        /// Obtém o valor do atributo 'Description' decorado em um valor de um enumerador.
        /// </summary>
        /// <param name="value">Item do enumerador.</param>
        /// <returns>Descrição do enumerador.</returns>
        public static string Description(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var attribute = value.GetCustomAttribute<DescriptionAttribute>();

            if (attribute == null)
                return value.ToString();

            return attribute.Description;
        }

        /// <summary>
        /// Obtém o valor do atributo 'Description' decorado em um valor de um enumerador.
        /// </summary>
        /// <param name="value">Item do enumerador.</param>
        /// <param name="parameters">Parâmetros do erro.</param>
        /// <returns>Descrição do enumerador.</returns>
        public static string Description(this Enum value, params object[] parameters)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var attribute = value.GetCustomAttribute<DescriptionAttribute>();

            if (attribute == null)
                return string.Format(value.ToString(), parameters);

            return string.Format(attribute.Description, parameters);
        }

        public static T GetCustomAttribute<T>(this Enum value) where T : Attribute
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var fi = value.GetType().GetField(value.ToString());

            return fi.GetCustomAttribute<T>();
        }

        /// <summary>
        /// Obtém a representação do erro que está em um enumerador.
        /// </summary>
        /// <param name="errorItem">Erro ocorrido.</param>
        /// <param name="parameters">Parâmetros do erro.</param>
        /// <returns>Objeto com os dados do erro.</returns>
        public static MetaError createMetaError(this Enum errorItem, params object[] parameters)
        {
            string description = errorItem.Description();
            string message = string.Empty;

            bool existsParameter = false;
            try
            {
                var existsIndex = parameters[0];
                existsParameter = true;

            }
            catch
            {
                existsParameter = false;
            }

            if (!existsParameter)
                message = description;
            else
                message = string.Format(description, parameters);

            string key = $"Transparecendo_{errorItem.ToString()}";

            return new MetaError(
                new ErrorEntity()
                {
                    Key = key.ToUpper(),
                    Message = message,
                    Args = parameters
                }
            );
        }


        private static string ToCamelCaseString(this string str)
        {
            if (!string.IsNullOrEmpty(str))
                return char.ToLowerInvariant(str[0]) + str.Substring(1);

            return str;
        }

        /// <summary>
        /// Obtém a representação do erro que está em um enumerador.
        /// </summary>
        /// <param name="errorItem">Erro ocorrido.</param>
        /// <param name="parameters">Parâmetros do erro.</param>
        /// <returns>Objeto com os dados do erro.</returns>
        public static MetaError createMetaError(this object errorItem, params object[] parameters)
        {
            return createMetaError((Enum)errorItem, parameters);
        }

        /// <summary>
        /// Verifica se um valor é válido para um enumerador.
        /// </summary>
        /// <param name="type">Tipo do enumerador.</param>
        /// <param name="value">Valor atribuído ao enumerador.</param>
        /// <returns>Retorna true se for um valor válido para o enumerador, senão, false.</returns>
        public static bool IsEnum(Type type, object value)
        {
            return Enum.IsDefined(type, value);
        }
    }
}