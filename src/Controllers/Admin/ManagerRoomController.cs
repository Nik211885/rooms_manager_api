using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Clients.Admin.ManageRooms;
using src.Models;

namespace src.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ManagerRoomController : ControllerBase
    {
        private readonly ICRURoom _iCRURoom;
        public ManagerRoomController(ICRURoom iCRURoom)
        {
            _iCRURoom = iCRURoom;
        }
        [HttpGet("id", Name = "GetRoomById")]
        public async Task<ActionResult<Room>> GetRoomByIdAsync(int id)
        {
            var result = await _iCRURoom.GetRoomByIdAsync(id);
            if(result.GetType() == typeof(string))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetRooms",Name = "GetAllRooms")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRoomsAsync()
        {
            var rooms = await _iCRURoom.GetAllRoomsAsync();
            return Ok(rooms);
        }
        [HttpPost("CreateRoom",Name = "CreateNewRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            var result = await _iCRURoom.CreateRoomAsync(room);
            if(result != null)
            {
                return BadRequest(result);
            }
            return Created();
        }
        [HttpPut("UpdateRoom/{id}", Name = "UpdateRoom")]
        public async Task<IActionResult> UpdateRoom([FromBody] Room room, int id)
        {
            var result = await _iCRURoom.UpdateRoomAsync(room, id);
            if(result != null)
            {
                return BadRequest(result);
            }
            return NoContent();
        }
    }
}
