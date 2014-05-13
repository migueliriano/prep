namespace prep.utility.filtering
{
  public delegate AttributeType AttributeAccessor<ItemToRetrieveAttributeFrom, AttributeType>(
    ItemToRetrieveAttributeFrom item);
}