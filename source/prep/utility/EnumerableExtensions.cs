using System.Collections.Generic;
using prep.collections;
using prep.utility.filtering;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (var item in items) yield return item;
    }

    public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items, IComparer<T> comparer )
    {
      var sorted = new List<T>(items);
      sorted.Sort(comparer);
      return sorted;
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, IMatch<T> match)
    {
      foreach (var item in items)
      {
        if (match(item))
        {
          yield return item;
        }
      }
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, IMatchAn<T> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }

    public static TestClass<ItemToMatch, AttributeType> where<ItemToMatch, AttributeType>(this IEnumerable<ItemToMatch> items, IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {

        return new TestClass<ItemToMatch, AttributeType>(items, accessor);

    }
  }
}