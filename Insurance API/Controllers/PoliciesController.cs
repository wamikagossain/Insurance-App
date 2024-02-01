using LearnDapper.Model;
using LearnDapper.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPoliciesRepo repo;
        public PoliciesController(IPoliciesRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _list = await this.repo.GetAll();
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetbyCode/{code}")]
        public async Task<IActionResult> GetbyCode(int policyID)
        {
            var _list = await this.repo.Getbycode(policyID);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] policies policies)
        {
            var _result = await this.repo.Create(policies);
            return Ok(_result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] policies policies, int policyID)
        {
            var _result = await this.repo.Update(policies, policyID);
            return Ok(_result);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int policy_id)
        {
            var _result = await this.repo.Remove(policy_id);
            return Ok(_result);
        }
    }
}
