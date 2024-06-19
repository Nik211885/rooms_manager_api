using Microsoft.EntityFrameworkCore;
using src.Data;

namespace src.Until
{
    public class ValidateRoom
    {
        private readonly RoomsManagerDbConText _dbContext;
        public ValidateRoom(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Check name rooms has exits
        /// </summary>
        /// <param name="nameRoom"></param>
        /// <returns>
        ///     Return true if name room has exits otherwise false
        /// </returns>
        public async Task<bool> IsNameRoomUniqueAsync(string nameRoom) 
        {
            return await _dbContext.Rooms.Where(r => r.NameRoom.Equals(nameRoom)).AnyAsync();
        }
    }
}
