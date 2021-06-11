using Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            var ymCollection = new YearMonth[] {
                new YearMonth(1980,1),
                new YearMonth(1990,4),
                new YearMonth(2000,7),
                new YearMonth(2010,9),
                new YearMonth(2020,12),
            };
            Exercise2_2(ymCollection);
            Console.WriteLine("----");

            Exercise2_4(ymCollection);
            Console.WriteLine("----");

            Exercise2_5(ymCollection);
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach(var ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }
        //4.2.3
        static YearMonth FindFirst21C(YearMonth[] ymCollection) {
            foreach(var ym in ymCollection) {
                if (ym.Is21Century) 
                    return ym;
            }
            //ここまで来たら２１世紀が存在しない
            return null;
        }

        private static void Exercise2_4(YearMonth[] ymCollection) {
            var yearmonth = FindFirst21C(ymCollection);
            var s = yearmonth != null ? yearmonth.ToString() : "21世紀のデータがありません";
            Console.WriteLine(s);
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            var array = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();
            
            foreach(var ym in array) {
                Console.WriteLine(ym);
            }
        }
    }
}
