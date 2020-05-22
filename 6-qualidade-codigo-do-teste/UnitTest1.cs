using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace qualidade_codigo_do_teste
{
    public class MaiorPrecoTest
    {
        private CarrinhoDeCompras _carrinho;
        public MaiorPrecoTest(){
            _carrinho = new CarrinhoDeCompras();
        }

        [Fact]
        public void DeveRetornarZeroSeCarrinhoVazio()
        {
            decimal valor = _carrinho.MaiorValor();

            Assert.Equal(0, valor);
        }

        [Fact]
        public void DeveRetornarValorDoItemSeCarrinhoCom1Elemento()
        {
            _carrinho.Adiciona(new Item("Geladeira", 1, 900));

            decimal valor = _carrinho.MaiorValor();

            Assert.Equal(900, valor);
        }

        [Fact]
        public void DeveRetornarMaiorValorSeCarrinhoContemMuitosElementos()
        {
            _carrinho.Adiciona(new Item("Geladeira", 1, 900));
            _carrinho.Adiciona(new Item("Fogão", 1, 1500));
            _carrinho.Adiciona(new Item("Maquina de Lavar", 1, 750));

            decimal valor = _carrinho.MaiorValor();

            Assert.Equal(1500, valor);
        }
    }

    public class MaiorPreco {
        public decimal Encontra(CarrinhoDeCompras carrinho) {
            if(carrinho.Itens.Count == 0) return 0;
            decimal maior = carrinho.Itens.First().ValorTotal;
            foreach(var item in carrinho.Itens){
                if(maior < item.ValorTotal)
                    maior = item.ValorTotal;
            }
            return maior;
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

        public decimal MaiorValor(){
            if(_itens.Count == 0) return 0;
            decimal maior = _itens.First().ValorTotal;
            foreach(var item in _itens){
                if(maior < item.ValorTotal)
                    maior = item.ValorTotal;
            }
            return maior;
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
