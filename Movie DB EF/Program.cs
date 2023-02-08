using Movie_DB_EF;
using Movie_DB_EF.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Validation;

MovieDbContext dbContext= new MovieDbContext();


//for (int i=0; i < 15; i++)
//{
//    Movie m = new Movie();
//    Console.WriteLine("Title");
//    m.Title = Console.ReadLine();
//    Console.WriteLine("Genre");
//    m.Genre = Console.ReadLine();
//    Console.WriteLine("Runtime");
//    m.Runtime = double.Parse(Console.ReadLine());
//    dbContext.Movies.Add(m);
//}
//dbContext.SaveChanges();
bool runProgram = true;

while (runProgram)
{
    while (true)
    {
        Console.WriteLine("Would you like to view all, by title or by genre?");
        string input = Console.ReadLine().ToLower().Trim();
        if (input.Contains("all"))
        {
            foreach (Movie x in SearchByAll(dbContext))
            {
                Console.WriteLine($"Title: {x.Title} Genre: {x.Genre} Runtime: {x.Runtime}");
            }
            break;
        }
        else if (input.Contains("tit"))
        {
            foreach (Movie x in SearchByTitle(dbContext))
            {
                Console.WriteLine($"Title: {x.Title} Genre: {x.Genre} Runtime: {x.Runtime}");
            }
            break;
        }
        else if (input.Contains("gen"))
        {
            foreach (Movie x in SearchByGenre(dbContext))
            {
                Console.WriteLine($"Title: {x.Title} Genre: {x.Genre} Runtime: {x.Runtime}");
            }
            break;
        }
        else
        {
            Console.WriteLine("Command not recognized. Please type all, title or genre.");
        }
    }
    runProgram = Validation.Validator.GetContinue();
}

static List<Movie> SearchByAll(MovieDbContext context)
{
    List<Movie> x = context.Movies.ToList();
    return x;
}
static List<Movie> SearchByGenre(MovieDbContext context)
{
    List<Movie> x = new List<Movie>();
    while (true)
    {
        Console.WriteLine("Please enter a genre.");
        string input = Console.ReadLine().ToLower().ToLower();
        x = context.Movies.Where(x => x.Genre.ToLower().Trim().Contains(input)).ToList();
        if (x.Count == 0)
        {
            Console.WriteLine("No movies found. Try again.");
        }
        else
        {
            break;
        }
    }
    return x;
}

static List<Movie> SearchByTitle(MovieDbContext context)
{
    List<Movie> x = new List<Movie>();
    while (true)
    {
        Console.WriteLine("Please enter a title.");
        string input = Console.ReadLine().ToLower().ToLower();
        x = context.Movies.Where(x => x.Title.ToLower().Trim().Contains(input)).ToList();
        if (x.Count == 0)
        {
            Console.WriteLine("No movies found. Try again.");
        }
        else
        {
            break;
        }
    }
    return x;
}