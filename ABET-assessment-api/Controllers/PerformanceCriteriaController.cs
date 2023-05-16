using ABET_assessment_api.DataContext;
using ABET_assessment_api.DTO;
using ABET_assessment_api.Helpers;
using ABET_assessment_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABET_assessment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceCriteriaController : Controller
    {
        private readonly Context _context;
        public PerformanceCriteriaController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerformanceCriteria>>> getAllPerformanceCriteria()
        {
            return _context.PerformanceCriterias.ToList();
        }

        [HttpPut("singlePerformanceCriteria/{id}")]
        public async Task<ActionResult<PerformanceCriteria>> getPerformanceCriteria(int id)
        {
            var model = await _context.PerformanceCriterias.SingleOrDefaultAsync(j => j.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerformanceCriteria(PerformanceCriteriaDTO pcModel)
        {
            var pc = new PerformanceCriteria
            {
                Name = pcModel.Name,
                Description = pcModel.Description
            };

            _context.PerformanceCriterias.Add(pc);
            await _context.SaveChangesAsync();

            return Ok(pc);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePEO(int id)
        {
            var model = await _context.PerformanceCriterias.FirstOrDefaultAsync(i => i.Id == id);

            _context.PerformanceCriterias.Remove(model);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> EditPEO(int id, PerformanceCriteriaDTO pcModel)
        {

            var existingPC = await _context.PerformanceCriterias.FindAsync(id);

            if (existingPC == null) { return Ok(new SuccesResponse { Successful = false }); }

            existingPC.Name = pcModel.Name;
            existingPC.Description = pcModel.Description;

            await _context.SaveChangesAsync();

            return Ok(new SuccesResponse { Successful = true });
        }
    }
}
