using DeveloperTestAPI.Models;
using DeveloperTestAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }

        /// <summary>
        /// GET: /api/Person/getInfo
        /// </summary>
        /// <param name="personModel"></param>
        /// <returns>returns an ActionResult</returns>
        [HttpPost("getInfo")]
        public async Task<ActionResult<PersonInfoModel>> GetInfo(PersonModel personModel)
        {
            return Ok(await _personRepository.GetInfo(personModel));
        }
    }
}
