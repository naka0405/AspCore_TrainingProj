using AspCore_Bank.Entities.Utils;

namespace AspCore_Bank.Entities
{
    public class UsdAccount : Account
    {
        public override Currencies Currency => Currencies.Usd;
        public override string Marking => "USD";
        
        public UsdAccount(string number ):base(number)
        {

        }
    }
}
