using BookApi.Data;
using BookApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Services
{
	public class AuthorService
	{
		private readonly ApplicationDbContext _context;
		public AuthorService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<Author> GetAllAuthors()
		{
			return _context.Authors.ToList();
		}

		public void AddAuthor(AuthorVM author)
		{
			var _author = new Author()
			{
				FirstName = author.FirstName,
				LastName = author.LastName

			};
			_context.Authors.Add(_author);
			_context.SaveChanges();
		}

		public Author GetAuthorById(int authorId)
		{
			var author = _context.Authors.FirstOrDefault(b => b.AuthorId == authorId);
			return author;
		}

		public void DeleteAuthorById(int id)
		{
			var author = _context.Authors.FirstOrDefault(b => b.AuthorId == id);
			if (author != null)
			{
				_context.Authors.Remove(author);
				_context.SaveChanges(true);
			}
		}

		public Author UpdateAuthorById(int authorId, AuthorVM author)
		{
			var _author = _context.Authors.FirstOrDefault(b => b.AuthorId == authorId);

			if (_author != null)
			{
				_author.FirstName = author.FirstName;
				_author.LastName = author.LastName;
				_context.SaveChanges();
			}

			return _author;
		}

	}
}
