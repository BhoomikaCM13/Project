using OfficeDL.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeBusiness.Services
{
    public class Profileservice
    {
        IProfileRepository _profileEditRepository;
        public Profileservice(IProfileRepository profileEditRepository)
        {
            _profileEditRepository = profileEditRepository;
        }

        // CRUD Service Operations for Profile:
        public void UpdateProfile(Profile profile)
        {
            _profileEditRepository.UpdateProfile(profile);
        }
        public void Register(Profile profile)
        {
            _profileEditRepository.Register(profile);
        }
        public int Login(Profile profile)
        {
            return _profileEditRepository.Login(profile);
        }
        public Profile GetProfileById(int profileId)
        {
            return _profileEditRepository.GetProfileById(profileId);
        }
        public IEnumerable<Profile> GetProfiles()
        {
            return _profileEditRepository.GetProfiles();
        }
    }
}
