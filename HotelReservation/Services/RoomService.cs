using HotelReservation.Areas.Customer.Models;
using HotelReservation.Data;
using HotelReservation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Services
{
    public class RoomService : IRoomService
    {
        private readonly DataContext db;

        public RoomService(DataContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            try
            {
                var roomList = await db.Room.ToListAsync();
                return roomList;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Room> GetRoomByIdAsync(int roomId)
        {
            try
            {
                var room = await db.Room.FindAsync(roomId);
                return room;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task UpdateRoomAsync(Room model)
        {
            try
            {
                db.Room.Update(model);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
 