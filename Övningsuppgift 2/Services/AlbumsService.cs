using Microsoft.EntityFrameworkCore;
using Övningsuppgift_2.Data;
using Övningsuppgift_2.Models;


namespace Övningsuppgift_2.Services
{
    public interface IAlbumsService
    {
        Task AddAsync(Albums albums);
        Task DeleteAsync(Albums albums);
        Task UpdateAsync(Albums albums);
        Task<IEnumerable<Albums>> GetAllAsync();
    }

    public class AlbumsService : IAlbumsService
    {
        private readonly SqlContext _sqlContext;

        public AlbumsService(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task AddAsync(Albums albums)
        {
            _sqlContext.Albums.Add(albums);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Albums albums)
        {
            _sqlContext.Albums.Remove(albums);
            await _sqlContext.SaveChangesAsync();

        }
        public async Task UpdateAsync(Albums albums)
        {

            _sqlContext.Albums.Update(albums);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Albums>> GetAllAsync()
        {
            return await _sqlContext.Albums.ToListAsync();
        }

    }
}
