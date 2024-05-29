using Database.Data;
using Database.Content;

namespace Database
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
            var sorok = File.ReadAllLines(@"\10.csv").Skip(1);
            foreach (var sor in sorok)
            {
                    db.User.Add(new User(sor));
            }
            db.SaveChanges();
        }
        Kiir(db.User);
    }
}
}