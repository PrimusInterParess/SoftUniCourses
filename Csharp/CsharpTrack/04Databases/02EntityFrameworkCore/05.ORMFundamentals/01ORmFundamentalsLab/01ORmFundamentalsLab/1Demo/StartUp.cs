using System;
using System.Linq;
using _1Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace _1Demo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext SUContext = new SoftUniContext();

            SUContext.Employees.Count();

        }
    }
}
