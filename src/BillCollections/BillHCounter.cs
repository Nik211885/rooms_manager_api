using src.Services.Admin.BillsServices;

namespace src.BillCollections
{
    public class BillHCounter : BaseBill
    {
        private int _counter;
        public BillHCounter(string nameServices, decimal priceServices, int counter, BillsCollectionServices billServices) : base(nameServices, priceServices, billServices)
        {
            _counter = counter;
        }

        public override decimal CalculateService() => _counter * PriceServices;

        public override string GetInformationBill()
        {
            return $"Bill {NameServices} have {_counter} number and this month 1 counter {NameServices} have price is {PriceServices} total bill {NameServices} = {CalculateService()}";
        }
    }
}
