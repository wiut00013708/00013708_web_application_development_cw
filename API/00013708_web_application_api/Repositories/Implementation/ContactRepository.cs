using _00013708_web_application_api.Data;
using _00013708_web_application_api.Models.Domain;
using _00013708_web_application_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace _00013708_web_application_api.Repositories.Implementation
{
    public class ContactRepository : IContactRepository<Contact>
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task CreateAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contactItem = await _context.Contacts.FindAsync(id);
            if (contactItem != null)
            {
                _context.Contacts.Remove(contactItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToArrayAsync();
        }

        public async Task<Contact> GetByIDAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task UpdateAsync(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
