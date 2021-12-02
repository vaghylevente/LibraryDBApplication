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
    public class BorrowingController : ControllerBase
    {
        IBorrowingLogic bl;
        public BorrowingController(IBorrowingLogic borrowingLogic)
        {
            bl = borrowingLogic;
        }
        // GET: api/<BorrowingController>
        [HttpGet]
        public IEnumerable<Borrowing> Get()
        {
            return bl.ReadAll();
        }

        // GET api/<BorrowingController>/5
        [HttpGet("{id}")]
        public Borrowing Get(int id)
        {
            return bl.Read(id);
        }

        // POST api/<BorrowingController>
        [HttpPost]
        public void Post([FromBody] Borrowing value)
        {
            bl.Create(value);
        }

        // PUT api/<BorrowingController>/5
        [HttpPut]
        public void Put([FromBody] Borrowing value)
        {
            bl.Update(value);
        }

        // DELETE api/<BorrowingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.Delete(id);
        }
    }
}
