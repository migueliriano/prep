using System;

namespace prep.utility.filtering
{
  public class MatchFactory<ItemToMatch, AttributeType>
  {
    AttributeAccessor<ItemToMatch, AttributeType> accessor;

    public MatchFactory(AttributeAccessor<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> equal_to(AttributeType value)
    {
      return new AnonymousMatch<ItemToMatch>(x => accessor(x).Equals(value));
    }

    public IMatchAn<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
      throw new NotImplementedException();
    }
  }
}