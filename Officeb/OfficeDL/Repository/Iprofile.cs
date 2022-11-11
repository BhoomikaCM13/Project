using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDL.Repository
{
    public interface Iprofile
    {
        void UpdateProfile(Profile profile);
        void Register(Profile profile);
        int Login(Profile profile);
        Profile GetProfileById(int profileid);
        IEnumerable<Profile> GetProfiles();
    }
}
