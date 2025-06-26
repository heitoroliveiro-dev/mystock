using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStockClientes.Models;

namespace MyStockClientes.Controllers
{
    public class ClienteController : Controller
    {
        // Lista estática para simular um banco de dados em memória
        private static List<Cliente> _clientes = new List<Cliente>
        {
            new Cliente{
                Id = 1,
                NomeRazaoSocial = "Heitor",
                Tipo = TipoCliente.Fisica,
                CpfCnpj = "13803702640",
                Telefone = "31992765449",
                Email = "heitoroliveiro@outlook.com",
                Endereco = "Rua Paineiras, 1839 - Eldorado, Contagem",
                Status = StatusCliente.Ativo
            },

            new Cliente{
                Id = 2,
                NomeRazaoSocial = "Tatiana",
                Tipo = TipoCliente.Fisica,
                CpfCnpj = "14956625655",
                Telefone = "31992765449",
                Email = "taticomendode4@outlook.com",
                Endereco = "Rua Paineiras, 1839 - Eldorado, Contagem",
                Status = StatusCliente.Ativo
            }
        };

        // Unicidade e sequência de cadastro
        private static int _proximoId = 3;

        //Get: Index
        public IActionResult Index()
        {
            return View(_clientes);
        }

        // Get: Details
        public IActionResult Details(int id)
        {
            // Recebe o código do cliente e consulta se não é == null
            var cliente = _clientes.FirstOrDefault(p => p.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // Get: Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Tipos = new SelectList(Enum.GetValues(typeof(TipoCliente)));
            return View();
        }

        // Get: Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cliente = _clientes.FirstOrDefault(p => p.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewBag.Tipos = new SelectList(Enum.GetValues(typeof(TipoCliente)));
            return View(cliente);
        }

        // Get: Delete
        public IActionResult Delete(int id)
        {
            var cliente = _clientes.FirstOrDefault(p => p.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
            return RedirectToAction(nameof(Index));
        }


        // Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = _proximoId++;
                cliente.DataCadastro = DateTime.Now;
                _clientes.Add(cliente);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Tipos = new SelectList(Enum.GetValues(typeof(TipoCliente)));
            return View(cliente);
        }

        // Post: Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            // Verifica se o Id do cliente em formulário é igual ao Id do cliente em editar 
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var clienteExistente = _clientes.FirstOrDefault(p => p.Id == id);
                if (clienteExistente == null)
                {
                    return NotFound();
                }

                ViewBag.Tipos = new SelectList(Enum.GetValues(typeof(TipoCliente)));

                clienteExistente.NomeRazaoSocial = cliente.NomeRazaoSocial;
                clienteExistente.Tipo = cliente.Tipo;
                clienteExistente.CpfCnpj = cliente.CpfCnpj;
                clienteExistente.Telefone = cliente.Telefone;
                clienteExistente.Email = cliente.Email;
                clienteExistente.Endereco = cliente.Endereco;
                clienteExistente.Status = cliente.Status;

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Tipos = new SelectList(Enum.GetValues(typeof(TipoCliente)));
            return View(cliente);
        }

        [HttpPost]
        public IActionResult AlterarStatus(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                cliente.Status = cliente.Status == StatusCliente.Ativo ? StatusCliente.Inativo : StatusCliente.Ativo;
            }
            return RedirectToAction("Edit", new { id });
        }
    }
}
