using DPCTeste.Domain.Service;
using DPCTeste.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPCTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;

        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public List<Role> GetAll()
        {
            return new RoleService().GetAll();
        }

        [HttpGet("{name}")]
        public Role Get(string name)
        {
            return new RoleService().Get(name);
        }

        [HttpPatch("{idUsuario}/{idRole}")]
        public void SetRole(int idUsuario, int idRole)
        {
            new RoleService().SetRole(idUsuario, idRole);
        }
    }
}
