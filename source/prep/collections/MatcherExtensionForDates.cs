using System;
using prep.utility.filtering;

namespace prep.collections
{
  public static class MatcherExtensionForDates
  {
    public static IMatchAn<ItemToMatch> greater_than<ItemToMatch>(
      this MatcherCreationExtensionPoint<ItemToMatch, DateTime> extension_point, int year, IGetAnAttributeValue<DateTime, int> date_part_accessor)
    {
        return extension_point.create_from_matcher(
          Match<DateTime>.with_attribute(x => date_part_accessor(x)).greater_than(year));
    }
  }
}