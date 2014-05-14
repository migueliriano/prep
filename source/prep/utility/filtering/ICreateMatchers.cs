namespace prep.utility.filtering
{
  public interface ICreateMatchers<ItemToMatch, AttributeType>
  {
    IMatchAn<ItemToMatch> equal_to(AttributeType value);
    IMatchAn<ItemToMatch> equal_to_any(params AttributeType[] values);
    IMatchAn<ItemToMatch> not_equal_to(AttributeType value);
  }
}