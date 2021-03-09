using Bank.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspCore_Bank.Entities
{
    public class Bank:BaseEntity
    {
        public string BankName { get; set; }
        public List<Client> Clients { get; set; }

        public Bank(string bankName)
        {
            BankName = bankName;
        }
    }
}
