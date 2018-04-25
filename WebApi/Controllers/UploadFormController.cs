using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{

    public class MyModel
    {
        public HttpPostedFileBase File { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class UploadFormController : Controller
    {
        public string Parameter(string Name, int Age, HttpPostedFileBase File)
        {
            return $"received:{Name}";
        }

        [HttpPost]
        public string Model([Bind(Include = "Name,Age,File")]MyModel model)
        {
            return $"received:{model.Name}";
        }
    }
}
