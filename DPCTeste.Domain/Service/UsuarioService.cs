using DPCTeste.Data;
using DPCTeste.Models;
using System.Collections.Generic;

namespace DPCTeste.Domain.Service
{
    public class UsuarioService
    {
        private UsuarioRepository Repository { get; set; }

        public UsuarioService()
        {
            Repository = new UsuarioRepository();
        }

        public int Add(Usuario usuario)
        {
            return Repository.Add(usuario);
        }

        public List<Usuario> GetAll()
        {
            return Repository.GetAll();
        }

        public Usuario Get(int id)
        {
            return Repository.Get(id);
        }

        public void Update(int id, Usuario usuario)
        {
            Repository.Update(id, usuario);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public Usuario Login(string login, string senha)
        {
            return Repository.Login(login, senha);
        }
    }
}
