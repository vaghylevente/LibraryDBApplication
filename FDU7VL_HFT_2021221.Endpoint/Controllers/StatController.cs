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
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBorrowingLogic bl;
        public StatController(IBorrowingLogic borrowingLogic)
        {
            bl = borrowingLogic;
        }

        //GET: /stat/mostpopularbook
        [HttpGet]
        public Book MostPopularBook()
        {
            return bl.MostPopularBook();
        }

        [HttpGet]
        public Student FirstBorrower()
        {
            return bl.FirstBorrower();
        }

        [HttpGet]
        public Student BiggestBorrower()
        {
            return bl.BiggestBorrower();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<Book, int>> BorrowingPerBook()
        {
            return bl.BorrowingPerBook();
        }

        [HttpGet("{name}")]
        public IEnumerable<Book> BooksBorrowedBy(string name)
        {
            return bl.BooksBorrowedBy(name);
        }

        
    }
}
