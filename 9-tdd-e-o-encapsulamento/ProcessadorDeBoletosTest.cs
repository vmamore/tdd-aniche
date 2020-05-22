using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace tdd_e_o_encapsulamento
{
    public class ProcessadorDeBoletosTest
    {
        [Fact]
        public void DeveProcessarPagamentoViaBoletoUnico()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();

            Fatura fatura = new Fatura("Cliente", 150.0m);
            Boleto b1 = new Boleto(150.0m);

            List<Boleto> boletos = new List<Boleto> { b1 };

            processador.Processa(boletos, fatura);

            Assert.Equal(1, fatura.Pagamentos.Count());
            Assert.Equal(150.0m, fatura.Pagamentos.First().Valor);
        }

        public class ProcessadorDeBoletos
        {
            public void Processa(List<Boleto> boletos, Fatura fatura)
            {
                Boleto boleto = boletos.First();
                Pagamento pagamento = new Pagamento(boleto.Valor, MeioDePagamento.BOLETO);

                fatura.Pagamentos.Add(pagamento);
            }
        }

        public class Fatura
        {
            public ICollection<Pagamento> Pagamentos { get; }
            public string Cliente { get; }
            public decimal Valor { get; }

            public Fatura(string cliente, decimal valor)
            {
                this.Cliente = cliente;
                this.Valor = valor;
                this.Pagamentos = new List<Pagamento>();
            }
        }

        public class Boleto
        {
            public decimal Valor { get; }

            public Boleto(decimal valor)
            {
                this.Valor = valor;
            }
        }

        public enum MeioDePagamento
        {
            BOLETO
        }

        public class Pagamento
        {
            public decimal Valor { get; set; }
            public MeioDePagamento MeioDePagamento { get; set; }

            public Pagamento(decimal valor, MeioDePagamento meioDePagamento)
            {
                this.Valor = valor;
                this.MeioDePagamento = meioDePagamento;
            }
        }
    }
}
