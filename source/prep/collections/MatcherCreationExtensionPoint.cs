using prep.utility.filtering;

namespace prep.collections
{
  public class MatcherCreationExtensionPoint<ItemToMatch, AttributeType>
  {
    public IGetAnAttributeValue<ItemToMatch, AttributeType>  accessor { get; private set; }

    public MatcherCreationExtensionPoint(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }
  }
}