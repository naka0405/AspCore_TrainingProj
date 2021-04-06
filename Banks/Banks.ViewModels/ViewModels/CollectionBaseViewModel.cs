using System.Collections.Generic;

namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// ViewModel for inheritance with generic collection.   
    /// </summary>
    /// <typeparam name="TView">TView is  generic parametr for viewModel.</typeparam> 
    public class CollectionBaseViewModel<TView> 
    {
        /// <summary>
        /// Gets or sets collection of viewModels.
        /// </summary>
        public List<TView> Items { get; set; }

        /// <summary>
        /// Gets or sets count of the collection.
        /// </summary>
        public int Count => Items.Count;

        /// <summary>
        /// Creates an instance of the CollectionBaseViewModel;
        /// </summary>
        public CollectionBaseViewModel()
        {
            Items = new List <TView>();            
        }

        /// <summary>
        /// Creates an instance of the CollectionBaseViewModel;
        /// </summary>
        /// <param name="collection">List of items with TView type.</param>
        public CollectionBaseViewModel(List<TView> collection)
        {
            Items = collection;           
        }
    }
}
