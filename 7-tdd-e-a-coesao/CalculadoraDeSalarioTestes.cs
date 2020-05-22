using System;
using Xunit;

namespace tdd_e_a_coesao
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

        [Fact]
        public void DeveCalcularSalarioParaDesenvolvedorComSalarioAcimaDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario desenvolvedor = new Funcionario("Vinicius", 4000.0m, Cargo.DESENVOLVEDOR);

            decimal salario = calculadora.CalculaSalario(desenvolvedor);

            Assert.Equal(4000.0m * 0.8m, salario);
        }

        [Fact]
        public void DeveCalcularSalarioParaDBAsComSalarioAbaixoDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario desenvolvedor = new Funcionario("Vinicius", 1500.0m, Cargo.DBA);

            decimal salario = calculadora.CalculaSalario(desenvolvedor);

            Assert.Equal(1500.0m * 0.85m, salario);
        }

        [Fact]
        public void DeveCalcularSalarioParaDBAsComSalarioAcimaDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario desenvolvedor = new Funcionario("Vinicius", 4500.0m, Cargo.DBA);

            decimal salario = calculadora.CalculaSalario(desenvolvedor);

            Assert.Equal(4500.0m * 0.75m, salario);
        }
    }

    public enum Cargo
    {
        DESENVOLVEDOR,
        DBA,
        TESTADOR
    }

    public class Funcionario
    {
        public string Nome { get; private set; }
        public decimal Salario { get; private set; }
        public Cargo Cargo { get; private set; }

        public Funcionario(string nome, decimal salario, Cargo cargo)
        {
            this.Nome = nome;
            this.Salario = salario;
            this.Cargo = cargo;
        }
    }

    public class CalculadoraDeSalario
    {
        public decimal CalculaSalario(Funcionario funcionario)
        {
            if (funcionario.Cargo == Cargo.DESENVOLVEDOR)
            {
                return dezOuVintePorCentoDeDesconto(funcionario);
            }
            else if (funcionario.Cargo == Cargo.DBA ||
                     funcionario.Cargo == Cargo.TESTADOR)
            {
                return quinzeOuVinteCincoPorCentoDeDesconto(funcionario);
            }

            throw new ArgumentException("Funcionário inválido!");
        }

        private decimal quinzeOuVinteCincoPorCentoDeDesconto(Funcionario funcionario){
            if(funcionario.Salario < 2500) return funcionario.Salario * 0.85m;

            return funcionario.Salario * 0.75m;
        }

        private decimal dezOuVintePorCentoDeDesconto(Funcionario funcionario){
            if(funcionario.Salario > 2500) return funcionario.Salario * 0.80m;

            return funcionario.Salario * 0.9m;
        }

    }
}
