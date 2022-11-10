using OfficeData.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeBusiness.Service
{
  public class ProfileService
    {
        IProfileRepository _profileeditRepository;
        public ProfileService(IProfileRepository profileeditRepository)
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
        public Profile Login(Profile profile)
        {
            return _profileeditRepository.Login(profile);
        }
    }
}
