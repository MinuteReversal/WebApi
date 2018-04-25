using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace WebApi.Controllers
{

    public class MultipartMIMEModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            //https://docs.microsoft.com/zh-cn/aspnet/web-api/overview/advanced/sending-html-form-data-part-2
            if (!actionContext.Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = @"D:\代码\CSharp\WebApi\WebApi\App_Data";
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                actionContext.Request.Content.ReadAsMultipartAsync(provider);

                // Show all the key-value pairs.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        Trace.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }

        }
    }


    public class ImageModel
    {
        public string Name { get; set; }
        public MemoryStream File { get; set; }
    }

    public class MultipartMIMEModelBinderController : ApiController
    {
        public ImageModel Post([ModelBinder(typeof(MultipartMIMEModelBinder))] ImageModel model)
        {
            return new ImageModel
            {
                Name = "hello"
            };
        }
    }
}
