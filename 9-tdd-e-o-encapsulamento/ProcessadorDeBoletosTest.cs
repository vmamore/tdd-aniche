using System;
using Xunit;

namespace tdd_e_o_encapsulamento
{
    public class ProcessadorDeBoletosTest
    {
        [Fact]
        public void DeveProcessarPagamentoViaBoletoUnico()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();

            Fatura fatura = new Fatura("Cliente", 150.0);
            Boleto b1 = new Boleto(150.0);

            List<Boleto> boletos = new List<Boleto> { b1 };

            processador.Processa(boletos, fatura);

            Assert.Equal(1, fatura.Pagamentos.Count());
            Assert.Equal(150.0, fatura.Pagamentos.First().Valor);
        }
    }
}
