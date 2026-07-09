using ProjetoSeguranca.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSeguranca.Tests;

public class ProdutoTests
{
    private List<ValidationResult> ValidarModelo(Produto produto)
    {
        var resultados = new List<ValidationResult>();
        var contexto = new ValidationContext(produto);
        Validator.TryValidateObject(produto, contexto, resultados, true);
        return resultados;
    }

    [Fact]
    public void Produto_NomeVazio_DeveRetornarErro()
    {
        var produto = new Produto { Nome = "", Preco = 10, Quantidade = 1 };
        var erros = ValidarModelo(produto);
        Assert.Contains(erros, e => e.MemberNames.Contains("Nome"));
    }

    [Fact]
    public void Produto_NomePreenchido_NaoDeveRetornarErro()
    {
        var produto = new Produto { Nome = "Mouse", Preco = 10, Quantidade = 1 };
        var erros = ValidarModelo(produto);
        Assert.DoesNotContain(erros, e => e.MemberNames.Contains("Nome"));
    }

    [Fact]
    public void Produto_PrecoNegativo_DeveRetornarErro()
    {
        var produto = new Produto { Nome = "Mouse", Preco = -1, Quantidade = 1 };
        var erros = ValidarModelo(produto);
        Assert.Contains(erros, e => e.MemberNames.Contains("Preco"));
    }

    [Fact]
    public void Produto_PrecoPositivo_NaoDeveRetornarErro()
    {
        var produto = new Produto { Nome = "Mouse", Preco = 10, Quantidade = 1 };
        var erros = ValidarModelo(produto);
        Assert.DoesNotContain(erros, e => e.MemberNames.Contains("Preco"));
    }

    [Fact]
    public void Produto_QuantidadeNegativa_DeveRetornarErro()
    {
        var produto = new Produto { Nome = "Mouse", Preco = 10, Quantidade = -1 };
        var erros = ValidarModelo(produto);
        Assert.Contains(erros, e => e.MemberNames.Contains("Quantidade"));
    }
}