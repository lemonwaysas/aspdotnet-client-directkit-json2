using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;
using com.lemonway;
using Microsoft.Extensions.Options;
using aspdotnet_client_directkit_json2.Services;

namespace aspdotnet_client_directkit_json2.Controllers
{
    public class HomeController : Controller
    {
		private readonly ILwService lwService;
		private readonly LwConfig lwConfig;
		

		public HomeController(ILwService lwService, IOptions<LwConfig> lwConfigAccessor)
		{
			this.lwService = lwService;
			this.lwConfig = lwConfigAccessor.Value;
		}

        public JsonResult Index()
        {
			var request = new LwRequest(lwConfig, new EndUserInfoProvider(Request));
			var response = lwService.Call("GetWalletDetails", request.Set("wallet", "sc"));
			return new JsonResult(response);
		}
    }
}
