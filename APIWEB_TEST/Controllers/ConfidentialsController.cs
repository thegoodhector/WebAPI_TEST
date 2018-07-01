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




namespace APIWEB_TEST.Controllers
{
    public class ConfidentialsController : ApiController
    {
        public void Test()
        {
            string donneecrypt = "GET" + Environment.NewLine + Environment.NewLine + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine;

            Helper h = new Helper();
            h.Appel_API("muu1yL89BUC+PGLlE0KioYcIEjLIUUYPo5kFaSuL","AKIAJVL7DCGWHAUOAQDQ", donneecrypt);
        }


    }
}
