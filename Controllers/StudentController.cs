using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;
using System.Threading.Tasks;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult>  Post(Student student)
        {

            _context.Add(student);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int Id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == Id);
            return Ok(student);
        }


        [HttpPut]
        public async Task<ActionResult> Put(Student student)
        {
            var dbStd = await _context.Students.FirstOrDefaultAsync(m => m.Id == student.Id);

            dbStd.FirstName = student.FirstName;
            dbStd.LastName = student.LastName;
            dbStd.RegistrationNo = student.RegistrationNo;

            _context.Students.Update(dbStd);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var std = await _context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }

            _context.Students.Remove(std);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
