﻿using ApiAplication.Configuration;
using ApiAplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAplication.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
        
        
        
        }
    
    
    }
}
