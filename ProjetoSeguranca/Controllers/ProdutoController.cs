using Microsoft.AspNetCore.Mvc;
using ProjetoSeguranca.Models;

namespace ProjetoSeguranca.Controllers;

public class ProdutoController : Controller
{
    private static List<Produto> produtos = new List<Produto>();

    public IActionResult Index()
    {
        return View(produtos);
    }

    public IActionResult Criar()
    {
    return View();
    }

    [HttpPost]
    public IActionResult Criar(Produto produto)
    {   
    if (!ModelState.IsValid)
    {
        return View(produto);
    }
    produto.Id = produtos.Count + 1;
    produtos.Add(produto);
    TempData["Sucesso"] = "Produto cadastrado com sucesso!";
    return RedirectToAction("Index");
    }
    
    public IActionResult Deletar(int id)
    {
    var produto = produtos.FirstOrDefault(p => p.Id == id);
    if (produto != null)
    {
        produtos.Remove(produto);
    }
    TempData["Sucesso"] = "Produto excluido com sucesso!";
    return RedirectToAction("Index");
    }
    public IActionResult Editar(int id)
    {
    var produto = produtos.FirstOrDefault(p => p.Id == id);
    return View(produto);
    }

    [HttpPost]
    public IActionResult Editar(Produto produto)
    {
    if (!ModelState.IsValid)
    {
        return View(produto);
    }
    var existente = produtos.FirstOrDefault(p => p.Id == produto.Id);
    if (existente != null)
    {
        existente.Nome = produto.Nome;
        existente.Preco = produto.Preco;
        existente.Quantidade = produto.Quantidade;
    }
    TempData["Sucesso"] = "Produto atualizado com sucesso!";
    return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id)
    {
    var produto = produtos.FirstOrDefault(p => p.Id == id);
    if (produto == null)
    {
            return NotFound();
    }
        return View(produto);
    }
}