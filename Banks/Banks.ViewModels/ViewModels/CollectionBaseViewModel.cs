using System.Collections.Generic;

namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// viewModel for inheritance with generic collection   
    /// </summary>
    public class CollectionBaseViewModel<TView> 
    {
        public List<TView> Items { get; set; }
        public int Count => Items.Count;

        public CollectionBaseViewModel()
        {
            Items = new List <TView>();            
        }

        public CollectionBaseViewModel(List<TView> collection)
        {
            Items = collection;           
        }
    }
}
