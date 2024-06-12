using src.Services.BillsServices;
using src.ServicesSharedSupport;

namespace src.BillCollections
{
    public class BillSimple : BaseBill
    {
        public BillSimple(string nameServices, decimal priceServices, BillsCollectionServices billServices) : base(nameServices, priceServices, billServices)
        {
        }

        public override decimal CalculateService()=>PriceServices;

        public override string GetInformationBill()
        {
            return $"Bill {NameServices} and this month have price is {PriceServices} => this bill = {PriceServices}";
        }
    }
}
