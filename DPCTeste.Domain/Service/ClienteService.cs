using DPCTeste.Data;
using DPCTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPCTeste.Domain.Service
{
    public class ClienteService
    {
        private ClienteRepository Repository { get; set; }

        public ClienteService()
        {
            Repository = new ClienteRepository();
        }

        public int Add(Cliente cliente)
        {
            if (cliente.Contatos == null || cliente.Contatos.Count < 2 || cliente.Contatos.GroupBy(x => x.TipoCntato).Count() <= 1)
                throw new Exception("Cliente deve ter no mínimo 2 contatos diferentes");

            return Repository.Add(cliente);
        }

        public List<Cliente> GetAll()
        {
            return Repository.GetAll();
        }

        public List<Cliente> Get(string texto)
        {
            return Repository.Get(texto);
        }

        public Cliente Get(int id)
        {
            return Repository.Get(id);
        }

        public void Update(int id, Cliente cliente)
        {
            if (cliente.Contatos == null || cliente.Contatos.Count < 2 || cliente.Contatos.GroupBy(x => x.TipoCntato).Count() <= 1)
                throw new Exception("Cliente deve ter no mínimo 2 contatos diferentes");

            Repository.Update(id, cliente);
        }
        
        public void UpdateAtivar(int id, bool ativar)
        {
            Repository.UpdateAtivar(id, ativar);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }
    }
}
