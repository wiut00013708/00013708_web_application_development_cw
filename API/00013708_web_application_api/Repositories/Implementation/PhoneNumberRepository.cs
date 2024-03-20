using _00013708_web_application_api.Data;
using _00013708_web_application_api.Models.Domain;
using _00013708_web_application_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace _00013708_web_application_api.Repositories.Implementation
{
    public class PhoneNumberRepository : IContactRepository<PhoneNumber>
    {
        private readonly ApplicationDbContext _context;

        public PhoneNumberRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task CreateAsync(PhoneNumber number)
        {
            await _context.PhoneNumbers.AddAsync(number);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var numberItem = await _context.PhoneNumbers.FindAsync(id);
            if (numberItem != null)
            {
                _context.PhoneNumbers.Remove(numberItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PhoneNumber>> GetAllAsync()
        {
            return await _context.PhoneNumbers.Include(t => t.contact).ToArrayAsync();
        }

        public async Task<PhoneNumber> GetByIDAsync(int id)
        {
            return await _context.PhoneNumbers.Include(t => t.contact).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(PhoneNumber number)
        {
            _context.Entry(number).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
