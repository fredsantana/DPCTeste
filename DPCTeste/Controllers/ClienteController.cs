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
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public int Add([FromBody] Cliente cliente)
        {
            return new ClienteService().Add(cliente);
        }

        [HttpGet]
        public List<Cliente> GetAll()
        {
            return new ClienteService().GetAll();
        }

        [HttpGet("{texto}/pesquisa")]
        [Authorize(Roles = "ADMIN")]
        public List<Cliente> Get(string texto)
        {
            return new ClienteService().Get(texto);
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return new ClienteService().Get(id);
        }

        [HttpPatch("{id}")]
        public void Update(int id, [FromBody] Cliente cliente)
        {
            new ClienteService().Update(id, cliente);
        }
        
        [HttpPatch("{id}/ativar/{ativar}")]
        public void UpdateAtivar(int id, bool ativar)
        {
            new ClienteService().UpdateAtivar(id, ativar);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ClienteService().Delete(id);
        }
    }
}
