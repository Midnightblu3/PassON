namespace PassON.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        Item? Get(int id);

        IEnumerable<Item> PromotedItem();

        IEnumerable<Item> SearchItems(string searchQuery);

        void CreateItem(SellModel sellModel);
    }
}
