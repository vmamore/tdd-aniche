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
    }

    public class ConversorDeNumeroRomano {
        public int Converte(string numeroEmRomano){
            return 0;
        }
    }
}
