namespace Banks.ViewModels.Models
{
    /// <summary>       
    /// ViewModel for inheritance with general property.     
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }
        
        public BaseViewModel(int id=default)
        {
            this.Id = id;
        }

        public BaseViewModel()
        {

        }
    }
}
