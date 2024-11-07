using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_console_app_project
{
    internal class Program
    {
        class Room
        {
            public int RoomNumber;
            public bool IsBooked;
            public string GuestName;
            public string PhoneNumber;
            public string Email;
        }

        class Hotel
        {
            private List<Room> rooms = new List<Room>();

            public Hotel(int no_Rooms)
            {
                InitializeRooms(no_Rooms);
            }

            private void InitializeRooms(int no_Rooms)
            {
                for (int i = 1; i <= no_Rooms; i++)
                {
                    rooms.Add(new Room { RoomNumber = i, IsBooked = false });
                }
            }

            public void DisplayAvailableRooms()
            {
                Console.WriteLine("\nAvailable Rooms:");
                foreach (Room room in rooms)
                {
                    if (!room.IsBooked)
                    {
                        Console.WriteLine(" Room " + room.RoomNumber);
                    }
                }
            }

            public void BookRoom()
            {
                Console.Write("\nEnter Room Number to book: ");
                int roomNumber = int.Parse(Console.ReadLine());

                Room room = rooms.Find(r => r.RoomNumber == roomNumber);

                if (room != null && !room.IsBooked)
                {
                    Console.Write("Enter Guest Name: ");
                    room.GuestName = Console.ReadLine();

                    Console.Write("Enter Phone Number: ");
                    room.PhoneNumber = Console.ReadLine();

                    Console.Write("Enter Email: ");
                    room.Email = Console.ReadLine();

                    room.IsBooked = true;
                    Console.WriteLine("Room booked Successfully " + roomNumber);
                }
                else
                {
                    Console.WriteLine("Room is either not available or already booked.");
                }
            }

            public void CheckOutRoom()
            {
                Console.Write("\nEnter Room Number to check out: ");
                int roomNumber = int.Parse(Console.ReadLine());

                bool roomFound = false; 

                foreach (Room room in rooms)
                {
                    if (room.RoomNumber == roomNumber)
                    {
                        roomFound = true;

                        if (room.IsBooked)
                        {
                            Console.WriteLine("\tGuest: " + room.GuestName + "\tPhone: " + room.PhoneNumber + "\tEmail: " + room.Email + " \tChecked Out From Room - " + room.RoomNumber);
                            room.IsBooked = false;
                            room.GuestName = null;
                            room.PhoneNumber = null;
                            room.Email = null;
                        }
                        else
                        {
                            Console.WriteLine("Room is not booked.");
                        }
                        break; 
                    }
                }

                if (!roomFound)
                {
                    Console.WriteLine("Room does not exist.");
                }
            }

            public void ViewGuestDetails()
            {
                Console.WriteLine("\nGuest Details:");
                foreach (Room x in rooms)
                {
                    if (x.IsBooked)
                    {
                        Console.WriteLine("Room :" + x.RoomNumber);
                        Console.WriteLine("Guest Name :" + x.GuestName);
                        Console.WriteLine("Phone Number :" + x.PhoneNumber);
                        Console.WriteLine("Email :" + x.Email);
                        Console.WriteLine("-----------------------------");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Hotel hotel = new Hotel(10);

            while (true)
            {
                Console.WriteLine("\n-------HOTEL MANAGEMENT SYSTEM-------");
                Console.WriteLine();
                Console.WriteLine("\t1. Display Available Rooms");
                Console.WriteLine("\t2. Book a Room");
                Console.WriteLine("\t3. Check-Out from Room");
                Console.WriteLine("\t4. View All Guest Details");
                Console.WriteLine("\t5. Exit");
                Console.WriteLine();
                Console.Write("-------CHOOSE AN OPTION: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        hotel.DisplayAvailableRooms();
                        break;
                    case "2":
                        hotel.BookRoom();
                        break;
                    case "3":
                        hotel.CheckOutRoom();
                        break;
                    case "4":
                        hotel.ViewGuestDetails();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}

