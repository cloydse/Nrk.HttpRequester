﻿using System.Linq;
using System.Net.Http;
using System.Threading;
using Nancy;
using Nancy.Extensions;
using Owin;

namespace Nrk.HttpRequester.IntegrationTests.TestServer
{
    public class ServerModule : NancyModule
    {
        public ServerModule()
        {
            Get["/"] = _ => "success";

            Put["/"] = _ => "success";

            Post["/"] = _ => "success";

            Delete["/"] = _ => "success";

            Put["/headers"] = _ => Response.AsJson(Request.Headers.ToArray());
            
            Post["/headers"] = _ => Response.AsJson(Request.Headers.ToArray());

            Delete["/headers"] = _ => Response.AsJson(Request.Headers.ToArray());

            Put["/content"] = _ => Request.Body.AsString();

            Post["/content"] = _ => Request.Body.AsString();
            
            Delete["/content"] = _ => Request.Body.AsString();

            Get["/delay/{ms:int}"] = parameters =>
            {
                Thread.Sleep(parameters.ms);
                return $"Finished sleeping for {parameters.ms}ms";
            };

            Get["/headers"] = _ =>
            {
                var headers = Request.Headers.ToArray();
                return Response.AsJson(headers);
            };
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseNancy();
        }
    }
}
