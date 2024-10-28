using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTaskEnum.Classlar
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        private static int _id = 0;

        public Hotel(string Hotelname) {
        
            Id = _id++;
            HotelName = Hotelname;       
        }
    }
}
