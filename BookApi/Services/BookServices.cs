using BookApi.Data;
using BookApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Services
{
	public class BookServices
	{
		private readonly ApplicationDbContext _context;
		public BookServices(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<Book> GetAllBooks()
		{
			return _context.Books.ToList();
		}

		public void AddBook(BookVM book)
		{
			var _book = new Book()
			{
				Title = book.Title,
				Description = book.Description,
				IsRead = book.IsRead,
				DateRead = book.DateRead,
				Rate = book.Rate,
				Genre = book.Genre,
				AuthorId = book.AuthorId,
				DateAdded = book.DateAdded

			};
			_context.Books.Add(_book);
			_context.SaveChanges();
		}

		public Book GetBookById(int bookId)
		{
			var book = _context.Books
				//.Include(i => i.Author)
				.FirstOrDefault(b => b.Id == bookId);
			return book;
		}

		public void DeleteBookById(int id)
		{
			var book = _context.Books.FirstOrDefault(b => b.Id == id);
			if (book != null)
			{
				_context.Books.Remove(book);
				_context.SaveChanges(true);
			}
		}

		public Book UpdateBookById(int bookId, BookVM book)
		{
			var _book = _context.Books.FirstOrDefault(b => b.Id == bookId);

			if (_book != null)
			{
				_book.Title = book.Title;
				_book.Description = book.Description;
				_book.IsRead = book.IsRead;
				_book.DateAdded = book.DateAdded;
				_book.Rate = book.Rate;
				_book.Genre = book.Genre;
				_book.AuthorId = book.AuthorId;
				_book.DateRead = book.DateRead;
				_context.SaveChanges();
			}

			return _book;
		}
	}
}
