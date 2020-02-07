using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Model;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private StudentContext studentContext;
        public ValuesController(StudentContext context)
        {
            studentContext = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            try
            {
           
                var students = studentContext.Students.ToList();
               
                return Ok(students);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get(int id)
        {
            try
            {

              
                var student = studentContext.Students.Find(id);
                



                return Ok(student);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("create")]
        public ActionResult<IEnumerable<Student>> Create(Student student)
        {
            try
            {

             studentContext.Students.Add(student);
             studentContext.SaveChanges();

                return Ok(student);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("upDate")]
        public ActionResult<IEnumerable<Student>> UpDate(Student student)
        {
            try
            {

                studentContext.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    
                studentContext.SaveChanges();

                return Ok(student);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpDelete]
        public ActionResult<IEnumerable<Student>> Delete(int id)
        {
            try
            {
                var student = studentContext.Students.Where(s => s.Id == id).FirstOrDefault();
                studentContext.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;



                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        ~ValuesController()
        {
            studentContext.Dispose();
        }
    }
}