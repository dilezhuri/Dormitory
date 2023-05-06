using Dormitory.BLL;
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
                    AnnouncementManagment.AddAnnouncement();
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
        


    }

    
}