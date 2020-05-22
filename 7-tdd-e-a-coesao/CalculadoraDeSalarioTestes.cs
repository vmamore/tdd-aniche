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
            Funcionario desenvolvedor = new Funcionario("Vinicius", 1500.0m, CargoEnum.DESENVOLVEDOR);

            decimal salario = calculadora.CalculaSalario(desenvolvedor);

            Assert.Equal(1500.0m * 0.9m, salario);
        }

        [Fact]
        public void DeveCalcularSalarioParaDesenvolvedorComSalarioAcimaDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario desenvolvedor = new Funcionario("Vinicius", 4000.0m, CargoEnum.DESENVOLVEDOR);

            decimal salario = calculadora.CalculaSalario(desenvolvedor);

            Assert.Equal(4000.0m * 0.8m, salario);
        }

        [Fact]
        public void DeveCalcularSalarioParaDBAsComSalarioAbaixoDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario desenvolvedor = new Funcionario("Vinicius", 1500.0m, CargoEnum.DBA);

            decimal salario = calculadora.CalculaSalario(desenvolvedor);

            Assert.Equal(1500.0m * 0.85m, salario);
        }

        [Fact]
        public void DeveCalcularSalarioParaDBAsComSalarioAcimaDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario desenvolvedor = new Funcionario("Vinicius", 4500.0m, CargoEnum.DBA);

            decimal salario = calculadora.CalculaSalario(desenvolvedor);

            Assert.Equal(4500.0m * 0.75m, salario);
        }
    }

    public enum CargoEnum
    {
        DESENVOLVEDOR,
        DBA,
        TESTADOR
    }

    public class Cargo
    {
        public static Cargo DESENVOLVEDOR
        { get { return new Cargo(new DezOuVintePorCento()); } }
        public static Cargo DBA
        { get { return new Cargo(new QuinzeOuVinteCincoPorcento()); } }
        public static Cargo TESTADOR
        { get { return new Cargo(new QuinzeOuVinteCincoPorcento()); } }
        public IRegraDeCalculo Regra { get; private set; }

        public Cargo(IRegraDeCalculo regra)
        {
            this.Regra = regra;
        }
    }

    public class Funcionario
    {
        public string Nome { get; private set; }
        public decimal Salario { get; private set; }
        public Cargo Cargo { get; private set; }

        public Funcionario(string nome, decimal salario, CargoEnum cargo)
        {
            this.Nome = nome;
            this.Salario = salario;
            this.Cargo = ObterCargo(cargo);
        }

        private Cargo ObterCargo(CargoEnum cargoEnum)
        {
            switch (cargoEnum)
            {
                case CargoEnum.DBA:
                    return Cargo.DBA;
                case CargoEnum.DESENVOLVEDOR:
                    return Cargo.DESENVOLVEDOR;
                case CargoEnum.TESTADOR:
                    return Cargo.TESTADOR;
                default:
                    return null;
            }
        }
    }

    public class CalculadoraDeSalario
    {
        public decimal CalculaSalario(Funcionario funcionario)
        {
            return funcionario.Cargo.Regra.Calcula(funcionario);
        }
    }

    public interface IRegraDeCalculo
    {
        decimal Calcula(Funcionario f);
    }

    public class DezOuVintePorCento : IRegraDeCalculo
    {
        public decimal Calcula(Funcionario funcionario)
        {
            if (funcionario.Salario > 2500) return funcionario.Salario * 0.80m;

            return funcionario.Salario * 0.9m;
        }
    }

    public class QuinzeOuVinteCincoPorcento : IRegraDeCalculo
    {
        public decimal Calcula(Funcionario funcionario)
        {
            if (funcionario.Salario < 2500) return funcionario.Salario * 0.85m;

            return funcionario.Salario * 0.75m;
        }
    }
}
