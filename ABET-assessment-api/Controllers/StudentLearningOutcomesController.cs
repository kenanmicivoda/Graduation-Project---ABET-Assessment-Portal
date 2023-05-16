using ABET_assessment_api.DataContext;
using ABET_assessment_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using ABET_assessment_api.DTO;
using ABET_assessment_api.Helpers;

namespace ABET_assessment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentLearningOutcomesController : Controller
    {

        private readonly Context _context;
        public StudentLearningOutcomesController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<StudentLearningOutcome>> GetSO()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 32,
                WriteIndented = true
            };


            var so = _context.StudentLearningOutcomes
                .Include(c=>c.PerformanceCriterias)
                .Include(d=>d.ProgramEducationalObjectives).ToList();

            var json = JsonSerializer.Serialize(so, options);
            return Ok(json);
        }

        [HttpPut("singleSO/{id}")]
        public async Task<ActionResult<StudentLearningOutcome>> getSO(int id)
        {
            var model = await _context.StudentLearningOutcomes.SingleOrDefaultAsync(j => j.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return model;
        }


        [HttpPost]
        public async Task<IActionResult> AddSLO(StudentLearningOutcomeDTO sloModel)
        {
            var slo = new StudentLearningOutcome
            {
                Name = sloModel.Name,
                Description = sloModel.Description
            };

            _context.StudentLearningOutcomes.Add(slo);
            await _context.SaveChangesAsync();

            return Ok(slo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSLO(int id)
        {
            var model = await _context.StudentLearningOutcomes.FirstOrDefaultAsync(i => i.Id == id);

            _context.StudentLearningOutcomes.Remove(model);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> EditSLO(int id, StudentLearningOutcomeDTO sloModel)
        {
            var existingSLO = await _context.StudentLearningOutcomes.FindAsync(id);

            if (existingSLO == null) { return Ok(new SuccesResponse { Successful = false }); }

            existingSLO.Name = sloModel.Name;
            existingSLO.Description = sloModel.Description;

            await _context.SaveChangesAsync();

            return Ok(new SuccesResponse { Successful = true });
        }
    }
}
