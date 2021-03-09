using AspCore_Bank.Entities.Utils;

namespace AspCore_Bank.Entities
{
    public abstract class Account
    {
        protected string _number;
        public int Id { get; set; }
        public string Number { get; set ; }
        public abstract Currencies Currency { get; }
        public abstract string Marking { get;}
        public int ClientId { get; set; }
        public string Client { get; set; }
        public Account(string number)
        {          
            Number = Marking + number;
        }
    }

}
