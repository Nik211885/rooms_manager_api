using src.Services.BillsServices;

namespace src.BillCollections
{
    public abstract class BaseBill : IBillCollection
    {
        protected string NameServices { get; set; } = null!;
        protected decimal PriceServices { get; set; }
        protected BaseBill(string nameServices, decimal priceServices, BillsCollectionServices billsServices)
        {
            billsServices.RegristBill(this);
            NameServices = nameServices;
            PriceServices = priceServices;
        }

        public abstract string GetInformationBill();
        public abstract decimal CalculateService();
    }
}
