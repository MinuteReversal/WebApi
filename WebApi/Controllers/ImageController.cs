using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace WebApi.Controllers
{


    public class ImageController : ApiController
    {
        public string Post()
        {
            var stream = Request.Content.ReadAsMultipartAsync();
            return "";
        }
    }
}
