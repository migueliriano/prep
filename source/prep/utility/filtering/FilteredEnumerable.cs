using System.Collections;
using System.Collections.Generic;
using prep.collections;

namespace prep.utility.filtering
{

  public class FilteredEnumerable<ItemToMatch, AttributeType> : IEnumerable<ItemToMatch>
  {
    IEnumerable<ItemToMatch> items;
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;
    IMatchAn<ItemToMatch> criteria;

    public FilteredEnumerable(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor, IMatchAn<ItemToMatch> criteria,
      IEnumerable<ItemToMatch> items)
    {
      this.accessor = accessor;
      this.criteria = criteria;
      this.items = items;
    }

    public IEnumerable<ItemToMatch> equal_to(AttributeType attribute)
    {
      var criteria = Match<ItemToMatch>.with_attribute(accessor).equal_to(attribute);
      return new FilteredEnumerable<ItemToMatch, AttributeType>(accessor, criteria, items);
    }

    public IEnumerator<ItemToMatch> GetEnumerator()
    {
      return items.all_items_matching(criteria).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}