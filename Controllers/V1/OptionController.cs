using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using VEMS.Models.DB.Exams;
using VEMS.Models.DB.Options;
using VEMS.Services.V1;

namespace VEMS.Controllers.V1
{
    public class OptionController : BaseController
    {
        private readonly IBaseEntityService<Option> optionService;
        public OptionController(IBaseEntityService<Option> optionService)
        {
            this.optionService = optionService;
        }

        [HttpPut]
        public async Task<IActionResult> Put(Option option)
        {
            return Ok(await optionService.Put(option));
        }

    }
}
