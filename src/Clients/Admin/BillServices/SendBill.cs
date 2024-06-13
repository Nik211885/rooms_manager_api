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
        public async Task SendAllBillInMonthAsync(int senderId, RoomsManagerDbConText dbContext, DateTime dateSendBill)
        {
            var createBill = new CreateBillServices(dbContext);
            ISaveMessage saveMss = new SystemSaveMessage();
            BillsCollectionServices? billServices;
            var customersId = await dbContext.Customer.Where(c=>!c.Deleted).Select(c=>c.Id).ToListAsync();
            foreach(var c in customersId)
            {
                billServices = await createBill.GetBillServices(c, dateSendBill);
                var mss = billServices.GetInformationBill();
                await saveMss.SaveMessage(senderId, c, mss,dbContext);
            }

        }
        public async Task SendBillMonthAsync(int senderId, int receiverId, DateTime dateSendBill, RoomsManagerDbConText dbContext)
        {
            var createBill = new CreateBillServices(dbContext);
            var billServices = await createBill.GetBillServices(receiverId,dateSendBill);
            var message = billServices.GetInformationBill();
            ISaveMessage saveMss = new SystemSaveMessage();
            await saveMss.SaveMessage(senderId,receiverId,message, dbContext);
        }
    }
}
