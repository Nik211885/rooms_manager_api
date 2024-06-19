using src.Collection;
using src.Data;
using src.Models;
namespace src.Services.ServicesShared.MessageServices
{
    public class SystemSaveMessage : ISaveMessage
    {
        public async Task SaveMessage(int senderId, int receiveId, string mss, RoomsManagerDbConText dbContext)
        {
            var ObMss = new Message() { SenderId = senderId, ReceiveId = receiveId, Content = mss, TimeSpan = DateTime.Now};
            if (dbContext != null)
            {
                await dbContext.AddAsync(ObMss);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
