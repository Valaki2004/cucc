using System;
using Data.Content;
using DB.Worker;
using Microsoft.EntityFrameworkCore;

namespace Program
{
    public class Program
    {
        static void Kiir(IEnumerable<object> szemelyek)
        {
            foreach (var item in szemelyek)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Context db = new Context();

            if (!db.User.Any())
            {
                var sorok = File.ReadAllLines(@"C:\Users\varas\source\repos\cucc\Data\CSV\10.csv").Skip(1);
                foreach (var line in sorok)
                {
                    db.User.Add(new User(line));
                }
                db.SaveChanges();
            }
            Kiir(db.User);
        }
    }
}