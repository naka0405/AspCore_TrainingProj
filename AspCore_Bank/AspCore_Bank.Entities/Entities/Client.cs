using Bank.Entities.Entities;
using System.Collections.Generic;

namespace AspCore_Bank.Entities
{
    public class Client:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Code { get; set; }
        public List<Account> Accounts { get; set; }

        public Client(string name, string surname, int code)
        {
            Name = name;
            Surname = surname;
            Code = code;
        }
    }
}
