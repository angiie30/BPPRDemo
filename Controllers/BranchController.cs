using BPPR_Demo.Models;
using BPPR_Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BPPR_Demo.Controllers
{
    [ApiController]
    [Route("api/Branches")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _branchService.Get();

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var response = await _branchService.Get(id);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Branch branch)
        {
            var response = await _branchService.Create(branch);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
