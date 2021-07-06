using DPCTeste.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DPCTeste.Data
{
    public class ClienteRepository
    {
        public int Add(Cliente cliente)
        {
            using (var dbContext = new Context())
            {
                dbContext.Clientes.Add(cliente);
                dbContext.SaveChanges();
                return cliente.Id;
            }
        }

        public List<Cliente> GetAll()
        {
            using (var dbContext = new Context())
            {
                return dbContext.Clientes.Include(c => c.Contatos).ToList();
            }
        }

        public Cliente Get(int id)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Clientes.Include(c => c.Contatos).FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Cliente> Get(string texto)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Clientes.Include(c => c.Contatos)
                    .Where(x => x.Nome.Contains(texto) || x.Endereco.Contains(texto)).ToList();
            }
        }

        public void Update(int id, Cliente cliente)
        {
            using (var dbContext = new Context())
            {
                var usu = dbContext.Clientes.Include(c => c.Contatos).FirstOrDefault(x => x.Id == id);
                usu.Nome = cliente.Nome;
                usu.Endereco = cliente.Endereco;
                usu.Contatos.Clear();
                foreach (var c in cliente.Contatos)
                {
                    c.Id = 0;
                }
                usu.Contatos.AddRange(cliente.Contatos);
                usu.DataNascimento = cliente.DataNascimento;
                usu.Status = cliente.Status;
                dbContext.SaveChanges();
            }
        }
        
        public void UpdateAtivar(int id, bool ativar)
        {
            using (var dbContext = new Context())
            {
                var usu = dbContext.Clientes.Include(c => c.Contatos).FirstOrDefault(x => x.Id == id);
                foreach (var c in usu.Contatos)
                {
                    dbContext.Entry(c).State = EntityState.Modified;
                }
                usu.Status = ativar;
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var dbContext = new Context())
            {
                var usu = dbContext.Clientes.Include(c => c.Contatos).FirstOrDefault(x => x.Id == id);
                foreach (var c in usu.Contatos)
                {
                    dbContext.Entry(c).State = EntityState.Deleted;
                }
                dbContext.Clientes.Remove(usu);
                dbContext.SaveChanges();
            }
        }
    }
}
