using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using System.Web.Http;

namespace WebApi.Controllers
{
    /// <summary>
    /// document:https://forums.asp.net/t/1885055.aspx?ASP+NET+Web+API+and+HTML+5+Server+Sent+Events+aka+EventSource+
    /// </summary>
    public class ServerSendController : ApiController
    {
        static Timer _timer = new Timer(5000);
        static readonly List<StreamWriter> ConnectedClients = new List<StreamWriter>();

        public ServerSendController()
        {
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var clientStream in ConnectedClients)
            {
                try
                {
                    clientStream.Write($"data:{JsonConvert.SerializeObject(new { t = DateTime.Now })}\n\n");
                    clientStream.Flush();
                }
                catch (Exception ex)
                {
                    ConnectedClients.Remove(clientStream);
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public HttpResponseMessage Get()
        {

            HttpResponseMessage response = Request.CreateResponse();

            response.Content = new PushStreamContent(new Action<Stream, HttpContent, TransportContext>(OnStreamAvailable), "text/event-stream");
            return response;
        }


        public static void OnStreamAvailable(Stream stream, HttpContent headers, TransportContext context)
        {
            var clientStream = new StreamWriter(stream);
            ConnectedClients.Add(clientStream);
        }
    }
}