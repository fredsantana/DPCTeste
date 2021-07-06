using DPCTeste.Data;
using DPCTeste.Models;
using System.Collections.Generic;

namespace DPCTeste.Domain.Service
{
    public class RoleService
    {
        private RoleRepository Repository { get; set; }

        public RoleService()
        {
            Repository = new RoleRepository();
        }

        public List<Role> GetAll()
        {
            return Repository.GetAll();
        }
        
        public Role Get(string nome)
        {
            return Repository.Get(nome);
        }

        public void SetRole(int idUsuario, int idRole)
        {
            Repository.SetRole(idUsuario, idRole);
        }
    }
}
