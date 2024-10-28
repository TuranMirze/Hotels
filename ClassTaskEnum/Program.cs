using ClassTaskEnum.Classlar;


namespace ClassTaskEnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();


            bool f = false;
            do
            {
                Console.WriteLine("******Menu******");
                Console.WriteLine("0. Cixis");
                Console.WriteLine("1. Sisteme giris");
                Console.WriteLine();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        f = true;
                        Console.WriteLine("Exit");
                        break;
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("1. Hotel yarat");
                        Console.WriteLine("2. Butun Hotelleri gor");
                        Console.WriteLine("3. Hotel sec");
                        Console.WriteLine("0. Exit");
                        Console.WriteLine();
                        string choose1 = Console.ReadLine();
                        Console.WriteLine();

                        switch (choose1)
                        {
                            case "0":
                                f = true;
                                break;
                            case "1":
                                Console.WriteLine("Hotel adini daxil edin: ");
                                string hotelname = Console.ReadLine();

                                try
                                {
                                    Hotel hotel = new Hotel(hotelname);
                                    context.AddHotel(hotel);
                                    Console.WriteLine("Hotel yaradıldı.");

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;

                            case "2":
                                List<Hotel> hotels = context.GetAllHotels();

                                if (hotels.Count > 0)
                                {
                                    Console.WriteLine("Butun Hoteller:");
                                    foreach (var hotel in hotels)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"No: {hotel.Id + 1}, HotelName: {hotel.HotelName}");
                                        Console.WriteLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Heç bir hotel yoxdur.");
                                    Console.WriteLine();
                                }
                                break;

                            case "3":
                                Console.WriteLine("Hotel secin");
                                string HotelName = Console.ReadLine();
                                  
                                bool roomcreate = false;
                                 
                                do
                                {
                                   
                                    Console.WriteLine($"Hotel: {HotelName}");
                                    Console.WriteLine("1. Room yarat");
                                    Console.WriteLine("2. Roomları gor");
                                    Console.WriteLine("3. Rezervasya et");
                                    Console.WriteLine("4. Evvelki menuya qayit.");
                                    Console.WriteLine("0. Exit");

                                    var choose3 = Console.ReadLine();

                                    switch (choose3)
                                    {
                                        case "1":
                                            //do
                                            //{
                                            Console.Write("Otağın adını daxil edin: ");
                                            string roomName = Console.ReadLine();
                                            Console.Write("Otağın qiymətini daxil edin: ");
                                            double roomPrice = double.Parse(Console.ReadLine());
                                            Console.Write("Otağın nece neferlik olacagini secin: ");
                                            int roomCapacity = int.Parse(Console.ReadLine());
                                            //} while (!roomcreate);
                                            try
                                            {
                                                Room room = new Room(roomName, roomPrice, roomCapacity);
                                                context.AddRoom(room);
                                                Console.WriteLine("Yeni otaq yaradildi.");
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                            break;

                                        case "2":
                                            List<Room> rooms = context.GetAllRooms();
                                            if (rooms.Count > 0)
                                            {
                                                foreach (var room in rooms)
                                                {
                                                    Console.WriteLine();
                                                    room.ShowInfo();
                                                    Console.WriteLine();
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Heç bir otaq yoxdur.");
                                                Console.WriteLine();
                                            }
                                            break;

                                        case "3":
                                            //var availableRooms = context.FindAllRoma(x => x.IsAvailable);

                                            Console.Write("Rezervasiya üçün otaq ID-sini daxil edin: ");
                                            int roomId = int.Parse(Console.ReadLine());
                                            Console.Write("Müşteri sayını daxil edin: ");
                                            int customerCount = int.Parse(Console.ReadLine());

                                            try
                                            {
                                                context.MakeReservation(roomId, customerCount);
                                                Console.WriteLine("Rezervasiya edildi");
                                            }
                                            catch (NullReferenceException ex)
                                            {
                                                throw new NullReferenceException(ex.Message);
                                            }
                                            break;

                                        case "4":
                                            roomcreate = true;
                                            break;
                                        case "0":
                                            roomcreate = true;
                                            f = true;
                                            break;
                                    }
                                } while (!roomcreate);

                                break;

                            default:
                                Console.WriteLine("Yuxaridaki secimlerden birini secin");
                                break;
                        }

                        break;
                }

            } while (!f);

        }
    }
}
