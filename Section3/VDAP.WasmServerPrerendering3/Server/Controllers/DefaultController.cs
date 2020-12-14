using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VDAP.WasmServerPrerendering2.Shared;

namespace VDAP.WasmServerPrerendering2.Server.Controllers
{

    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        [Route("api/ClientSettings")]
        public AppSettings ClientSettings()
        {
            return VDAP.WasmServerPrerendering2.Client.BAL.AppGlobalInfo.AppSettings;
        }
    }
}
