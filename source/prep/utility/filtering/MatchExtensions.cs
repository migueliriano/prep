namespace prep.utility.filtering
{
  public static class MatchExtensions
  {
    public static IMatchAn<ItemToMatch> or<ItemToMatch>(this IMatchAn<ItemToMatch> left,
      IMatchAn<ItemToMatch> right)
    {
      return new OrMatch<ItemToMatch>(left, right);
    }

    public static IMatchAn<ItemToMatch> not<ItemToMatch>(this IMatchAn<ItemToMatch> to_negate)
    {
      return new NegatingMatch<ItemToMatch>(to_negate);
    }
  }
}