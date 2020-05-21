using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace tdd_design_classes
{
    public class MaiorPrecoTest
    {
        [Fact]
        public void DeveRetornarZeroSeCarrinhoVazio()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            
            MaiorPreco algoritmo = new MaiorPreco();
            decimal valor = algoritmo.Encontra(carrinho);

            Assert.Equal(0, valor);
        }

        [Fact]
        public void DeveRetornarValorDoItemSeCarrinhoCom1Elemento(){
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            carrinho.Adiciona(new Item("Geladeira", 1, 900));

            MaiorPreco algoritmo = new MaiorPreco();
            decimal valor = algoritmo.Encontra(carrinho);

            Assert.Equal(900, valor);
        }
    }

    public class MaiorPreco {
        public decimal Encontra(CarrinhoDeCompras carrinho) {
            if(carrinho.Itens.Count == 0) return 0;
            return carrinho.Itens.First().ValorTotal;
        }
    }

    public class CarrinhoDeCompras
    {
        private List<Item> _itens;
        public IReadOnlyCollection<Item> Itens => _itens.AsReadOnly();

        public CarrinhoDeCompras()
        {
            this._itens = new List<Item>();
        }

        public void Adiciona(Item item)
        {
            _itens.Add(item);
        }
    }

    public class Item
    {
        public string Descricao { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public decimal ValorTotal
        {
            get
            {

                return ValorUnitario * Quantidade;
            }
        }

        public Item(string descricao,
            int quantidade,
            decimal valorUnitario)
        {
            this.Descricao = descricao;
            this.Quantidade = quantidade;
            this.ValorUnitario = valorUnitario;
        }


    }
}
