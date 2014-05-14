namespace prep.utility.filtering
{
  public delegate AttributeType IGetAnAttributeValue<in ItemToRetrieveAttributeFrom, out AttributeType>(
    ItemToRetrieveAttributeFrom item);

}