using prep.utility.filtering;

namespace prep.collections
{
  public class Match<ItemToMatch>
  {
    public static MatcherCreationExtensionPoint<ItemToMatch, AttributeType> with_attribute<AttributeType>(
      IGetAnAttributeValue<ItemToMatch, AttributeType> accessor) 
    {
      return new MatcherCreationExtensionPoint<ItemToMatch, AttributeType>(accessor);
    }
  }
}