namespace PassON.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        IEnumerable<Item> Get(int id);

        IEnumerable<Item> PromotedItem();

    }
}
