using System;
using System.Linq;
using System.Threading.Tasks;
using Bp.EfCore.Data.Context;
using BP.EfCore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BP.EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        public StudentController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Student filter = new Student() { FirstName = "Eray" };

            var students = applicationDbContext.Students.AsQueryable();

            if (!String.IsNullOrEmpty(filter.FirstName))
                students = students.Where(i => i.FirstName == filter.FirstName);

            if (!String.IsNullOrEmpty(filter.LastName))
                students = students.Where(i => i.LastName == filter.LastName);

            if (filter.Number > 0)
                students = students.Where(i => i.Number == filter.Number);

            var list = students.Count();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {

            Student student = new Student()
            {
                FirstName = "Eray",
                LastName = "Berberoğlu",
                Number = 363,
                StudentAddress = new StudentAddress()
                {
                    City = "Izmir",
                    District = "Konak",
                    FullAddress = "Menderes Street No:666",
                    Country = "Turkey"
                }
            };

            await applicationDbContext.Students.AddAsync(student);
            await applicationDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await applicationDbContext.Students.FirstOrDefaultAsync(p => p.Id == id);
            applicationDbContext.Students.Remove(student);
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var student = await applicationDbContext.Students.FirstOrDefaultAsync(p => p.Id == id);
            student.FirstName = "Beycan";
            student.Number = 666;
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }

    }
}