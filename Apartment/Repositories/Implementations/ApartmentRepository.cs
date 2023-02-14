using Apartment.Data;
using Microsoft.EntityFrameworkCore;

namespace Apartment.Repositories.Implementations
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly ApartmentsDbContext _context;
        public ApartmentRepository(ApartmentsDbContext context)
        {
            _context = context;
        }

        public async Task<Data.Models.Apartment?> GetByIdAsync(long id)
        {
            return await _context.Apartments.FindAsync(id);
        }

        public async Task<List<Data.Models.Apartment>> GetPaginatedAsync(string? name, int take, int skip)
        {
            var apartmentsQuery = _context.Apartments 
                .Skip(skip)
                .Take(take);

            if (!string.IsNullOrWhiteSpace(name))
            {
                apartmentsQuery = apartmentsQuery.Where(x => x.Name.Contains(name));
            }

            apartmentsQuery = apartmentsQuery.OrderBy(x => x.Name);

            return await apartmentsQuery.ToListAsync();
        }


    }
}
