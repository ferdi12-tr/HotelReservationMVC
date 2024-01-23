using HotelReservation.Areas.Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Services.Interfaces
{
    public interface IRoomService
    {
        public Task<IEnumerable<Room>> GetAllRoomsAsync();
        public Task<Room> GetRoomByIdAsync(int roomId);
        public Task AddRoomAsync(Room room);    
        public Task UpdateRoomAsync(Room model);
    }
}
