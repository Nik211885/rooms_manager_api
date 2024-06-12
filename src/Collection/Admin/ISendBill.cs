namespace src.Collection.Admin
{
    public interface ISendBill 
    {
        Task SendBillMonthAsync(int senderId, int receiverId, DateTime dateSendBill);
        Task SendAllBillInMonthAsync(int senderId);
    }
}
