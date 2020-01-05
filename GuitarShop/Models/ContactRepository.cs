using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }


        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }
    }
}
