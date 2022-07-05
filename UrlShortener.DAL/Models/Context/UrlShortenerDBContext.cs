using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.DAL.Models.Entities;

namespace UrlShortener.DAL.Models.Context
{
    public class UrlShortenerDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"filename=../urls.db");
        }

        public DbSet<Url> Urls { get; set; }
    }
}
