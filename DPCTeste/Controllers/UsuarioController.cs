using DPCTeste.Domain.Service;
using DPCTeste.Helper;
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
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public int Add([FromBody] Usuario usuario)
        {
            return new UsuarioService().Add(usuario);
        }

        [HttpGet]
        public List<Usuario> GetAll()
        {
            return new UsuarioService().GetAll();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return new UsuarioService().Get(id);
        }

        [HttpPatch("{id}")]
        public void Update(int id, [FromBody] Usuario usuario)
        {
            new UsuarioService().Update(id, usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new UsuarioService().Delete(id);
        }

        [AllowAnonymous]
        [HttpGet("{login}/{senha}/login")]
        public string login(string login, string senha)
        {
            var usuario = new UsuarioService().Login(login, senha);
            if (usuario != null)
                return TokenHelper.GenerateToken(usuario);

            return null;
        }
    }
}
