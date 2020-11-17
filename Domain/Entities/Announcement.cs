using Domain.Base;
using System;

namespace Domain.Entities
{
    public class Announcement : Entity<int>
    {
        public DateTime DateOne { get; set; }
        public DateTime DateTwo { get; set; }

        public Announcement()
        {

        }

        public int Verify_dates(Announcement announcement)
        {
            if (announcement.DateOne == null || announcement.DateTwo == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}

