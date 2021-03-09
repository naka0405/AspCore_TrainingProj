using Bank.Entities.Entities;
using Bank.Entities.Utils;

namespace Bank.Entities
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
