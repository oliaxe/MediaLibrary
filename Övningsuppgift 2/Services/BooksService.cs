using Microsoft.EntityFrameworkCore;
using Övningsuppgift_2.Data;
using Övningsuppgift_2.Models;


namespace Övningsuppgift_2.Services
{
    public interface IBookService
    {
        Task AddAsync(Books books);
        Task DeleteAsync(Books books);
        Task UpdateAsync(Books books);
        Task<IEnumerable<Books>> GetAllAsync();
    }

    public class BookService : IBookService
    {
        private readonly SqlContext _sqlContext;

        public BookService(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task AddAsync(Books books)
        {
            _sqlContext.Books.Add(books);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Books books)
        {
            _sqlContext.Books.Remove(books);
            await _sqlContext.SaveChangesAsync();

        }
        public async Task UpdateAsync(Books books)
        {

            _sqlContext.Books.Update(books);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Books>> GetAllAsync()
        {
            return await _sqlContext.Books.ToListAsync();
        }
    }
}
