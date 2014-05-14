using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.utility.filtering;

namespace prep.utility.Sorting
{
    class AttributeSorting<ItemToSort, AttributeType> : IComparer<ItemToSort> where AttributeType : IComparable<AttributeType>
    {
        private readonly IGetAnAttributeValue<ItemToSort, AttributeType> _valueToCompare;

        public AttributeSorting(IGetAnAttributeValue<ItemToSort, AttributeType> valueToCompare)
        {
            _valueToCompare = valueToCompare;
        }


        public int Compare(ItemToSort x, ItemToSort y)
        {
            return _valueToCompare(y).CompareTo(_valueToCompare(x));
        }
    }
}
