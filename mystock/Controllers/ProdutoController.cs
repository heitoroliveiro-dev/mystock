using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStockPedidos.Models;
using MyStockProdutos.Models;

namespace MyStockPedidos.Controllers
{
    public class ProdutoController : Controller
    {
        // Lista estática para simular um banco de dados em memória
        private static List<Produto> _produtos = new List<Produto>
        {
            new Produto{
                Id = 1,
                Nome = "Martelo",
                Marca = "Tramontina",
                Descricao = "Martelo bola 400g cabo de madeira",
                PrecoCompra = 15.00m,
                PrecoVenda = 37.00m,
                QuantidadeEstoque = 15,
                UnidadeMedida = UnidadeMedida.Un
            },

            new Produto{
                Id = 2,
                Nome = "Furadeira 1/2 GWS250-S 220v",
                Marca = "Bosch",
                Descricao = "Furadeira com mandril de 1/2 GWS250-S 220v com 850w de potência",
                PrecoCompra = 658.00m,
                PrecoVenda = 859.00m,
                QuantidadeEstoque = 25,
                UnidadeMedida = UnidadeMedida.Un
            }
        };

        private static int _proximoId = 3;

        // Get: Produto
        public IActionResult Index()
        {
            return View(_produtos);
        }

        // Get: Produto/Details/5 (Detalhes de um produto)
        // Details: Exibe os detalhes de um produto específico
        // Parâmetro: id - ID do produto a ser exibido
        public IActionResult Details(int id)
        {
            // A variável produto recebe o primeiro produto da lista que tem o ID igual ao parâmetro id
            // Se não encontrar, retorna NotFound()
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // Get: Produto/Create (Criação de um novo produto)
        // Create: Exibe o formulário para criar um novo produto
        // GET: Produto/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Unidades = new SelectList(Enum.GetValues(typeof(UnidadeMedida)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            // Verifica se o modelo é válido
            // Se for válido, atribui um novo ID, define a data de cadastro e adiciona o produto à lista
            // Em seguida, redireciona para a ação Index
            if (ModelState.IsValid)
            {
                produto.Id = _proximoId++;
                produto.DataCadastro = DateTime.Now;
                _produtos.Add(produto);
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Unidades = new SelectList(Enum.GetValues(typeof(UnidadeMedida)));
            return View(produto);

        }

        // Get: Produto/Edit/5 (Edição de um produto)
        // Edit: Exibe o formulário para editar um produto existente
        // Parâmetro: id - ID do produto a ser editado
        // GET: Produto/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewBag.Unidades = new SelectList(Enum.GetValues(typeof(UnidadeMedida)));

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto)
        {
            // Verifica se o ID do produto no formulário é igual ao ID do produto na lista
            // Se não for, retorna NotFound()
            if (id != produto.Id)
            {
                return NotFound();
            }

            // Verifica se o modelo é válido
            // Se for válido, busca o produto existente na lista pelo ID
            if (ModelState.IsValid)
            {
                var produtoExistente = _produtos.FirstOrDefault(p => p.Id == id);
                if (produtoExistente == null)
                {
                    return NotFound();
                }
                ViewBag.Unidades = new SelectList(Enum.GetValues(typeof(UnidadeMedida)));

                // Atualiza as propriedades do produto existente com os valores do produto editado
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Marca = produto.Marca;
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.PrecoCompra = produto.PrecoCompra;
                produtoExistente.PrecoVenda = produto.PrecoVenda;
                produtoExistente.QuantidadeEstoque = produto.QuantidadeEstoque;
                produtoExistente.UnidadeMedida = produto.UnidadeMedida;
                produtoExistente.EstoqueMinimo = produto.EstoqueMinimo;

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Unidades = new SelectList(Enum.GetValues(typeof(UnidadeMedida)));

            return View(produto);
        }

        // Get: Produto/Delete/5
        public IActionResult Delete(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}