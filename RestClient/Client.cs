using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestClient {
    public class RestClient : IDisposable {
        private Uri _apiUri { get; set; }
        private string _userName { get; set; }
        private string _password { get; set; }
        private WebProxy _proxy { get; set; }

        private HttpClient _client { get; set; }
        private string _urlParameters { get; set; }

        public RestClient(Uri uri, string username = "", string password = "", WebProxy proxy = null, string urlparam = "") {
            _apiUri = uri;
            _userName = username;
            _password = password;
            _proxy = proxy;
            _urlParameters = urlparam;
            Init();
        }
        private void Init() {
            _client = new HttpClient();
            _client.BaseAddress = _apiUri;
            _client.DefaultRequestHeaders.Add("Content-type", "application/x-www-form-urlencoded");
            _client.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.Default.GetBytes($"{_userName}:{_password}"))}");
            // Add an Accept header for JSON format.
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public HttpResponseMessage GetAsync() {
            return  _client.PostAsync();
        }
        public void Dispose() {
            this._client.Dispose();
        }

    }
}
