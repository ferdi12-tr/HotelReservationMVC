﻿using HotelReservation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Data
{

        public class DataContext : IdentityDbContext<AppUser, AppRole, int>
        {
            public DataContext(DbContextOptions<DataContext> options)
                : base(options)
            {
            }
        }
    
}
