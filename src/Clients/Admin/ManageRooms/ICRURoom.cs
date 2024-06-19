using src.Models;

namespace src.Clients.Admin.ManageRooms
{
    public interface ICRURoom
    {
        /// <summary>
        /// Insert new room in db
        /// </summary>
        /// <param name="room"></param>
        /// <returns>
        /// Return error if result != null otherwise create success new room
        /// </returns>
        Task<string?> CreateRoomAsync(Room room);
        /// <summary>
        /// Update room have id
        /// </summary>
        /// <param name="room"></param>
        ///  <param name="id"></param>
        /// <returns>
        /// Return error if result != null otherwise update success room
        /// </returns>
        Task<string?> UpdateRoomAsync(Room room, int id);
        /// <summary>
        /// Query and get room has id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     Return error if string otherwise object good request
        /// </returns>
        Task<dynamic> GetRoomByIdAsync(int id);
        /// <summary>
        ///  
        /// </summary>
        /// <returns>
        ///     Return all room
        /// </returns>
        Task<IEnumerable<Room>> GetAllRoomsAsync();
    }
}
