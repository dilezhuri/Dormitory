using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Dormitory.DomainModel;

namespace Dormitory.Services
{
    public class DormitoryServices: DbContext
    {
      // protected readonly DormitoryContext_dbContext;
      public DbSet<Students> Students { get; set; }

    }
}
