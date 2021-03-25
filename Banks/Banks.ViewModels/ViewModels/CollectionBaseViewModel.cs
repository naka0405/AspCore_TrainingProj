using System.Collections.Generic;

namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// ViewModel for inheritance with generic collection.   
    /// </summary>
    /// <summary>       
    /// TView is  generic parametr for viewModel.   
    /// </summary> 
    public class CollectionBaseViewModel<TView> 
    {
        /// <summary>
        /// Gets or sets collection of viewModels.
        /// </summary>
        public List<TView> Items { get; set; }

        /// <summary>
        /// Gets or sets count of collection.
        /// </summary>
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
