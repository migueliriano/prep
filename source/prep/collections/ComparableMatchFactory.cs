using System;
using prep.utility.filtering;

namespace prep.collections
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType> where AttributeType : IComparable<AttributeType>
  {
    AttributeAccessor<ItemToMatch, AttributeType> accessor;
    ICreateMatchers<ItemToMatch, AttributeType> original;

    public ComparableMatchFactory(AttributeAccessor<ItemToMatch, AttributeType> accessor, ICreateMatchers<ItemToMatch, AttributeType> original)
    {
      this.accessor = accessor;
      this.original = original;
    }

    public IMatchAn<ItemToMatch> equal_to(AttributeType value)
    {
      return original.equal_to(value);
    }

    public IMatchAn<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
      return original.equal_to_any(values);
    }

    public IMatchAn<ItemToMatch> not_equal_to(AttributeType value)
    {
      return original.not_equal_to(value);
    }

    public IMatchAn<ItemToMatch> greater_than(AttributeType value)
    {
      return new AnonymousMatch<ItemToMatch>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchAn<ItemToMatch> between(AttributeType start, AttributeType end)
    {
      return new AnonymousMatch<ItemToMatch>(x =>
      {
        var value = accessor(x);
        return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
      });
    }
  }
}