using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeDL.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        Office_Context _officecontext;
        public ProfileRepository(Office_Context context)
        {
            _officecontext = context;
        }

      
        public int Login(Profile profiles)
        {
            #region LOGIN 
            Profile pro = null;
            List<Profile> list = new List<Profile>();
            list = _officecontext.profile.ToList();
            foreach(var profile in list)
            {
                if(profile.email==profiles.email && profile.password == profiles.password)
                {
                    return profile.id;
                }  
            }
            return -1;
            #endregion
        }      
        public void Register(Profile profile)
        {
            #region REGISTER
            _officecontext.profile.Add(profile);
            _officecontext.SaveChanges();
            #endregion
        }
  
        public void UpdateProfile(Profile profile)
        {
            #region EDIT PROFILE AFTER LOGIN 
            _officecontext.Entry(profile).State = EntityState.Modified;
            _officecontext.SaveChanges();
            #endregion
        }
     
        public Profile GetProfileById(int profileId)
        {
            #region GET UNIQUE PROFILE 
            var result = _officecontext.profile.ToList();
            var profile=result.Where(obj=>obj.id==profileId).FirstOrDefault();
            return profile;
            #endregion

        }

        public IEnumerable<Profile> GetProfiles()
        {
            #region GET PROFILES
            return _officecontext.profile.ToList();
            #endregion
        }
    }
}
