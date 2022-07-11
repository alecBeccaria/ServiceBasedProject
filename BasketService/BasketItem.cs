public class BasketItem
{
    public int BasketId {get; set;}

    public int ItemId {get; set;}

    public BasketItem(int basketId, int itemId)
    {
        BasketId = basketId;
        ItemId = itemId;
    }

    public BasketItem(){}

    
}