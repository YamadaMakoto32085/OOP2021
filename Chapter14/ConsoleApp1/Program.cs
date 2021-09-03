using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section04
{
    class Program
    {
        Dictionary<string, int> AreaDic = new Dictionary<string, int>()
        {
            {"前橋", 4210},
            {"みなかみ", 4220},
            {"宇都宮", 4110},
            {"水戸", 4010},
        };
        static void Main(string[] args)
        {
            new Program();
        }

        //コンストラクタ
        public Program()
        {
            //DownloadString();
            //DownloadFileAsync();
            //OpenReadSample();
            Console.WriteLine("yahoo!週間天気予報");
            Console.WriteLine(); //改行
            Console.WriteLine("地域コードを入力");
            for(int i = 0; i < AreaDic.Count; i++)
            {
                Console.WriteLine("{0}:{1}", i + 1, );
            }
            Console.WriteLine("1:前橋");
            Console.WriteLine("2:みなかみ");
            Console.WriteLine("3:宇都宮");
            Console.WriteLine("4:水戸");
            Console.WriteLine("9:その他(直接入力)");
            Console.WriteLine(); //改行
            Console.Write(">");
            var selectArea = Console.ReadLine(); //文字列として取り込む
            if (selectArea == "1")
            {
                var results = GetWeatherReportFromYahoo(4210);
                foreach(var s in results)
                {
                    Console.WriteLine(s);
                }
                Console.ReadLine();
            }
            if(selectArea == "2")
            {
                var results = GetWeatherReportFromYahoo(4220);
                foreach(var s in results)
                {
                    Console.WriteLine(s);
                }
                Console.ReadLine();
            }
            if(selectArea == "3")
            {
                var results = GetWeatherReportFromYahoo(4110);
                foreach (var s in results)
                {
                    Console.WriteLine(s);
                }
                Console.ReadLine();
            }
            if(selectArea == "4")
            {
                var results = GetWeatherReportFromYahoo(4010);
                foreach (var s in results)
                {
                    Console.WriteLine(s);
                }
                Console.ReadLine(); 
            }
            if(selectArea == "9")
            {
                Console.WriteLine("コードを入力してください");
                var otherArea = Console.ReadLine();
            }
            Console.ReadLine();//入力待ち
        }

        public void DownloadString()
        {
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var html = wc.DownloadString("https://yahoo.co.jp/");
            Console.WriteLine(html);
        }

        private void DownloadFileAsync()
        {
            var wc = new WebClient();
            var url = new Uri(@"C:\Users\my32085\Desktop\授業関係\プログラム基礎\01_Java_単語登録(読み方：じゃば).txt");
            var filename = @"C:\temp\example.txt";
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            wc.DownloadFileAsync(url, filename);
            Console.ReadLine(); //アプリケーションが終了しないようにする
        }

        static void wc_DownloadProgressChanged(object sender,
                            DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("{0}% {1}/{2}", e.ProgressPercentage,
                              e.BytesReceived, e.TotalBytesToReceive);
        }

        static void wc_DownloadFileCompleted(object sender,
                            System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("ダウンロード完了");
        }

        public void OpenReadSample()
        {
            var wc = new WebClient();
            using (var stream = wc.OpenRead(@"https://yahoo.co.jp/"))
            using(var sr = new StreamReader(stream, Encoding.UTF8))
            {
                string html = sr.ReadToEnd();
                Console.WriteLine(html);
            }
        }

        private static IEnumerable<string> GetWeatherReportFromYahoo(int cityCode)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-type", "charset=UTF-8");
                var uriString = string.Format(
                    @"http://rss.weather.yahoo.co.jp/rss/days/{0}.xml", cityCode);
                var url = new Uri(uriString);
                var stream = wc.OpenRead(url);

                XDocument xdoc = XDocument.Load(stream);
                var nodes = xdoc.Root.Descendants("title");
                foreach (var node in nodes)
                {
                    string s = Regex.Replace(node.Value, "【|】", "");
                    yield return s;
                }
            }
        }
    }
}
