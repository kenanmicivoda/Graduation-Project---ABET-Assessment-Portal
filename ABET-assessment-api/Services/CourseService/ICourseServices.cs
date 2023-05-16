using ABET_assessment_api.Helpers;
using ABET_assessment_api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace ABET_assessment_api.Services.CourseService
{
    public interface ICourseServices
    {
        Task<ActionResult<IEnumerable<Course>>> GetAllCourses();
        Task<SuccesResponse> AddCourse([FromForm] Course course);
        Task<ActionResult<Course>> GetCourse(int id);
        Task<SuccesResponse> DeleteCourse(int id);
        Task<SuccesResponse> EditCourse(int id, [FromForm] Course course);

    }
}
