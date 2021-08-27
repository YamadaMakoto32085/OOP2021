using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "Sample.xml";
            Exercise1_1(file);
            Console.WriteLine("-------");

            Exrcise1_2(file);
            Console.WriteLine("-------");

            Exrcise1_3(file);
            Console.WriteLine("-------");

        }

        private static void Exercise1_1(string file)
        {
            var xdoc = XDocument.Load(file);
            var ballsports = xdoc.Root.Elements().Select(x => new
            {
                Name = x.Element("name").Value,
                Teammembers = x.Element("teammembers").Value
            });
            foreach(var ballsport in ballsports)
            {
                Console.WriteLine("{0}:{1}", ballsport.Name, ballsport.Teammembers);
            }

        }

        private static void Exrcise1_2(string file)
        {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                                  .Select(x => new
                                  {
                                      Firstplayed = x.Element("firstplayed").Value,
                                      Name = x.Element("name").Attribute("kanji").Value
                                  }).OrderBy(x => int.Parse(x.Firstplayed));
.            foreach (var sport in sports)
            {
                Console.WriteLine("{0} {1}", sport.Name, sport.Firstplayed);
            }

        }

        private static void Exrcise1_3(string file)
        {
            var xdoc = XDocument.Load(file);


        }
    }
}
