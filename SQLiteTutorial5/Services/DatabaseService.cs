using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteTutorial5.Models;
using SQLite;

namespace SQLiteTutorial5.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Book>().Wait();
        }

        public Task<List<Book>> GetBooksAsync()
        {
            return _database.Table<Book>().OrderByDescending(b => b.CreatedAt).ToListAsync();
        }

        public Task<Book> GetBookIdAsync(int id)
        {
            return _database.Table<Book>().Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveBookAsync(Book book)
        {
            if (book.Id != 0)
                return _database.UpdateAsync(book);
            else
                return _database.InsertAsync(book);
        }
        public Task<int> DeleteBookAsync(Book book)
        {
            return _database.DeleteAsync(book);
        }


    }
}
