using Microsoft.EntityFrameworkCore;

namespace PassON.Models
{
    public class ItemRepository : IItemRepository
    {

        private readonly PassONDbContext _DbContext;

        public ItemRepository(PassONDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IEnumerable<Item> PromotedItem => throw new NotImplementedException();

        public void CreateItem(SellModel sellModel)
        {
            Item item = new Item { Name = sellModel.Name, ShortDescription = sellModel.ShortDescription, LongDescription = sellModel.LongDescription,
                                   Price=sellModel.Price, CategoryId=sellModel.CategoryId, ImageThumbnailUrl = sellModel.ImageThumbnailUrl, ImageUrl = sellModel.ImageUrl, 
                                   InStock= true, IsPromoted = sellModel.IsPromoted, Category = _DbContext.Categories.SingleOrDefault(c=>c.Id== sellModel.CategoryId)};
            _DbContext.Items.Add(item);
            _DbContext.SaveChanges();
        }

        public Item? Get(int id)
        {
            return _DbContext.Items.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Item> GetAll()
        {
            return _DbContext.Items.Include(c=>c.Category);
        }

        public IEnumerable<Item> SearchItems(string searchQuery)
        {
            return _DbContext.Items.Where(i => i.Name.Contains(searchQuery));
        }

        IEnumerable<Item> IItemRepository.PromotedItem()
        {
            return _DbContext.Items.Where(c => c.IsPromoted);
        }

        

    }
}
