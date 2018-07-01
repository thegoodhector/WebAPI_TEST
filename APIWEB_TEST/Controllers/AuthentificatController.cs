using APIWEB_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWEB_TEST.Controllers
{
    public class AuthentificatController : ApiController
    {
        Utilisateur[] personne = new Utilisateur[]
      {
             new Utilisateur {Email="thegoodhector84@gmail.com",Password="123456" },
             new Utilisateur {Email="aouattari@ooredoo.dz",Password="123456"  }

      };


        public IHttpActionResult GetUser(string mail,string pass)
        {
            var userme = personne.FirstOrDefault((p) => p.Email == mail && p.Password == pass);
            if (userme == null)
            {
                return NotFound();
            }
            return Ok(userme);
        }


    }
}
