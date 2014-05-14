using prep.utility.filtering;

namespace prep.utility
{
  public class AlwaysMatches<T> :IMatchAn<T>
  {
    public bool matches(T item)
    {
      return true;
    }
  }
}