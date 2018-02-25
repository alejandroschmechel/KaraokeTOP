using System;
using KaraokeTOP.Models;

namespace KaraokeTOP
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.SongName;
            Item = item;
        }
    }
}
