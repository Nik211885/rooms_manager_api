using Microsoft.EntityFrameworkCore;
using src.Clients.ServicesShared;
using src.Collection;
using src.Collection.Admin;
using src.Data;
using src.Services.BillsServices;

namespace src.Clients.Admin.BillServices
{
    public class SendBill : ISendBill
    {
        private RoomsManagerDbConText _dbContext;
        private int _adminId;
        public SendBill(RoomsManagerDbConText dbContext, int adminId)
        {
            _dbContext = dbContext;
            _adminId = adminId;
        }

        public async Task SendAllBillInMonthAsync(int senderId)
        {
            var createBill = new CreateBillServices(_dbContext);
            ISaveMessage saveMss = new SystemSaveMessage(_dbContext);
            var customersId = await _dbContext.Customer.Where(c=>!c.Deleted).Select(c=>c.Id).ToListAsync();
            foreach(var c in customersId)
            {
                var billServices = await createBill.GetBillServices(c, DateTime.Now);
                var mss = billServices.GetInformationBill();
                await saveMss.SaveMessage(_adminId, c, mss);
            }

        }

        public async Task SendBillMonthAsync(int senderId, int receiverId, DateTime dateSendBill)
        {
            var createBill = new CreateBillServices(_dbContext);
            var billServices = await createBill.GetBillServices(receiverId,dateSendBill);
            var message = billServices.GetInformationBill();
            ISaveMessage saveMss = new SystemSaveMessage(_dbContext);
            await saveMss.SaveMessage(_adminId,billServices.GetCustomerId(),message);
        }
    }
}
