using DPCTeste.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DPCTeste.Data
{
    public class RoleRepository
    {
        public List<Role> GetAll()
        {
            using (var dbContext = new Context())
            {
                return dbContext.Roles
                    .Include(x => x.Permissions)
                    .ThenInclude(x => x.Permission).ToList();
            }
        }

        public Role Get(string name)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Roles
                    .Include(x => x.Permissions)
                    .ThenInclude(x => x.Permission)
                    .FirstOrDefault(x => x.Name == name);
            }
        }

        public void SetRole(int idUsuariom, int idRole)
        {
            using (var dbContext = new Context())
            {
                dbContext.UsuarioRoles.Add(new UsuarioRole { UsuarioId = idUsuariom, RoleId = idRole });
                dbContext.SaveChanges();
            }
        }
    }
}
