using System;
using Xunit;

namespace simplicade_e_baby_steps
{
    public class CalculadoraDeSalarioTestes
    {
        [Fact]
        public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAbaixoDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario desenvolvedor = new Funcionario("Vinicius", 1500.0m, Cargo.DESENVOLVEDOR);

            double salario = calculadora.CalculaSalario(desenvolvedor);

            Assert.Equals(1500.0 * 0.9, salario, 0.00001);
        }
    }

    public enum Cargo {
        DESENVOLVEDOR,
        DBA,
        TESTADOR
    }

    public class Funcionario {
        public string Nome { get; private set; }
        public double Salario { get; private set; }
        public Cargo Cargo { get; private set; }

        public Funcionario(string nome, double salario, Cargo cargo){
            this.Nome = nome;
            this.Salario =salario;
            this.Cargo = cargo;
        }
    }
}
