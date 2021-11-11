using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;


namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new StudentSystemContext();

        }
    }
}
