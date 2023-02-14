namespace Apartment.Repositories
{
    public interface IApartmentRepository
    {
        Task<List<Apartment.Data.Models.Apartment>> GetPaginatedAsync(string? name, int take, int skip);
        Task<Apartment.Data.Models.Apartment?> GetByIdAsync(long id);
    }
}
