using System;
using prep.utility;
using prep.utility.filtering;
using prep.utility.ranges;

namespace prep.collections
{
  public static class MatcherExtensions
  {
    public static IMatchAn<ItemToMatch> equal_to<ItemToMatch, AttributeType>(this MatcherCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static IMatchAn<ItemToMatch> equal_to_any<ItemToMatch, AttributeType>(this MatcherCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, params AttributeType[] values)
    {
      return create_from_matcher(extension_point, new EqualToAny<AttributeType>(values));
    }

    public static IMatchAn<ItemToMatch> not_equal_to<ItemToMatch, AttributeType>(this MatcherCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType value)
    {
      return equal_to(extension_point, value).not();
    }

    public static IMatchAn<ItemToMatch> create_from_condition<ItemToMatch, AttributeType>(this MatcherCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, IMatch<ItemToMatch> condition)
    {
      return new AnonymousMatch<ItemToMatch>(condition);
    }

    public static IMatchAn<ItemToMatch> create_from_matcher<ItemToMatch, AttributeType>(this MatcherCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, IMatchAn<AttributeType> attribute_matcher)
    {
      return new AttributeMatcher<ItemToMatch, AttributeType>(extension_point.accessor, attribute_matcher);
    }

    public static IMatchAn<ItemToMatch> greater_than<ItemToMatch, AttributeType>(this MatcherCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType value) where AttributeType : IComparable<AttributeType>
    {
      return falls_in(extension_point, new RangeWithNoUpperBound<AttributeType>(value));
    }

    public static IMatchAn<ItemToMatch> between<ItemToMatch, AttributeType>(this MatcherCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType start, AttributeType end) where AttributeType : IComparable<AttributeType>
    {
      return falls_in(extension_point, new InclusiveRange<AttributeType>(start, end));
    }
    
    public static IMatchAn<ItemToMatch> falls_in<ItemToMatch, AttributeType>(this MatcherCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, IContainValues<AttributeType> range) where AttributeType : IComparable<AttributeType>
    {
      return create_from_matcher(extension_point, new FallsInRange<AttributeType>(range));
    }
  }
}
