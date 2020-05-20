using System;
using System.Collections.Generic;
using Xunit;

namespace introducao_ao_tdd
{
    public class ConversorDeNumeroRomanoTestes
    {
        [Fact]
        public void DeveEntenderOSimboloI()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("I");
            Assert.Equal(1, numero);
        }

        [Fact]
        public void DeveEntenderOSimboloV()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("V");
            Assert.Equal(5, numero);
        }
    }

    public class ConversorDeNumeroRomano {
        private Dictionary<string, int> tabela = new Dictionary<string, int>(){
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };
        public int Converte(string numeroEmRomano){
            return tabela[numeroEmRomano];
        }
    }
}
