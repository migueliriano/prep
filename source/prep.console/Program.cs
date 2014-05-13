using System.Collections.Generic;
using System.Linq;
using prep.collections;

namespace prep.console
{
  class Program
  {
    static void Main(string[] args)
    {
      var movies = new List<Movie>();
      var library = new MovieLibrary(movies);

      Enumerable.Range(1, 1000).ToList().ForEach(x =>
      {
        library.add(new Movie
        {
          title = x.ToString("Title 0")
        });
      });

      var results = library.all_movies();
      System.Console.ReadLine();
    }
  }
}