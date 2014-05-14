namespace prep.utility.filtering
{
  public class AnonymousMatch<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    IMatch<ItemToMatch> match;

    public AnonymousMatch(IMatch<ItemToMatch> match)
    {
      this.match = match;
    }

    public bool matches(ItemToMatch item)
    {
      return match(item);      
    }
  }
}