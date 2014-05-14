using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility.Sorting
{
  class AttributeComparer<ItemToSort, AttributeType> : IComparer<ItemToSort>
  {
    IGetAnAttributeValue<ItemToSort, AttributeType> accessor;
    IComparer<AttributeType> attribute_comparer;

    public AttributeComparer(IGetAnAttributeValue<ItemToSort, AttributeType> accessor,
      IComparer<AttributeType> attribute_comparer)
    {
      this.accessor = accessor;
      this.attribute_comparer = attribute_comparer;
    }

    public int Compare(ItemToSort x, ItemToSort y)
    {
      var first_value = accessor(x);
      var second_value = accessor(y);

      return attribute_comparer.Compare(first_value, second_value);
    }
  }
}