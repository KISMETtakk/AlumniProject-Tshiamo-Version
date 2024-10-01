using AlumniSpace.DTOs;
using AlumniSpace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnusController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public AlumnusController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(AlumnusDTO alumnusDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //signup validation
            var objAlumnus = dbContext.Alumnus.FirstOrDefault(a => a.Email == alumnusDTO.Email);

            if (objAlumnus == null)
            {
                dbContext.Alumnus.Add(new Alumnus
                {
                    StudentNum = alumnusDTO.StudentNum,
                    Email = alumnusDTO.Email,
                    Password = alumnusDTO.Password
                });
                dbContext.SaveChanges();

                return Ok($"Alumnus {alumnusDTO.StudentNum} has registered successfully");
            }
            else
            {
                return BadRequest($"Alumnus with email '{objAlumnus.Email}' already exists. Try again.");
            }

        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var alumnus = dbContext.Alumnus.FirstOrDefault(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password);

            if (alumnus != null)
            {
                return Ok(alumnus);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("Get
        public IActionResult GetAlumnis() 
        {
            return Ok (dbContext.Alumnus.ToList());
        }

        [HttpGet]
        [Route("GetAlumnus")]
        public IActionResult GetAlumnus(int id)
        {
            var alumnus = dbContext.Alumnus.FirstOrDefault(a => a.StudentNum == id);

            if (alumnus != null)
            {
                return Ok(alumnus);
            }
            else
            {
                return NoContent();
            }
            
        }
    }
}
