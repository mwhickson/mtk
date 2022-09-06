using System.Net;
using System.Text;

namespace mtk.services
{
    public class Web
    {
        public static async Task<string> Fetch(string url)
        {
            string content = "";
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                switch(response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        StreamReader reader = new StreamReader(response.Content.ReadAsStream(), Encoding.UTF8);
                        content = reader.ReadToEnd();
                        break;

                    default:
                        content = String.Format("{0} {1}", (int)response.StatusCode, response.StatusCode);
                        break;
                }
            }
            catch(Exception ex)
            {
                content = ex.Message;
            }

            return content;
        }

    }

}