using Dormitory.DAL;

namespace Dormitory;

internal class Program
{
    static void Main(string[] args)
    {
     while(true) 
        {
            Console.WriteLine("Choose one of:");
            Console.WriteLine("New announcement (AA)");
            Console.WriteLine("Edit announcement(EA)");
            Console.WriteLine("New aplication (AAPP)");
            Console.WriteLine("Exit : (ESC)");
             var choise=Console.ReadLine();
           

            switch(choise?.ToUpper()) 
            {
                case "AA":
                    AnnouncementManagment();
                    break;
                case "EA":
                    //TerminateAnnouncement();
                    break;
                case "AAPP":
                    //NewApplication();
                    break;
                case "ESC":
                    Console.WriteLine("Bye Bye");
                    break;
                default:
                    Console.WriteLine("Choise in not valid");
                    Console.ReadLine();
                    break;



            }
        }
        



        AnnouncementManagment();

    }

    private static void AnnouncementManagment()
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


        var hasActiveAnnouncmentForRoom = context.Announcemnts
            .Any(x => x.IsActive == true && x.RoomId == roomId);


        _ = context.Announcemnts.Add(new Announcemnt
        {
            Title = title,
            Description = description,
            Published = DateTime.Now,
            IsActive = true,
            RoomId = roomId
        });

        _ = context.SaveChanges();
    }
}