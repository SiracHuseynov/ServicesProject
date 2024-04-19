using Core.DataAccessLayer;
using Core.Models;
using Core.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Concretes
{
    public class HotelService : IHotelService
    {
        public void AddHotel(Hotel hotel)
        {
            AppDB.Hotels.Add(hotel);
        }

        public Hotel ChooseHotel(string name)
        {
            return AppDB.Hotels.Find(item => item.Name == name);
        }

        public List<Hotel> GetAllHotels()
        {
            return AppDB.Hotels;
        }
    }
}
