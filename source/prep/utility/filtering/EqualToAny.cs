using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class EqualToAny<T> : IMatchAn<T>
  {
    IList<T> possible_values;

    public EqualToAny(params T[] possible_values)
    {
      this.possible_values = new List<T>(possible_values);
    }

    public bool matches(T item)
    {
      return possible_values.Contains(item);
    }
  }
}