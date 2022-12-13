using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDL.Repository
{
    public interface IProfileRepository
    {
        //Method Definition's for ProfileEntity
        void UpdateProfile(Profile profile);
        void Register(Profile profile);
        int Login(Profile profile);
        Profile GetProfileById(int profileId);
        IEnumerable<Profile> GetProfiles();
    }
}
