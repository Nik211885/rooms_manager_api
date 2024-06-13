using src.Data;
using src.Models;
using src.Services.BillsServices;
using src.ServicesSharedSupport;

namespace src.Clients.Admin.BillServices
{
    public class CreateBillServices
    {
        private RoomsManagerDbConText? _dbContext;
        private int _customerId;
        private IEnumerable<ServiceSupport>? _servicesSupport;
        public CreateBillServices(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
            _servicesSupport = SingletonServices.GetIntentServicesProvide(_dbContext);
        }
        public async Task<BillsCollectionServices> GetBillServices(int customerId, DateTime date)
        {
            if (_dbContext != null && _servicesSupport != null && _customerId >0)
            {
                _customerId = customerId;
                var billServices = new BillsCollectionServices(_dbContext,_customerId);
                await AddServices.AddServicesToBillServicesAsync(billServices, _dbContext, _customerId, _servicesSupport, date);
                return billServices;
            }
            else
            {
                throw new Exception("Missing data");
            }
        }
    }
}
