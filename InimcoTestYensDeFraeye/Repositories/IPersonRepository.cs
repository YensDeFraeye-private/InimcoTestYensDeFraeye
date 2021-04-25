using DeveloperTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTestAPI.Repositories
{
    public interface IPersonRepository
    {
        Task<PersonInfoModel> GetInfo(PersonModel personModel);
    }
}
