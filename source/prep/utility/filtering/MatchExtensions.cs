using prep.collections;

namespace prep.utility.filtering
{
  public static class MatchExtensions
  {
    public static IMatchAn<ItemToMatch> or<ItemToMatch>(this IMatchAn<ItemToMatch> left,
      IMatchAn<ItemToMatch> right)
    {
      return new OrMatch<ItemToMatch>(left, right);
    }


       public static IMatchAn<Item> equal_to<Item>(this AtributeCondition<Item> atributeCondition, ProductionStudio st)
      {
          AnonymousMatch<Item> match = new AnonymousMatch<Item>(x => atributeCondition(x) == st);
          return match;

      }
  }
}