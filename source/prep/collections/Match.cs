using System;
using prep.utility;
using prep.utility.filtering;

namespace prep.collections
{
  public class Match<ItemToMatch>
  {

      private static AtributeCondition<ItemToMatch> baseCondition;



      public static AtributeCondition<ItemToMatch> with_attribute(AtributeCondition<ItemToMatch> atribute)
    {
          baseCondition = atribute;
          return baseCondition;
    }



  }
}