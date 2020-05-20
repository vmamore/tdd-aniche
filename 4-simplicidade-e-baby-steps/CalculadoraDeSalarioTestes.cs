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

            decimal salario = calculadora.CalculaSalario(desenvolvedor);

            Assert.Equal(1500.0m * 0.9m, salario);
        }
    }

    public enum Cargo {
        DESENVOLVEDOR,
        DBA,
        TESTADOR
    }

    public class Funcionario {
        public string Nome { get; private set; }
        public decimal Salario { get; private set; }
        public Cargo Cargo { get; private set; }

        public Funcionario(string nome, decimal salario, Cargo cargo){
            this.Nome = nome;
            this.Salario =salario;
            this.Cargo = cargo;
        }
    }

    public class CalculadoraDeSalario {
        public decimal CalculaSalario(Funcionario funcionario){
            return 1350.0m;
        }
    }
}


