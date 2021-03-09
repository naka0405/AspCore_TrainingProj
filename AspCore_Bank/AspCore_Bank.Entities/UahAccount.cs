using AspCore_Bank.Entities.Utils;

namespace AspCore_Bank.Entities
{
    public class UahAccount : Account
    {
        public override Currencies Currency => Currencies.Uah;
        public override string Marking => "UAH";

        public UahAccount(string number) : base(number)
        {

        }
    }
}
