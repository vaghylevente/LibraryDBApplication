using FDU7VL_HFT_2021221.Endpoint.Services;
using FDU7VL_HFT_2021221.Logic;
using FDU7VL_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public StudentController(IStudentLogic studentLogic, IHubContext<SignalRHub> hub)
        {
            sl = studentLogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("StudentCreated", value);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public void Put([FromBody] Student value)
        {
            sl.Update(value);
            this.hub.Clients.All.SendAsync("StudentUpdated", value);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var studentToDelete = this.sl.Read(id);
            sl.Delete(id);
            this.hub.Clients.All.SendAsync("StudentDeleted", studentToDelete);
            this.hub.Clients.All.SendAsync("BorrowingDeleted", null);
        }
    }
}
