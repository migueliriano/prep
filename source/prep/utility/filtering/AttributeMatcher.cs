namespace prep.utility.filtering
{
  public class AttributeMatcher<ItemToMatch, AttributeType> : IMatchAn<ItemToMatch>
  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> get_the_value;
    IMatchAn<AttributeType> match_the_value;

    public AttributeMatcher(IGetAnAttributeValue<ItemToMatch, AttributeType> get_the_value,
      IMatchAn<AttributeType> match_the_value)
    {
      this.get_the_value = get_the_value;
      this.match_the_value = match_the_value;
    }

    public bool matches(ItemToMatch item)
    {
      var value = get_the_value(item);
      return match_the_value.matches(value);
    }
  }
}