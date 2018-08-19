using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace MandMOnTheRoad.Controllers
{
    public class NotificationController : UmbracoAuthorizedApiController
    {
        public const string API_KEY = "AAAAdfZQ3cc:APA91bHK4YCooHbXeWsOum4Pt4a0X5XB65NiokItm-eiuDXY3tDEWzzgX3FDc33eoYHRT8-dWP-xcijPpijetdyYIDMBDGgPXLVkgQsMkptqlnrmfAEXntJZ94PR0fS8LjldDGCPlGmw";
        
        [HttpGet]
        public bool PushNotification(string title, string message)
        {
            var jGcmData = new JObject();
            var jData = new JObject();

            jData.Add("title", title);
            jData.Add("message", message);
            jData.Add("appaction", "map");
            jGcmData.Add("to", "/topics/vakantie");
            jGcmData.Add("data", jData);

            var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Authorization", "key=" + API_KEY);

                    var response = client.PostAsync(url, new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"));
                    return response.Result.IsSuccessStatusCode;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}