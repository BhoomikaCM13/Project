using Microsoft.EntityFrameworkCore;
using OfficeDL;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Contactus> GetContact()
        {
            #region GET ALL CONTACTS
            return _OfficeDbcontext.contact.ToList();
            #endregion
        }
    }
}
