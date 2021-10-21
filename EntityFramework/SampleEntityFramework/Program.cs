﻿using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //演習問題
            Console.WriteLine("# 1.1");
            Exercise13_1_1();

            Console.WriteLine("# 1.2");
            Exercise13_1_2();

            Console.WriteLine("# 1.3");
            Exercise13_1_3();

            Console.WriteLine("# 1.4");
            Exercise13_1_4();

            Console.WriteLine("# 1.5");
            Exercise13_1_5();

            Console.ReadLine(); //F5で実行してもすぐコンソール画面が消えないようにする
        }

        private static void Exercise13_1_1()
        {
            using(var db = new BooksDbContext())
            {
                InsertBooks();
                var author1 = new Author
                {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛",
                };
                db.Authors.Add(author1);
                var author2 = new Author
                {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端康成",
                };
                db.Authors.Add(author2);
                var book1 = new Book
                {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = new Author
                    {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);
                var book2 = new Book
                {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = author2,
                };
                db.Books.Add(book2);
                var book3 = new Book
                {
                    Title = "真珠夫人",
                    PublishedYear = 2002,
                    Author = author1
                };
                db.Books.Add(book3);
                var book4 = new Book
                {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = new Author
                    {
                        Birthday = new DateTime(1896, 8, 27),
                        Gender = "M",
                        Name = "宮沢賢治",
                    }
                };
                db.Books.Add(book4);
                db.SaveChanges();
            }
        }

        private static void Exercise13_1_2()
        {
            using (var db = new BooksDbContext())
            {
                foreach (var book in db.Books)
                {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd})",
                                        book.Title, book.PublishedYear,
                                        book.Author.Name, book.Author.Birthday);
                }
            }
        }

        private static void Exercise13_1_3()
        {
            using(var db = new BooksDbContext())
            {
                var books = db.Books.Where(b => b.Title.Length == db.Books.Max(x => x.Title.Length));
                foreach(var book in books)
                {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd}", book.Title, book.PublishedYear,
                                                                   book.Author.Name, book.Author.Birthday);
                }
            }
        }

        private static void Exercise13_1_4()
        {
            using(var db = new BooksDbContext())
            {
                var books = db.Books.OrderBy(b => b.PublishedYear).Take(3);
                foreach(var book in books)
                {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd}", book.Title, book.PublishedYear,
                                                                   book.Author.Name, book.Author.Birthday);
                }
            }
        }

        private static void Exercise13_1_5()
        {
            using(var db = new BooksDbContext())
            {
                var authors = db.Authors.OrderByDescending(a => a.Birthday);
                foreach (var author in authors)
                {
                    Console.WriteLine("{0} {1:yyyy/MM}", author.Name, author.Birthday);
                    foreach (var book in author.Books)
                    {
                        Console.WriteLine("  {0} {1}", book.Title, book.PublishedYear,
                                                      book.Author.Name, book.Author.Birthday);
                    }
                    Console.WriteLine();
                }
            }
        }

        // List 13-12
        private static void DeleteBook()
        {
            using(var db = new BooksDbContext())
            {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }

        // List 13-11
        private static void UpdateBook()
        {
            using(var db = new BooksDbContext())
            {
                var book = db.Books.Single(x => x.Title == "銀河鉄道の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();
            }
        }

        // List 13-5
        static void InsertBooks()
        {
            using (var db = new BooksDbContext())
            {
                var book1 = new Book
                {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author
                    {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);

                var book2 = new Book
                {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author
                    {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges(); //データベースの更新
            }
        }

        // List 13-7
        static IEnumerable<Book> GetBooks()
        {
            using(var db = new BooksDbContext())
            {
                return db.Books.Where(book => book.Author.Name.StartsWith("夏目")).ToList();
            }
        }

        // List 13-8
        static void DisplayAllBooks()
        {
            var books = GetBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}{book.PublishedYear}");
            }
            Console.ReadLine(); //F5で実行後、一時停止させる
        }

        // List 13-9
        private static void AddAuthors()
        {
            using (var db = new BooksDbContext())
            {
                var author1 = new Author
                {
                    Birthday = new DateTime(1878, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子"
                };
                db.Authors.Add(author1);

                var author2 = new Author
                {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "宮沢賢治"
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }
        }

        // List 13-10
        private static void AddBooks()
        {
            using (var db = new BooksDbContext())
            {
                var author1 = db.Authors.Single(a => a.Name == "与謝野晶子");
                var book1 = new Book
                {
                    Title = "みだれ髪",
                    PublishedYear = 2000,
                    Author = author1,
                };
                db.Books.Add(book1);

                var author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book2 = new Book
                {
                    Title = "銀河鉄道の夜",
                    PublishedYear = 1989,
                    Author = author2,
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

    }
}
