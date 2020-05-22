using System;
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
            Mock<NFDao> daoMock = new Mock<NFDao>();
            Mock<SAP> sapMock = new Mock<SAP>();

            GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(daoMock.Object, sapMock.Object);
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

        private NFDao _dao;
        private SAP _sap;

        public GeradorDeNotaFiscal(NFDao dao, SAP sap){
            _dao = dao;
            _sap = sap;
        }
        public NotaFiscal Gera(Pedido pedido){
            var notaFiscal = new NotaFiscal(
                pedido.Cliente,
                pedido.ValorTotal * 0.94m,
                DateTime.UtcNow
            );

            _dao.Persiste(notaFiscal);
            _sap.Envia(notaFiscal);

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
}
