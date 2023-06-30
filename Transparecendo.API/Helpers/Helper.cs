using System.Text.RegularExpressions;

namespace Transparecendo.Service.API.Helpers
{
    public static class Helper
    {
        public static string OnlyNumbers(string value)
        {
            return Regex.Replace(value, @"[^\d]", string.Empty);
        }
    }
}
