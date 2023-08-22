namespace PassON.Models
{
    public class CategoryRespository: ICategoryRepository
    {
        private readonly PassONDbContext _DbContext;

        public CategoryRespository(PassONDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IEnumerable<Category> AllCategories()
        {
            return _DbContext.Categories.OrderBy(c=>c.Name);
        }


    }
}
