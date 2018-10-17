using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestClient {
    public class Program {
        static void Main(string[] args) {

            try {
                using (RestClient rest = new RestClient(new Uri($"http://api.octanner.net/performance/auth/token"),
                "eecd46b55e9e2985e1f1c8439e97eeb0",
                "CsuueNDkY6hKB98DwfKFfgmFT21VkSCv4NdCFQrA3pZS0cbtrNmTHofPXDP2PZLn",
                null,
                "?grant_type=client_credential")) {
                    HttpResponseMessage response = rest.GetAsync();
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }

        }
    }
}
