using Aspnetrun.Data;
using Aspnetrun.Entities;
using System;
using System.Threading.Tasks;

namespace Aspnetrun.Repositories
{
    public class ContactRepository : IContactRepository
    {
        protected readonly AspnetrunContext _dbContext;

        public ContactRepository(AspnetrunContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Contact> SendMessage(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> Subscribe(string address)
        {
            // implement your business logic
            var newContact = new Contact();
            newContact.Email = address;
            newContact.Message = address;
            newContact.Name = address;

            _dbContext.Contacts.Add(newContact);
            await _dbContext.SaveChangesAsync();

            return newContact;
        }
    }
}
