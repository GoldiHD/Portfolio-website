using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioAPI.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        SQLAccess SQL = new SQLAccess();

        [HttpGet]
        public ActionResult<List<Project>> GetProjects()
        {
            return SQL.GetProjects();
        }

        // PUT api/<ProjectController>/5
        [HttpPost]
        public void Put([FromBody] Project value)
        {

        }

    }
}
