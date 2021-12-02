using FDU7VL_HFT_2021221.Logic;
using FDU7VL_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FDU7VL_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentLogic sl;
        public StudentController(IStudentLogic studentLogic)
        {
            sl = studentLogic;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return sl.ReadAll();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return sl.Read(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            sl.Create(value);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public void Put([FromBody] Student value)
        {
            sl.Update(value);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.Delete(id);
        }
    }
}
