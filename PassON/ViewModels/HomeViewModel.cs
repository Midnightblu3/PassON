using PassON.Models;

namespace PassON.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Item> PromotedItem { get; }
        public HomeViewModel(IEnumerable<Item> promotedItem)
        {
            PromotedItem = promotedItem;
        }
    }
}
