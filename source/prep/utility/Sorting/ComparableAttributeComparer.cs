using System;
using System.Collections.Generic;

namespace prep.utility.Sorting
{
  public class ComparableAttributeComparer<T> : IComparer<T> where T : IComparable<T>
  {
    public int Compare(T x, T y)
    {
      return x.CompareTo(y);
    }
  }

  public class WeightedAttributeComparer<T> : IComparer<T>
  {
    IList<T> values;

    public WeightedAttributeComparer(params T[] values)
    {
      this.values = new List<T>(values);
    }

    public int Compare(T x, T y)
    {
      return values.IndexOf(x).CompareTo(values.IndexOf(y));
    }
  }
}