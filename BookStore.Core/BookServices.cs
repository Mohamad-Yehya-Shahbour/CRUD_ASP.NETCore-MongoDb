using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace BookStore.Core
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> _books;

        public BookServices(IDbClient dbClient)
        {
            _books = dbClient.GetBooksCollection();
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void DeleteBook(string id)
        {
            _books.DeleteOne(x => x.Id == id);
        }

        public Book GetBook(string id)
        {
            return _books.Find(x => x.Id == id).First();
        }

        public List<Book> GetBooks()
        {
            return _books.Find(book => true).ToList();
        }

        public Book UpdateBook(Book book)
        {
            GetBook(book.Id);
            _books.ReplaceOne(x => x.Id == book.Id, book);
            return book;
        }
    }
}
