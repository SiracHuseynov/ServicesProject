using Core.DataAccessLayer;
using Core.Exceptions;
using Core.Models;
using Core.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Concretes
{
    public class RoomService : IRoomService
    {
        public void AddRoom(Room room)
        {
            AppDB.Rooms.Add(room);
        }

        public List<Room> FindAllRooms(Predicate<Room> predicate)
        {
            return AppDB.Rooms.FindAll(predicate);
        }

        public List<Room> GetAll()
        {
            return AppDB.Rooms;
        }

        public void MakeReservation(int? roomId, int personCapacity)
        {
            if(roomId == null) { throw new NullReferenceException("Room id not found!"); }
            Room room = AppDB.Rooms.FirstOrDefault(item => item.Id == roomId);
            if(room == null) { throw new NullReferenceException("RoomId it not found"); }

            if(room.PersonCapacity < personCapacity)
            {
                throw new NotAviableException("Person capacity limiti asildi!");
            }

            room.IsAviable = true;

        }
    }
}
