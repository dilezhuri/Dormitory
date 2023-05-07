using Dormitory.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitory.BLL
{//ne perditshmeri do ta kemi AnnouncementService
    internal class AnnouncementManagment
    {
        internal static void AddAnnouncement()
        {
            using var context = new DormitoryContext();
            //context = new DormitoryContext();
            Console.WriteLine("Enter announcment title");
            var title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Enter a valit title");
            }
            Console.WriteLine("Enter announcment decsription");
            var description = Console.ReadLine();
            if (String.IsNullOrEmpty(description))
            {
                Console.WriteLine("Desription is required");
            }
            var existingRooms = context.Rooms.ToList();
            foreach (var room in existingRooms)
            {
                Console.WriteLine($"{room.Id}, {room.Name}");
            }
            Console.WriteLine("Enter the room ID:");
            int.TryParse(Console.ReadLine(), out var roomId);

            var roomexist = existingRooms.Any(room => room.Id == roomId);
            if (!roomexist)
            {
                Console.WriteLine($"{roomId}, does not exist!");
                Console.ReadLine();
                return;
            }
            var hasActiveAnnouncmentForRoom = context.Announcemnt
                .Any(x => x.IsActive == true && x.RoomId == roomId);

            _ = context.Announcemnt.Add(new Announcemnt
            {
                Title = title,
                Description = description,
                Published = DateTime.Now,
                IsActive = true,
                RoomId = roomId
            });
            Console.WriteLine($"Your Announcemet {title} is added");

            _ = context.SaveChanges();
        }

        public static void TerminateAnnouncemnt()
        {
            using var context = new DormitoryContext();

            //Enter ID of announcemnts
            //Control if announcement exists
            //if exists update with new information, else ..
            var existingAnnouncements = context.Announcemnt.ToList();
            foreach (var announcemnt in existingAnnouncements)
            {
                Console.WriteLine($"{announcemnt.Id}");
            }
            Console.WriteLine("Enter the announcement ID");
            int.TryParse(Console.ReadLine(), out var announcemnetId);

            var announcementexists = existingAnnouncements
                .FirstOrDefault(Announcemnt => Announcemnt.Id == announcemnetId);
            if (announcementexists == null)
            {
                Console.WriteLine($"{announcemnetId}, does not exist!");
                Console.ReadLine();
                return;
            }

            announcementexists.IsActive= false;

            context.SaveChanges();
        }
    }
}
