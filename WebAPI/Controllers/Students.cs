using BLL_Business_Logic_Layer_;
using BOL_Business_Object_Layer_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace WebAPI.Controllers
{

    [ApiController]
    public class Students : ControllerBase
    {
        private readonly IStudentService studentService;

        public Students(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudents() {

            var allStudents = await studentService.GetAllStudents();
            return Ok(allStudents);
        }


        // for single student
        [HttpGet]
        [Route("[controller]/{studentId:guid}"), ActionName("GetStudent")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid studentId)
        {

            var student = await studentService.GetStudent(studentId);
            return Ok(student);

        }

        // Update Student Method
        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid studentId, [FromBody] StudentsModel request)
        {

            if (await studentService.Exists(studentId))
            {
                //Update the details
                var student = await studentService.UpdateStudent(studentId, request);
                return Ok(student);
            } else
            {
                return NotFound();
            }


        }

        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]

        public async Task<IActionResult> DeleteStudent([FromRoute] Guid studentId)
        {
            if (await studentService.Exists(studentId))
            {
                //Update the details
                var student = await studentService.DeleteStudent(studentId);
                return Ok(student);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("[controller]/Add")]

        public async Task<IActionResult> AddStudent([FromBody] StudentsModel request)
        {   
           request.Id= Guid.NewGuid();
           var student = await studentService.AddStudent(request);
            return CreatedAtAction(nameof(GetStudent), new { studentId = student.Id }, student);
        }
    
    }
}
