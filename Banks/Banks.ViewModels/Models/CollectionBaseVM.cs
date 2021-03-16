using System.Collections.Generic;

namespace Banks.ViewModels.Models
{
    public class CollectionBaseVM<TView> where TView:BaseViewModel
    {
        public List<TView> Collection { get; set; }
        public int Count { get; set; }

        public CollectionBaseVM()
        {
            Collection = new List <TView>();
            Count = Collection.Count;
        }       
    }
}
