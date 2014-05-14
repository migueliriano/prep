using System;
using System.Collections;
using System.Collections.Generic;
using prep.utility.filtering;
using prep.utility.Sorting;

namespace prep.utility
{
  public class SortedEnumerable<T> : IEnumerable<T>
  {
    IEnumerable<T> items_to_sort;
    IComparer<T> comparer;

    public SortedEnumerable(IComparer<T> comparer, IEnumerable<T> items_to_sort)
    {
      this.comparer = comparer;
      this.items_to_sort = items_to_sort;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
      return items_to_sort.sort_using(comparer).GetEnumerator();
    }

    public SortedEnumerable<T> then_by<AttributeType>(IGetAnAttributeValue<T, AttributeType> accessor) where AttributeType : IComparable<AttributeType>
    {
      return then_with(Compare<T>.by(accessor));
    }

    public SortedEnumerable<T> then_by<AttributeType>(IGetAnAttributeValue<T, AttributeType> accessor,
      params AttributeType[] values)
    {
      return then_with(Compare<T>.by(accessor, values));
    }

    public SortedEnumerable<T> then_by_descending<AttributeType>(IGetAnAttributeValue<T, AttributeType> accessor)
      where AttributeType : IComparable<AttributeType>
    {
      return then_with(Compare<T>.by_descending(accessor));
    }

    SortedEnumerable<T> then_with(IComparer<T> next_comparer)
    {
      return new SortedEnumerable<T>(comparer.then_by(next_comparer), items_to_sort);
    }
  }
}