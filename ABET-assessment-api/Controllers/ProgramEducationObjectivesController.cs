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
    public class ProgramEducationObjectivesController : Controller
    {

        private readonly Context _context;
        public ProgramEducationObjectivesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramEducationalObjective>>> GetAllPEO()
        {
            return _context.ProgramEducationalObjectives.ToList();
        }

        [HttpPut("singlePEO/{id}")]
        public async Task<ActionResult<ProgramEducationalObjective>> getPEO(int id)
        {
            var model = await _context.ProgramEducationalObjectives.SingleOrDefaultAsync(j => j.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return model;
        }


        [HttpPost]
        public async Task<IActionResult> AddPEO(ProgramEducationObjectiveDTO peoModel)
        {
            var peo = new ProgramEducationalObjective
            {
                Name = peoModel.Name,
                Description = peoModel.Description
            };

            _context.ProgramEducationalObjectives.Add(peo);
            await _context.SaveChangesAsync();

            return Ok(peo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePEO(int id)
        {
            var model = await _context.ProgramEducationalObjectives.FirstOrDefaultAsync(i => i.Id == id);

            _context.ProgramEducationalObjectives.Remove(model);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> EditPEO(int id, ProgramEducationalObjectiveEditDTO peoModel)
        {
            if (id != peoModel.Id)
            {
                return Ok(new SuccesResponse { Successful = false });
            }

            var existingPEO = await _context.ProgramEducationalObjectives.FindAsync(id);

            if (existingPEO == null) { return Ok(new SuccesResponse { Successful = false }); }

            existingPEO.Name = peoModel.Name;
            existingPEO.Description = peoModel.Description;

            await _context.SaveChangesAsync();

            return Ok(new SuccesResponse { Successful = true });
        }


    }
}
