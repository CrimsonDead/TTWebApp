using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TTWebApp.Models;

namespace TTWebApp.DBLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 1,
                Name = "Alex",
                NickName = "SaneKing",
                Age = 12,
                DateOfCreation = new DateTime(2002, 12, 6)
            }, new Author
            {
                Id = 2,
                Name = "Kir",
                NickName = "CrimsonDead",
                Age = 20,
                DateOfCreation = new DateTime(2002, 3, 12)
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 1,
                Name = "Red House",
                Link = "https://ya.cc/t/bvybNZ4V3FerDY",
                Size = 123,
                DateOfCreation = new DateTime(2020, 1, 1),
                AuthorId = 1,
                Cost = 5,
                NumberOfPurchase = 79
            }, new Photo 
            {
                Id = 2,
                Name = "Nature",
                Link = "https://ya.cc/t/Ny1sR0Cl3Ferdt",
                Size = 432,
                DateOfCreation = new DateTime(2021, 11, 6),
                AuthorId = 1,
                Cost = 88,
                NumberOfPurchase = 2
            }, new Photo
            {
                Id = 3,
                Name = "Green field",
                Link = "https://ya.cc/t/75GdCcRs3Ferjc",
                Size = 2234,
                DateOfCreation = new DateTime(2021, 3, 5),
                AuthorId = 2,
                Cost = 44,
                NumberOfPurchase = 1
            });
            modelBuilder.Entity<Text>().HasData(new Text
            {
                Id = 1,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi scelerisque dapibus magna at blandit. Sed efficitur ultricies ipsum eget lobortis. Nullam facilisis porta sapien, in sodales erat commodo eu. Duis nisl velit, pharetra id nisi vel, hendrerit varius massa. Cras pellentesque imperdiet est, at bibendum nisl ullamcorper id. Vestibulum commodo sagittis leo, vel feugiat lorem euismod ac. Praesent ac odio nulla. Sed pharetra et ipsum sit amet accumsan. Aliquam erat volutpat. ",
                Size = 213,
                DateOfCreation = new DateTime(2022, 2, 5),
                Cost = 44,
                AuthorId = 2,
                NumberOfPurchase = 3
            });
        }
    }
}
