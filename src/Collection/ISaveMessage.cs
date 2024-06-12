using src.Data;

namespace src.Collection
{
    public interface ISaveMessage
    {
        //Simple way is save in db
        Task SaveMessage(int senderId, int receiveId,string mss);
    }
}
