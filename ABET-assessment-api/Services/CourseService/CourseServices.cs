using ABET_assessment_api.Helpers;
using ABET_assessment_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABET_assessment_api.Services.CourseService
{
    public class CourseServices : ICourseServices
    {
        public Task<SuccesResponse> AddCourse([FromForm] Course course)
        {
            throw new NotImplementedException();
        }

        public Task<SuccesResponse> DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SuccesResponse> EditCourse(int id, [FromForm] Course course)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Course>> GetCourse(int id)
        {
            throw new NotImplementedException();
        }
    }
}
