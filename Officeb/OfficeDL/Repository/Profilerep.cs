using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeDL.Repository
{
    public class Profilerep : Iprofile
    {
        Office_Context _officecontext;
        public Profilerep(Office_Context context)
        {
            this._officecontext = context;
        }
        public int Login(Profile profiles)
        {
            /*Profile profile = null;
            var result = _officecontext.profile.Where(obj => obj.Email == profiles.Email && obj.Password == profiles.Password).ToList();
            *//*if (result.Count > 0)
            {
                profile = result[0];
            }*//*
            return result.;*/
            Profile pro = null;
            List<Profile> list = new List<Profile>();
            list = _officecontext.profile.ToList();
            foreach(var profile in list)
            {
                if(profile.Email==profiles.Email && profile.Password == profiles.Password)
                {
                    return profile.Id;
                }

                
            }
            return -1;
        }

        public void Register(Profile profile)
        {
            _officecontext.profile.Add(profile);
            _officecontext.SaveChanges();
        }
        public void UpdateProfile(Profile profile)
        {
            _officecontext.Entry(profile).State = EntityState.Modified;
            _officecontext.SaveChanges();
        }
        public Profile GetProfileById(int profileId)
        {
            //return _officecontext.profile.Find(profileId);
            var result = _officecontext.profile.ToList();
            var profile=result.Where(obj=>obj.Id==profileId).FirstOrDefault();
            return profile;
        }
        public IEnumerable<Profile> GetProfiles()
        {
            return _officecontext.profile.ToList();
        }
    }
}
