using prep.utility.filtering;

namespace prep.collections
{
  public interface IProvideAccessToCreateMatchers<ItemToMatch, AttributeType>
  {
    IMatchAn<ItemToMatch> create_matcher(IMatchAn<AttributeType> attribute_matcher);
  }
}