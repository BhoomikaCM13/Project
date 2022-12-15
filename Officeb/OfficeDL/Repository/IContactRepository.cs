using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeData.Repository
{
    public interface IContactRepository
    {
        //Method Definition for ContactEntity
        void AddContact(Contactus contactUs);
<<<<<<< HEAD
=======
        IEnumerable<Contactus> GetContact();
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
    }
}
