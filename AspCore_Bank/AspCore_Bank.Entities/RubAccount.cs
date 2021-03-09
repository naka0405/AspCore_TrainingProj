using AspCore_Bank.Entities.Utils;

namespace AspCore_Bank.Entities
{
    public class RubAccount : Account
    {
        public override Currencies Currency => Currencies.Rub;
        public override string Marking => "RUB";

        public RubAccount(string number):base(number)
        {

        }
    }
}
