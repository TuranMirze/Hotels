using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTaskEnum.Classlar
{
    public class Room
    {
        private static int _id = 0;
        public int Id { get;}
        public string RoomName { get; set; }
        public double Price { get; set; }
        public int PersonCapacity { get; set; }
        public bool IsAvailable { get; set; } = true;


        public Room(string name, double price, int personCapacity)
        {
            Id = _id++; 
            RoomName = name;
            Price = price;
            PersonCapacity = personCapacity;
        }

        public string ShowInfo()
        {
            return $"Room ID: {Id}, HotelName: {RoomName}, Price: {Price}, Capacity: {PersonCapacity}, Available: {IsAvailable}";
        }

        public override string ToString()
        {
            return ShowInfo();
        }


    }
}
