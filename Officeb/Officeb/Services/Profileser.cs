using OfficeDL.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Officeb.Services
{
    public class Profileser
    {
        Iprofile _profileeditRepository;
        public Profileser(Iprofile profileeditRepository)
        {
            this._profileeditRepository = profileeditRepository;
        }
        public void UpdateProfile(Profile profile)
        {
            _profileeditRepository.UpdateProfile(profile);
        }
        public void Register(Profile profile)
        {
            _profileeditRepository.Register(profile);
        }
        public int Login(Profile profile)
        {
            return _profileeditRepository.Login(profile);
        }
        public Profile GetProfileById(int profileId)
        {
            return _profileeditRepository.GetProfileById(profileId);
        }
        public IEnumerable<Profile> GetProfiles()
        {
            return _profileeditRepository.GetProfiles();
        }
    }
}
