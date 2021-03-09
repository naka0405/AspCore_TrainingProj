using AspCore_Bank.Entities.Utils;
using Bank.Entities.Entities;

namespace AspCore_Bank.Entities
{
    public class Account:BaseEntity
    {        
        public string Number { get; set ; }
        public Currencies Currency { get; }
        public int ClientId { get; set; }
        public virtual string Client { get; set; }

        public Account(string number)
        {
            Number = number;
        }
    }
}
