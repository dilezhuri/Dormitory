using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitory.DomainModel;
using Dormitory.DomainModels;


namespace Dormitory
{
    public partial class DormitoryContext : DbContext


    {

       public Db<Students> { get; set;}

       // public DbSet<Announcements> {get; set;}
        //public DbSet<Applications> {get; set;}
        //public DbSet<RoomStudent> {get; set;}
        //public DbSet<Dormitories> { get; set;}
        
       // public DbSet<Rooms>  {get; set;}
       
    }
}
