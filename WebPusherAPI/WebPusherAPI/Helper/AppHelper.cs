using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebPusherAPI.Helper
{
    public static class AppHelper
    {
        public static async Task<string> ToBodyJson(this Stream Body)
        {
            using (StreamReader reader = new StreamReader(Body, Encoding.UTF8))
            {
                var jsonString = await reader.ReadToEndAsync();

                return jsonString;
            }
        }

        public static string ToValue(this string jsonString, string Key)
        {
            NameValueCollection qscoll = HttpUtility.ParseQueryString(jsonString);

            if (qscoll.AllKeys.Where(x => x == Key).Count() > 0)
            {
                return qscoll[Key];
            }


            return string.Empty;
        }
    }
}
