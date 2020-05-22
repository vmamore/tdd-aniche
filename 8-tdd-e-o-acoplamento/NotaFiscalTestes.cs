using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace tdd_e_o_acoplamento
{
    // god classes: pouca regra de negócio e apenas coordenam o processo de várias classes juntas
    public class NotaFiscalTestes
    {
        [Fact]
        public void DeveGerarNFComValorDeImpostoDescontado()
        {
            Mock<AcaoAposGerarNota> acao1 = new Mock<AcaoAposGerarNota>();
            Mock<AcaoAposGerarNota> acao2 = new Mock<AcaoAposGerarNota>();

            List<AcaoAposGerarNota> listaAcoes = new List<AcaoAposGerarNota>{
                acao1.Object,
                acao2.Object
            };

            GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(listaAcoes);

            Pedido pedido = new Pedido("Mauricio", 1000m, 1);

            NotaFiscal nf = gerador.Gera(pedido);

            Assert.Equal(1000 * 0.94m, nf.Valor);
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

    public class GeradorDeNotaFiscal{

        private List<AcaoAposGerarNota> _acoes;
        private IRelogio _relogio;

        public GeradorDeNotaFiscal(List<AcaoAposGerarNota> acoes) : this(acoes, new RelogioDoSistema()){
        }

        public GeradorDeNotaFiscal(List<AcaoAposGerarNota> acoes, IRelogio relogio){
            _acoes = acoes;
            _relogio = relogio;
        }
        public NotaFiscal Gera(Pedido pedido){
            var notaFiscal = new NotaFiscal(
                pedido.Cliente,
                pedido.ValorTotal * 0.94m,
                _relogio.Hoje()
            );

            foreach(var acao in _acoes)
                acao.Executa(notaFiscal);

            return notaFiscal;
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

    public interface AcaoAposGerarNota{
        void Executa(NotaFiscal nf);
    }

    public interface IRelogio {
        DateTime Hoje();
    }

    public class RelogioDoSistema : IRelogio
    {
        public DateTime Hoje()
        {
            return DateTime.UtcNow;
        }
    }
}
