using BookApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
namespace BookApi.Data

{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().HasData(
			new Book()
			{
				Id = 1,
				Title = "Book nr 1",
				Description = "Book with Id 1",
				AuthorId = 1,
				IsRead = false,
				DateAdded = DateTime.Now,
				Genre = "Kids",

			},
			new Book()
			{
				Id = 2,
				Title = "Book nr 2",
				Description = "Book with Id 2",
				AuthorId = 2,
				IsRead = false,
				DateAdded = DateTime.Now,
				Genre = "Kids"

			});

			modelBuilder.Entity<Author>().HasData(
			new Author()
			{
				AuthorId = 1,
				FirstName = "Fatih",
				LastName = "Ozer",

			},
			new Author()
			{
				AuthorId = 2,
				FirstName = "Hafida",
				LastName = "Gaougaou",
			});
		}
	}
}
