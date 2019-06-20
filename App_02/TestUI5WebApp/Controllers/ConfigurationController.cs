using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestUI5WebApp.Data;

namespace TestUI5WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : Controller
    {
        private static ConfigurationData m_config = new ConfigurationData();

        [HttpGet]
        public IActionResult Get() => this.Ok(m_config);

        [HttpPut]
        public IActionResult Put([FromBody]ConfigurationData config)
        {
            m_config = config;

            return Ok(config);
        }

        //*********************************************************************
        //*********************************************************************
        //*********************************************************************



    }
}