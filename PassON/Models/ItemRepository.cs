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

        public IEnumerable<Item> Get(int id)
        {
            return _DbContext.Items.Where(x => x.Id == id);
        }

        public IEnumerable<Item> GetAll()
        {
            return _DbContext.Items.Include(c=>c.Category);
        }

        IEnumerable<Item> IItemRepository.PromotedItem()
        {
            return _DbContext.Items.Where(c => c.IsPromoted);
        }
    }
}
