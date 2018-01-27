using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Text;
using System.IO;

namespace Xamarin
{
    public class NetworkService
    {

        public static FormUrlEncodedContent GetAccessCodeUrlsCnt(string username, string password, string clientId, string clientSecret)
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
            postData.Add(new KeyValuePair<string, string>("client_id", clientId));
            postData.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
            postData.Add(new KeyValuePair<string, string>("username", username));
            postData.Add(new KeyValuePair<string, string>("password", password));
            FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
            return content;
        }


        public static string GetPushRegUrl(string accessToken, HttpClient client, string baseUrl)
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("html"));

            // Add the Authorization header with the AccessToken.
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            return putUri;
        }

        public static void PreparePushRegistration(string regId, string accessToken, string outUrl, string deviceIdentifier,  HttpClient client, out FormUrlEncodedContent content, out string putUri)
        {
            client.BaseAddress = new Uri(outUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("html"));

            // Add the Authorization header with the AccessToken.
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            // create the URL string.
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("identifier", deviceIdentifier));
            postData.Add(new KeyValuePair<string, string>("token", regId));
            content = new FormUrlEncodedContent(postData);
        }

        public static void GetUpdateRegistration(string regId, string baseUrl,  string identifier,  string platform, string handle, string tag, string accessToken, HttpClient client, out FormUrlEncodedContent content, out string putUri)
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("html"));

            // Add the Authorization header with the AccessToken.
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("identifier", Uri.EscapeUriString(identifier)));
            postData.Add(new KeyValuePair<string, string>("token", Uri.EscapeUriString(regId)));
            postData.Add(new KeyValuePair<string, string>("platform", Uri.EscapeUriString(platform)));
            postData.Add(new KeyValuePair<string, string>("handle", Uri.EscapeUriString(handle)));
            postData.Add(new KeyValuePair<string, string>("tag", Uri.EscapeUriString(tag)));
            content = new FormUrlEncodedContent(postData);
        }

    }
}

