using System;
using System.Collections.Generic;
using Xunit;

namespace testes_de_unidade
{
    public class MaiorMenorTestes
    {
        [Fact]
        public void TestaMaiorEMenor()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            carrinho.Adiciona(new Produto(250.0m, "Liquidificador"));
            carrinho.Adiciona(new Produto(450.0m, "Geladeira"));
            carrinho.Adiciona(new Produto(70.0m, "Jogo de Pratos"));

            MaiorMenor algoritmo = new MaiorMenor();
            algoritmo.Encontra(carrinho);

            Assert.Equal("Jogo de Pratos", algoritmo.Menor.Nome);
            Assert.Equal("Geladeira", algoritmo.Maior.Nome);
        }

        [Fact]
        public void TestaMaiorEMenorQueFalha()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            carrinho.Adiciona(new Produto(450.0m, "Geladeira"));
            carrinho.Adiciona(new Produto(250.0m, "Liquidificador"));
            carrinho.Adiciona(new Produto(70.0m, "Jogo de Pratos"));

            MaiorMenor algoritmo = new MaiorMenor();
            algoritmo.Encontra(carrinho);

            Assert.Equal("Jogo de Pratos", algoritmo.Menor.Nome);
            Assert.Equal("Geladeira", algoritmo.Maior.Nome);
        }
    }

    public class MaiorMenor {
        public Produto Menor {get; private set; }
        public Produto Maior {get; private set; }

        public void Encontra(CarrinhoDeCompras carrinho){
            foreach(var produto in carrinho.Produtos){
                if(Menor == null || produto.Valor < Menor.Valor){
                    Menor = produto;
                } else if (Maior == null || produto.Valor > Maior.Valor){
                    Maior = produto;
                }
            }

        }
    }

    public class CarrinhoDeCompras {
        public List<Produto> Produtos { get; set; }

        public CarrinhoDeCompras(){
            Produtos = new List<Produto>();
        }

        public void Adiciona(Produto produto){
            Produtos.Add(produto);
        }
    }


    public class Produto{
        public decimal Valor { get; set; }
        public string Nome { get; set; }

        public Produto(decimal valor, string nome)
        {
            Valor = valor;
            Nome = nome;
        }
    }
}
