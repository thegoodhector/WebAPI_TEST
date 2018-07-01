using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWEB_TEST.Models;
using System.Security.Cryptography;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using Amazon.Auth;
using Amazon.S3;

namespace APIWEB_TEST
{
    public class Helper
    {
        public static string Coder(string input, byte[] key)
        {
            HMACSHA1 monhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.UTF8.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return monhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);         
        }

        public static byte[] Convertir_HEX(string inputHex)
        {
            inputHex = inputHex.Replace("-", "");

            byte[] resultantArray = new byte[inputHex.Length / 2];
            for (int i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = Convert.ToByte(inputHex.Substring(i * 2, 2), 16);
            }
            return resultantArray;
        }

        public async void Appel_API(string accessKey, string id, string dataencry)
        {

            byte[] key = Encoding.UTF8.GetBytes(accessKey);


            var details = Coder(dataencry, key);

            byte[] data = Convertir_HEX(details);
            string base64 = Convert.ToBase64String(data);


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://us-east-1.signin.aws.amazon.com");
                client.DefaultRequestHeaders.Date = DateTime.Now;

                string authorization = string.Format("AWS {0}:{1}", id, base64);
                client.DefaultRequestHeaders.Add("Authorization", "AWS " + id + ":" + base64);
                ServicePointManager.ServerCertificateValidationCallback = delegate (
                   Object obj, X509Certificate certificate, X509Chain chain,
                   SslPolicyErrors errors)
                {
                    return (true);
                };


                var response = await client.GetAsync("api/authentificat/ouattari.abdelhak@hotmail.fr");

                var result = response.Content.ReadAsStringAsync().Result;
            }


        }
    }
}