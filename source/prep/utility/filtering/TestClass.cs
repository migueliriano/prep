using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using prep.collections;

namespace prep.utility.filtering
{
    public class TestClass<ItemToMatch, AttributeType>
    {
        private readonly IEnumerable<ItemToMatch> items;
        private readonly IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;

        public TestClass(IEnumerable<ItemToMatch> items, IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
        {
            this.items = items;
            this.accessor = accessor;
        }


        public IEnumerable<ItemToMatch> equal_to(AttributeType attribute)
        {
            foreach (var item in items)
            {
                if(accessor(item).Equals(attribute) )
                {
                    yield return item;
                }
            }
        }
    }
}
