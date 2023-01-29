using Microservice.Demo.Report.Application;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Demo.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly PolicyApplicationService _policyApplicationService;
        public ReportController(PolicyApplicationService policyApplicationService)
        {
            _policyApplicationService = policyApplicationService;
        }

        // GET api/report
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return new JsonResult(await _policyApplicationService.GetAll());
        }
    }
}