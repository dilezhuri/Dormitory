﻿using System;
using System.Collections.Generic;

namespace Dormitory.DAL
{
    public partial class Application
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AnnouncementId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Announcemnt Announcement { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}