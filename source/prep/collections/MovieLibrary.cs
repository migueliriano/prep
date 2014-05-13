using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.collections
{
  public class MovieLibrary
  {
    IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (already_contains(movie)) return;

      movies.Add(movie);
    }

    bool already_contains(Movie movie)
    {
      return movies.Contains(movie);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      var result = new List<Movie>();
      foreach (var movie in movies)
      {
        if (movie.production_studio.Equals(ProductionStudio.Pixar))
        {
          result.Add(movie);
        }
      }

      return result;
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      var result = new List<Movie>();
      foreach (var movie in movies)
      {
        if (movie.production_studio.Equals(ProductionStudio.Pixar) ||
            movie.production_studio.Equals(ProductionStudio.Disney))
        {
          result.Add(movie);
        }
      }

      return result;
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      var result = new List<Movie>();
      foreach (var movie in movies)
      {
        if (!movie.production_studio.Equals(ProductionStudio.Pixar))
        {
          result.Add(movie);
        }
      }

      return result;
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      var result = new List<Movie>();
      foreach (var movie in movies)
      {
        if (movie.date_published.Year > year)
        {
          result.Add(movie);
        }
      }

      return result;
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
      var result = new List<Movie>();
      foreach (var movie in movies)
      {
        if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
        {
          result.Add(movie);
        }
      }

      return result;
    }

    public IEnumerable<Movie> all_kid_movies()
    {
      var result = new List<Movie>();
      foreach (var movie in movies)
      {
        if (movie.genre.Equals(Genre.kids))
        {
          result.Add(movie);
        }
      }

      return result;
    }

    public IEnumerable<Movie> all_action_movies()
    {
      var result = new List<Movie>();
      foreach (var movie in movies)
      {
        if (movie.genre.Equals(Genre.action))
        {
          result.Add(movie);
        }
      }

      return result;
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }
}