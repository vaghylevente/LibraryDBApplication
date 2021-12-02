using FDU7VL_HFT_2021221.Models;
using System;

namespace FDU7VL_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:20621/");

            var student = rest.Get<Student>("student");
        }
    }
}
