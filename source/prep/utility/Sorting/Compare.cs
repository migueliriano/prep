using System;
using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility.Sorting
{
  public class Compare<ItemToSort>
  {
    public static IComparer<ItemToSort> by_descending<AttributeType>(
      IGetAnAttributeValue<ItemToSort, AttributeType> value_to_compare) where AttributeType : IComparable<AttributeType>
    {
      return new ReverseComparer<ItemToSort>(by(value_to_compare));
    }

    public static IComparer<ItemToSort> by<AttributeType>(
      IGetAnAttributeValue<ItemToSort, AttributeType> value_to_compare) where AttributeType : IComparable<AttributeType>
    {
      return new AttributeComparer<ItemToSort, AttributeType>(value_to_compare,
        new ComparableAttributeComparer<AttributeType>());
    }

    public static IComparer<ItemToSort> by<AttributeType>(
      IGetAnAttributeValue<ItemToSort, AttributeType> value_to_compare, params AttributeType[] weighting) 
    {
      return new AttributeComparer<ItemToSort, AttributeType>(value_to_compare,
        new WeightedAttributeComparer<AttributeType>(weighting) 
        );
    }
  }

  public static class ComparerExtensions
  {
    public static IComparer<T> then_by<T>(this IComparer<T> first, IComparer<T> second)
    {
      return new CombinedComparer<T>(first, second);
    }

    public static IComparer<T> then_by<T, AttributeType>(this IComparer<T> first, IGetAnAttributeValue<T, AttributeType> accessor) where AttributeType : IComparable<AttributeType>
    {
      return first.then_by(Compare<T>.by(accessor));
    }
  }
}