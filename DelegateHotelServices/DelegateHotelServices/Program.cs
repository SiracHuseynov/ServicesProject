using Core.Models;
using Core.Services.Concretes;
using System.Threading.Channels;

namespace DelegateHotelServices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HotelService hotelService = new HotelService();
            RoomService roomService = new RoomService();
            bool check = true;
            bool subCheck = true;
            double price;
            string choice;
            int roomId;
            int personCapacity;
            do
            {
                Console.WriteLine("1.Sisteme Giris");
                Console.WriteLine("0.Exit");
                Console.Write("Secim edin: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("1.Hotel Yarat");
                            Console.WriteLine("2.Butun hotelleri gor ");
                            Console.WriteLine("3.Hotel sec");
                            Console.WriteLine("0.Exit");
                            choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    Console.Write("Hotel adi daxil edin: ");
                                    string name = Console.ReadLine();
                                    Hotel hotel = new Hotel(name);
                                    hotelService.AddHotel(hotel);
                                    break;
                                case "2":
                                    hotelService.GetAllHotels().ForEach(item => Console.WriteLine(item));
                                    break;
                                case "3":
                                    Console.Write("Name daxil edin: ");
                                    name = Console.ReadLine();
                                    hotelService.ChooseHotel(name);

                                    do
                                    {
                                        Console.WriteLine("");
                                        Console.Write("Secim edin: ");
                                        choice = Console.ReadLine();

                                        switch (choice)
                                        {
                                            case "1":
                                                Console.WriteLine("Otag adi daxil edin:");
                                                string roomName = Console.ReadLine();
                                                do
                                                {
                                                    Console.WriteLine("Price daxil edin: ");
                                                }
                                                while (!double.TryParse(Console.ReadLine(), out price));

                                                do
                                                {
                                                    Console.WriteLine("Person capacity daxil edin: ");
                                                }
                                                while (!int.TryParse(Console.ReadLine(), out personCapacity));

                                                Room room = new Room(name, price, personCapacity);
                                                roomService.AddRoom(room);
                                                break;
                                            case "2":
                                                Console.WriteLine("Name daxil edin: ");
                                                roomName = Console.ReadLine();
                                                roomService.GetAll().ForEach(item => Console.WriteLine(item));
                                                break;
                                            case "3":
                                                do
                                                {
                                                    Console.WriteLine("Roomid daxil edin: ");
                                                }
                                                while (!int.TryParse(Console.ReadLine(), out roomId));

                                                do
                                                {
                                                    Console.WriteLine("Person capacity daxil edin: ");
                                                }
                                                while (!int.TryParse(Console.ReadLine(), out personCapacity));

                                                roomService.MakeReservation(roomId, personCapacity);
                                                break;
                                            case "4":
                                                subCheck = false;
                                                break;
                                        }
                                    }
                                    while (subCheck);

                                    break;
                            }

                        }
                        while (subCheck);
                        break;
                    case "0":
                        check = false;
                        break;
                }

            }
            while (check);
        }
    }
}
