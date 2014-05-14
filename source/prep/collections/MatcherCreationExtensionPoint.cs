using prep.utility.filtering;

namespace prep.collections
{
  public class MatcherCreationExtensionPoint<ItemToMatch, AttributeType> : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType>
  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor; 

    public MatcherCreationExtensionPoint(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IProvideAccessToCreateMatchers<ItemToMatch,AttributeType> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint(this);
      }
    }

    class NegatingMatchCreationExtensionPoint : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType>
    {
      IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> original;

      public NegatingMatchCreationExtensionPoint(IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> original)
      {
        this.original = original;
      }

      public IMatchAn<ItemToMatch> create_matcher(IMatchAn<AttributeType> attribute_matcher)
      {
        return original.create_matcher(attribute_matcher).not();
      }
    }

    public IMatchAn<ItemToMatch> create_matcher(IMatchAn<AttributeType> attribute_matcher)
    {
      return new AttributeMatcher<ItemToMatch, AttributeType>(accessor, attribute_matcher);
    }
  }
}