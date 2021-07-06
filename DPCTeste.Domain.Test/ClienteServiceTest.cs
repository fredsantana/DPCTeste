using DPCTeste.Domain.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPCTeste.Domain.Test
{
    public class ClienteServiceTest
    {
        private ClienteService _clienteService;

        private Models.Cliente cliente = new Models.Cliente()
        {
            Nome = "Teste",
            Endereco = "Rua Teste",
            DataNascimento = DateTime.Now,
            Status = true,
            Contatos = new System.Collections.Generic.List<Models.Contato>
            {
                new Models.Contato
                {
                    TipoCntato = Models.Enum.TipoContato.Celular,
                    Descricao = "12321341"
                },
                new Models.Contato
                {
                    TipoCntato = Models.Enum.TipoContato.Email,
                    Descricao = "teste@teste"
                },
            }
        };

        [SetUp]
        public void Setup()
        {
            _clienteService = new ClienteService();
        }

        [Test]
        public void Add_erro_contact()
        {
            try
            {
                _clienteService.Add(new Models.Cliente());
            }catch(Exception)
            {
                Assert.Pass();
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void Add_sucess()
        {
            var id = 0;
            try
            {
                id = _clienteService.Add(cliente);
                _clienteService.Delete(id);
            }
            catch (Exception)
            {
                Assert.Fail();
                return;
            }
            Assert.IsTrue(id > 0);
        }

        [Test]
        public void get_all_sucess()
        {
            List<Models.Cliente> clientes;
            int id;
            try
            {
                id = _clienteService.Add(cliente);
                clientes = _clienteService.GetAll();
                _clienteService.Delete(id);
            }
            catch (Exception e)
            {
                Assert.Fail();
                return;
            }
            Assert.IsNotNull(clientes.FirstOrDefault(x => x.Id == id));
        }

        [Test]
        public void get_sucess()
        {
            Models.Cliente c;
            int id;
            try
            {
                id = _clienteService.Add(cliente);
                c = _clienteService.Get(id);
                _clienteService.Delete(id);
            }
            catch (Exception e)
            {
                Assert.Fail();
                return;
            }
            Assert.IsNotNull(c);
        }

        [Test]
        public void update_sucess()
        {
            Models.Cliente c;
            int id;
            try
            {
                id = _clienteService.Add(cliente);
                cliente.Nome = "alterado";
                _clienteService.Update(id, cliente);
                c = _clienteService.Get(id);
                _clienteService.Delete(id);
            }
            catch (Exception e)
            {
                Assert.Fail();
                return;
            }
            Assert.IsTrue(c.Nome == "alterado");
        }

        [Test]
        public void ativar_sucess()
        {
            Models.Cliente c;
            int id;
            try
            {
                id = _clienteService.Add(cliente);
                _clienteService.UpdateAtivar(id, false);
                c = _clienteService.Get(id);
                _clienteService.Delete(id);
            }
            catch (Exception e)
            {
                Assert.Fail();
                return;
            }
            Assert.IsFalse(c.Status);
        }

        [Test]
        public void delete_sucess()
        {
            Models.Cliente c;
            int id;
            try
            {
                id = _clienteService.Add(cliente);
                _clienteService.Delete(id);
                c = _clienteService.Get(id);
            }
            catch (Exception e)
            {
                Assert.Fail();
                return;
            }
            Assert.IsNull(c);
        }
    }
}