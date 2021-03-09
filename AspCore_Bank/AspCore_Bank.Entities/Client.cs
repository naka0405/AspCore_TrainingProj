using System;
using System.Collections.Generic;

namespace AspCore_Bank.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Code { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
