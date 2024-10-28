using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassTaskEnum.Classlar
{
    internal class AppDbContext
    {
        private List<Room> rooms = new List<Room>();
        private List<Hotel> hotels = new List<Hotel>();

        public void AddRoom(Room room)
        {
            rooms.Add(room);

        }

        public void AddHotel(Hotel hotel)
        {
            hotels.Add(hotel);
        }

        public void MakeReservation(int? Id, int customer)
        {
            Room foundedRoom = rooms.Find(x => x.Id == Id);
            if (foundedRoom == null)
            {
                throw new NullReferenceException("Otaq tapilmadi");
            }
        }


        public List<Hotel> GetAllHotels()
        {
            return hotels.ToList();
        }


        public List<Room> GetAllRooms()
        {
            return rooms.ToList();
        }


    }
}
