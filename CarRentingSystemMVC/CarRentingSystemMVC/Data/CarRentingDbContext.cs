﻿namespace CarRentingSystemMVC.Data
{
    using CarRentingSystemMVC.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CarRentingDbContext : IdentityDbContext
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}