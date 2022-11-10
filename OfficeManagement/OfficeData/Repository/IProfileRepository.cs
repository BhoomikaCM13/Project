using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeData.Repository
{
   public interface IProfileRepository
    {
        void UpdateProfile(Profile profile);
        void Register(Profile profile);
        Profile Login(Profile profile);
    }
}
