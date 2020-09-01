using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VEMS.Services.V1;

namespace VEMS.Controllers.V1
{
    public class GlobalController : BaseController
    {
        private readonly IDashboard dashboard;
        public GlobalController(IDashboard dashboard)
        {
            this.dashboard = dashboard;
        }

        [HttpGet("GetDashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            return Ok(await dashboard.Get());
        }
    }
}
