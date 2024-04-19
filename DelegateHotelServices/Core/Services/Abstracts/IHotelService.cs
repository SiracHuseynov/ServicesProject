using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstracts
{
    public interface IHotelService
    {
        void AddHotel(Hotel hotel);
        List<Hotel> GetAllHotels();
        Hotel ChooseHotel(string name);


    }
}
