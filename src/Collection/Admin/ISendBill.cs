using src.Data;

namespace src.Collection.Admin
{
    public interface ISendBill 
    {
        Task SendBillMonthAsync(int senderId, int receiverId, DateTime dateSendBill, RoomsManagerDbConText dbContext);
        Task SendAllBillInMonthAsync(int senderId, RoomsManagerDbConText dbContext, DateTime dateSendBill);
    }
}
