using prep.utility.filtering;

namespace prep.collections
{
  public class Match<ItemToMatch>
  {
    public static MatchFactory<ItemToMatch, AttributeType> with_attribute<AttributeType>(
      AttributeAccessor<ItemToMatch, AttributeType> accessor)
    {
      return new MatchFactory<ItemToMatch, AttributeType>(accessor);
    }
  }
}