using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
    }
}
