using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitory.DAL;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.BLL
{
    internal class AplicationManagment
    {
        internal static void AddAplication()
        {
            using var context = new DormitoryContext();
            // to do show all announcement
            Console.WriteLine("List of announcement");
            var existingAnnouncement=context.Announcemnt
                .Include(x=>x.Room)
                .Where(x=>IsAcitve==true)
                .ToList();

            
}
    }
}
