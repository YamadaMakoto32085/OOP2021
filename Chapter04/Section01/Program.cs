using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            int count = 0;

            Console.WriteLine($"後置:{count++}");
            
            Console.WriteLine($"前置:{count++}");

        }

        private static Product GetProductA() {
            Sale sale = new Sale();
            
            return sale?.Product;  //null条件演算子
        }
    }
    class Sale {
        public string ShopName { get; set; } = "abcde";
        public int Amount { get; set; } = 12340;
        public Product Product { get; set; }
    }
}
