using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.collections;
using prep.utility.filtering;

namespace prep.utility.Sorting
{
    public class Compare<ItemToSort> 
    {
        public static IComparer<ItemToSort> by_descending<AttributeType>(IGetAnAttributeValue<ItemToSort, AttributeType> value_to_Compare) where AttributeType: IComparable<AttributeType>
        {
            return new AttributeSorting<ItemToSort, AttributeType>(value_to_Compare);
        }
    }
}
