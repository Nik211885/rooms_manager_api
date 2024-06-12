using src.Collection;
using src.Data;
using src.Models;

namespace src.Clients.ServicesShared
{
    public class SystemSaveMessage : ISaveMessage
    {
        private RoomsManagerDbConText _dbContext;
        public SystemSaveMessage(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveMessage(int senderId, int receiveId, string mss)
        {
            var ObMss = new Message() { SenderId = senderId, ReceiveId = receiveId, Content = mss, TimeSpan = DateTime.Now};
            if (_dbContext != null)
            {
                await _dbContext.AddAsync(ObMss);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
