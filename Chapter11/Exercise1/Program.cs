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
            Console.WriteLine("-11.1.1------");
            Exercise1_1(file);
            Console.WriteLine();
            Console.WriteLine("-11.1.2------");

            Exrcise1_2(file);
            Console.WriteLine();
            Console.WriteLine("-11.1.3------");

            Exrcise1_3(file);
            Console.WriteLine();
            Console.WriteLine("-11.1.4------");

            Exrcise1_4(file);
            Console.WriteLine();
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
            var sports = xdoc.Root.Elements()
                                  .Select(x => new
                                  {
                                      Name = x.Element("name").Value,
                                      Teammembers = x.Element("teammembers").Value
                                  }).OrderByDescending(x => int.Parse(x.Teammembers)).First();
            Console.WriteLine("{0}", sports.Name);

        }

        private static void Exrcise1_4(string file)
        {
            var newfile = "sports.xml"; //新しく出力するファイル
            //追加先のxmlファイルを読み込む
            var xdoc = XDocument.Load(file);
            //追加するデータ
            var element = new XElement("ballsport",
                            new XElement("name", "サッカー", new XAttribute("kanji", "蹴球")),
                            new XElement("teammembers", "11"),
                            new XElement("firstplayed", "1863")
                            );
            xdoc.Root.Add(element); //追加先へ追加
            xdoc.Save(newfile);
            //var sports = xdoc.Root.Elements()
            //                      .Select(x => new
            //                      {
            //                          Name = x.Element("name").Attribute("kanji").Value,
            //                          Teammembers = x.Element("teammembers").Value,
            //                          Firstplayed = x.Element("firstplayed").Value
            //                      });
            //foreach(var sport in sports)
            //{
            //    Console.WriteLine("{0} {1} {2}", sport.Name, sport.Teammembers, sport.Firstplayed);
            //}
        }
    }
}