using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentcsController : ControllerBase
    {
        [HttpGet]
        [Route("All",Name ="GetAllStudents")]
        public ActionResult<IEnumerable<Students>> GetStudents()
        {
            //Ok - 200 - Success
            return Ok(CollegeRepository.Students);
        }

        [HttpGet]
        [Route("{id:int}",Name ="GetStudentById")]
        public ActionResult<Students> GetStudentsById(int id)
        {
            // BadRequest - 400 - client error
            if (id <= 0)
                return BadRequest();

            var stu = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            // not found - 404 - client error
            if (stu == null) {
                return NotFound($"The student with id {id} not found");
            }
            return Ok(stu);
        }

        [HttpGet("{Name:alpha}",Name ="GetStudentByName")]
        public ActionResult<Students.> GetStudentsByName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
                return BadRequest();

            var stu = CollegeRepository.Students.Where(n => n.Studentname == Name).FirstOrDefault();
            // not found - 404 - client error
            if (stu == null)
            {
                return NotFound($"The student with name {Name} not found");
            }
            return Ok(stu);
            //return CollegeRepository.Students.Where(n => n.Studentname == Name).FirstOrDefault();
        }

        [HttpDelete("{id}",Name = "DeleteStudentById")]
        public ActionResult<bool> DeleteStudent(int id) {
            if (id <= 0) {
                return BadRequest();
                    }
            var stu = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            if (stu == null) {
                return NotFound($"Not Found");
            }
            CollegeRepository.Students.Remove(stu);

            return true;

        }

    }
}
