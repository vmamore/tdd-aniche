using System;
using Xunit;

namespace tdd_e_o_acoplamento
{
    public class NotaFiscalTestes
    {
        [Fact]
        public void DeveGerarNFComValorDeImpostoDescontado()
        {
            GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal();
            Pedido pedido = new Pedido("Mauricio", 1000m, 1);

            NotaFiscal nf = gerador.Gera(pedido);
            Assert.Equals(1000 * 0.94m, nf.Valor);
        }
    }

    public class Pedido {
        public string Cliente { get; set; }
        public decimal ValorTotal { get; set; }
        public int QuantidadeItens { get; set; }

        public Pedido(string cliente, decimal valorTotal, int quantidadeItens) {
            this.Cliente = cliente;
            this.ValorTotal = valorTotal;   
            this.QuantidadeItens = quantidadeItens;
        }
    }

    public class NotaFiscal {
        public string Cliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public NotaFiscal(string cliente, decimal valor, DateTime data){
            this.Cliente = cliente;
            this.Valor=valor;
            this.Data = data;
        }
    }

    public class SAP
    {
        public void Envia(NotaFiscal nf){

        }
    }

    public class NFDao {
        public void Persiste(NotaFiscal nf){

        }
    }
}
