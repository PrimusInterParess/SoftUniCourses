using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XMLDemo
{

   public class book
    {
        [XmlElement("title")]
        public string Title { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
    }

  public  class Program
    {
        static void Main(string[] args)
        {
            //var file = File.ReadAllText("Data.xml");

            ////  XDocument doc = XDocument.Parse(file);

            //XDocument doc = XDocument.Load("Data.xml");


            //foreach (var element in doc.Root.Elements())
            //{ 
            //    element.SetElementValue("price",1.20);
            //}
             
            //doc.Save("Data_new.xml");

            //doc.Root.Elements().Select(b => new
            //{
            //    Name = b.Element("title").Value,
            //    Isbn = b.Element("Isbn").Value 
            //});


            //XDocument fromScratch = new XDocument();

            ////fromScratch.Add(new XElement("library"));

            //var serializer = new XmlSerializer(typeof(book[]),new XmlRootAttribute("library"));

            // IEnumerable<book> books =(book[])serializer.Deserialize(File.OpenRead(@"C:\work\SoftUniCourses\Csharp\CsharpTrack\04Databases\02EntityFrameworkCore\19XML\01Lab\XmlAttributesDemo\XMLDemo\bin\Debug\netcoreapp3.1\Data.xml"));

            // foreach (var book in books)
            // {
            //     Console.WriteLine(book.title);
            //     Console.WriteLine(book.author);
            // }

            //List<book> books = new List<book>();

            //var serializer = new XmlSerializer(typeof(List<book>), new XmlRootAttribute("library"));

            //books.Add(new book(){author = "dani",title = "golemeca"});

            //serializer.Serialize(File.OpenWrite("good books.xml",books));
        }
    }
}
