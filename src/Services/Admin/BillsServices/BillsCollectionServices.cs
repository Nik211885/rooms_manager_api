using src.BillCollections;
using src.Data;
using System.Text;

namespace src.Services.Admin.BillsServices
{
    public class BillsCollectionServices : IBillCollection
    {
        private int _customerId;
        private List<BaseBill> _bills = [];
        private RoomsManagerDbConText _dbContext;
        public BillsCollectionServices(RoomsManagerDbConText dbContext, int customerId)
        {
            _customerId = customerId;
            _dbContext = dbContext;
        }

        public decimal CalculateService()
        {
            decimal total = 0;
            foreach(var b in _bills)
            {
                total += b.CalculateService();
            }
            return total;
        }

        public string GetInformationBill()
        {
            var NameCustomer = "";
            var NameRoom = "";
            if(_dbContext != null)
            {
                using (_dbContext)
                {
                    NameCustomer = _dbContext.Customer.Where(
                            c=>c.Id == _customerId
                        ).Select(c=>c.FullName).FirstOrDefault();

                    NameRoom = _dbContext.Rooms.Where(
                        r => r.Id == _dbContext.Contracts.Where(
                            c => c.Customer.Id == _customerId
                            ).Select(c => c.Room.Id).FirstOrDefault()
                    ).Select(r=>r.NameRoom).FirstOrDefault();
                }
            }
            StringBuilder sb = new StringBuilder($"Hello {NameCustomer} in room {NameRoom} this month {DateTime.Now} your bills is ");
            foreach (var b in _bills)
            {
                sb.Append(b.GetInformationBill());
            }
            sb.Append($"and total bills = {CalculateService()}");
            return sb.ToString();
        }
        public int GetCustomerId()
        {
            return _customerId;
        }
        public void RegristBill(BaseBill bill)
        {
            _bills.Add(bill);
        }
        public void RemoveBill(BaseBill bill)
        {
            _bills.Remove(bill);
        }
    }
}
