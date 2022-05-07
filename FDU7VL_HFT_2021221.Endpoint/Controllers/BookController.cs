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
    public class BookController : ControllerBase
    {
        IBookLogic bl;
        IHubContext<SignalRHub> hub;
        public BookController(IBookLogic bookLogic, IHubContext<SignalRHub> hub)
        {
            bl = bookLogic;
            this.hub = hub;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bl.ReadAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return bl.Read(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            bl.Create(value);
            this.hub.Clients.All.SendAsync("BookCreated", value);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public void Put([FromBody] Book value)
        {
            bl.Update(value);
            this.hub.Clients.All.SendAsync("BookUpdated", value);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bookToDelete = bl.Read(id);
            bl.Delete(id);
            this.hub.Clients.All.SendAsync("BookDeleted", bookToDelete);
            this.hub.Clients.All.SendAsync("BorrowingDeleted", null);
        }
    }
}
