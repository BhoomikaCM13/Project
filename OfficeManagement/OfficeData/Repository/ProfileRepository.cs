using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeData.Repository
{
   public class ProfileRepository :IProfileRepository
    {
        OfficeDbContext _officecontext;
        public ProfileRepository(OfficeDbContext context)
        {
            this._officecontext = context;
        }
        public Profile Login(Profile profiles)
        {
            Profile profile = null;
            var result = _officecontext.profiles.Where(obj => obj.Email == profiles.Email && obj.Password == profiles.Password).ToList();
            if (result.Count > 0)
            {
                profile = result[0];
            }
            return profiles;
        }

        public void Register(Profile profile)
        {
            _officecontext.profiles.Add(profile);
            _officecontext.SaveChanges();
        }
        public void UpdateProfile(Profile profile)
        {
            _officecontext.Entry(profile).State = EntityState.Modified;
            _officecontext.SaveChanges();
        }

    }
}
