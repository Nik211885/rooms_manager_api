using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;
using src.Until;

namespace src.Clients.Admin.ManageRooms
{
    public class CRDRoom : ICRURoom
    {
        private readonly RoomsManagerDbConText _dbContext;
        public CRDRoom(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string?> CreateRoomAsync(Room room)
        {
            if (room == null)
            {
                return "Room not exits";
            }
            var ValR = new ValidateRoom(_dbContext);
            if (await ValR.IsNameRoomUniqueAsync(room.NameRoom))
            {
                return "Name rooms has exits";
            }
            _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
            return null;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            var rooms = await _dbContext.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<dynamic> GetRoomByIdAsync(int id)
        {
            if (id <= 0)
            {
                return ("Room not exits");
            }
            var r = await _dbContext.Rooms.FirstOrDefaultAsync(r=> r.Id == id);
            if(r == null)
            {
                return "Room not exits";
            }
            return r;
        }

        public async Task<string?> UpdateRoomAsync(Room room, int id)
        {
            if (id <= 0)
            {
                return "Room not exits";
            }
            var r = await _dbContext.Rooms.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (r == null)
            {
                return "Room not exits";
            }
            //Map form to r
            r.NameRoom = room.NameRoom;
            r.PriceRoom = room.PriceRoom;
            r.ImageRoom = room.ImageRoom;
            r.Description = room.Description;
            r.Hired = room.Hired;
            _dbContext.Update(r);
            await _dbContext.SaveChangesAsync();
            return null;
        }
    }
}
