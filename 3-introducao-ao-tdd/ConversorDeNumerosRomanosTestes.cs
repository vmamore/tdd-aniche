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

        [Fact]
        public void DeveEntenderDoisSimbolosComoII()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("II");
            Assert.Equal(2, numero);
        }

        [Fact]
        public void DeveEntenderQuatroSimbolosDoisADoisComoXXII()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("XXII");
            Assert.Equal(22, numero);
        }

        [Fact]
        public void DeveEntenderNumerosComoIX()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("IX");
            Assert.Equal(9, numero);
        }

        [Fact]
        public void DeveEntenderNumerosComoXXIV()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("XXIV");
            Assert.Equal(24, numero);
        }
    }

    public class ConversorDeNumeroRomano {
        private Dictionary<char, int> tabela = new Dictionary<char, int>(){
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        public int Converte(string numeroEmRomano){
            int acumulador = 0;
            int ultimoNumeroADireita = 0;
            for(int i = numeroEmRomano.Length - 1; i >= 0; i--){
                int atual = tabela[numeroEmRomano[i]];
                int multiplicador = 1;
                if(atual < ultimoNumeroADireita) multiplicador = -1;
                acumulador += atual * multiplicador;
                ultimoNumeroADireita = atual;
            }
            return acumulador;
        }
    }
}
