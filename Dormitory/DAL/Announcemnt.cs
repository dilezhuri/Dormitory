using System;
using System.Collections.Generic;

namespace Dormitory.DAL
{
    public partial class Announcemnt
    {
        public Announcemnt()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Decpription { get; set; } = null!;
        public DateTime Published { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
