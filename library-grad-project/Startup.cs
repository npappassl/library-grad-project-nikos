using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LibraryGradProject.Startup))]

namespace LibraryGradProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Run(async (context) =>
            //{
            //    if(context.Request.Path.ToString().Contains("api/"))
            //    {
            //        context.
            //    }
            //    else
            //    {
            //        await context.Response.WriteAsync("<div style=\"font-size:4em; text-align:center;\" >hello world</div>");
            //    }
            //});
        }
    }
}
