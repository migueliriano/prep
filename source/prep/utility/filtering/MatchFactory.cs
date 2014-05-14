using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class MatchFactory<ItemToMatch, AttributeType> : ICreateMatchers<ItemToMatch, AttributeType>
  {
    AttributeAccessor<ItemToMatch, AttributeType> accessor;

    public MatchFactory(AttributeAccessor<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> equal_to(AttributeType value)
    {
      return equal_to_any(value);
    }

    public IMatchAn<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
      return new AnonymousMatch<ItemToMatch>(x =>
      {
        var possible_values = new List<AttributeType>(values);
        var attribute_value = accessor(x);
        return possible_values.Contains(attribute_value);
      });
    }

    public IMatchAn<ItemToMatch> not_equal_to(AttributeType value)
    {
      return equal_to(value).not();
    }
  }
}