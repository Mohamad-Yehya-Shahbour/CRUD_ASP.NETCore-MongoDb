using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> _books;
        public DbClient(IOptions<BookStoreDbConfig> bookstoreDbconfig)
        {
            var client = new MongoClient(bookstoreDbconfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDbconfig.Value.Database_Name);
            _books = database.GetCollection<Book>(bookstoreDbconfig.Value.Book_Collection_Name);

        }
        public IMongoCollection<Book> GetBooksCollection()
        {
            return _books;
        }
    }
}
