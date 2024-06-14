using Microsoft.EntityFrameworkCore;
using src.BillCollections;
using src.Data;
using src.Models;

namespace src.Services.Admin    .BillsServices
{
    public class AddServices
    {
        /// <summary>
        /// Add All Services with user use 
        /// </summary>
        /// <param name="billServices">Pass Bill and query and add to here</param>
        /// <param name="dbContext">Pass Section make DB</param>
        /// <param name="customerId">BillServices customer's have customerId</param>
        public async static Task AddServicesToBillServicesAsync(BillsCollectionServices billServices, RoomsManagerDbConText dbContext, int customerId, IEnumerable<ServiceSupport> serviceSupports,DateTime date)
        {
            using (dbContext)
            {
                //Add Price Room
                var priceRoom = await dbContext.Rooms.Where(r => r.Id == dbContext.Contracts.Where(c => c.Customer.Id == customerId)
                    .Select(c => c.Room.Id).FirstOrDefault()
                ).Select(r => r.PriceRoom).FirstOrDefaultAsync();
                var roomBill = new BillSimple("Room Service",priceRoom,billServices);
                //Add Water Service and electricity Services
                var defaultService = await dbContext.ServicesBases.Where(r => r.Id == dbContext.Customer.Where(c => c.Id == customerId)
                    .Select(c => c.Id).FirstOrDefault() && r.Date.Month.ToString("MM").Equals(date.ToString("MM").FirstOrDefault())).ToListAsync();
                //Query name and price services
                foreach(var s in defaultService)
                {
                    var InforServicesSupport = serviceSupports.Where(sp => sp.Id == s.ServiceSupport.Id).First();
                    var dfServices = new BillHCounter(InforServicesSupport.NameServices, InforServicesSupport.PriceServices, s.Counter, billServices);
                }
                var customerServices = await dbContext.ServicesCustoms.Where(r => r.Id == dbContext.Customer.Where(c => c.Id == customerId)
                    .Select(c => c.Id).FirstOrDefault() && r.Date.Month.ToString("MM").Equals(date.ToString("MM").FirstOrDefault())).ToListAsync();
                foreach(var s in customerServices)
                {
                    var InforServicesSupport = serviceSupports.Where(sp=>sp.Id == s.ServicesSupport.Id).First();
                    var csServices = new BillSimple(InforServicesSupport.NameServices, InforServicesSupport.PriceServices, billServices);
                }
            }
        }
    }
}
