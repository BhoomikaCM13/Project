<<<<<<< HEAD
﻿using OfficeDL;
using OfficeEntity;
using System;
using System.Collections.Generic;
=======
﻿using Microsoft.EntityFrameworkCore;
using OfficeDL;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
using System.Text;

namespace OfficeData.Repository
{
    public class ContactRepository:IContactRepository
    {

        Office_Context _OfficeDbcontext;
        public ContactRepository(Office_Context context)
        {
            _OfficeDbcontext = context;
        }
        public void AddContact(Contactus contactUs)
        {
            #region ADD Contact
            _OfficeDbcontext.contact.Add(contactUs);
            _OfficeDbcontext.SaveChanges();
            #endregion
        }
<<<<<<< HEAD
=======
        public IEnumerable<Contactus> GetContact()
        {
            #region GET ALL CONTACTS
            return _OfficeDbcontext.contact.ToList();
            #endregion
        }
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
    }
}
