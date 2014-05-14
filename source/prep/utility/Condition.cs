using System;
using prep.collections;

namespace prep.utility
{
    public delegate bool Condition<ItemToMatch>(ItemToMatch item);

    public delegate ProductionStudio AtributeCondition<Item>(Item item);
}