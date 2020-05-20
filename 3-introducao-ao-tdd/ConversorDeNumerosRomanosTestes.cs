using System;
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
        public int Converte(string numeroEmRomano){
            if(numeroEmRomano.Equals("I")) return 1;
            else if(numeroEmRomano.Equals("V")) return 5;

            return 0;
        }
    }
}
