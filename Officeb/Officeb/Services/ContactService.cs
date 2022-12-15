using OfficeData.Repository;
using OfficeDL.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeBusiness.Services
{
    public class ContactService
    {
        IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public void AddContact(Contactus contact)
        {
            _contactRepository.AddContact(contact);
        }
<<<<<<< HEAD
=======
        public IEnumerable<Contactus> GetContacts()
        {
            return _contactRepository.GetContact();
        }
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
    }
}
