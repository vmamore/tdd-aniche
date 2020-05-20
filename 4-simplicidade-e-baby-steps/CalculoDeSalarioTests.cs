using System;
using Xunit;

namespace simplicade_e_baby_steps
{
    public class CalculoDeSalarioTests
    {
        [Fact]
        public void Test1()
        {

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
