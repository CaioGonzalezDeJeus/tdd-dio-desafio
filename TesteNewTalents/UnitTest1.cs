using NewTalents;

namespace TesteNewTalents
{
    public class UnitTest1
    {
        private readonly Calculadora _calculadora;

        public UnitTest1()
        {
            DateTime data = DateTime.Today;
            _calculadora = new Calculadora(data);
        }
        //public Calculadora construirClasse() //classe pra simplificar instancias que retorna um obj�to calculadora
        //{
        //    DateTime data = DateTime.Today;
        //    _calculadora = new Calculadora(data);

        //    return calculadora;
        //}

        [Theory]              //usando a teoria ele vai devolver nesse caso, 2 resultados de falha
        [InlineData(1, 2, 3)] //1 = valor 1, 2 = valor 2, 3 = resultado esperado
        [InlineData(4, 5, 9)] //testar dnv, porem inserindo outros valores pro teste
        public void TestSomar(int val1, int val2, int resultado) //recebendo os 3 valores acima
        {
            //Arrange
            //Calculadora calc = construirClasse();
            //Calculadora calc = new Calculadora(); // em vez de sempre instanciar aqui dentro, eu tenho um m�todo que faz essa instancia pra mim

            //Act
            int resultadoCalculadora = _calculadora.somar(val1, val2);

            //Assent
            Assert.Equal(resultado, resultadoCalculadora); 
            //com isso podemos fazer nosso teste abrangir mais calulos e podemos fazer "varios testes" de uma s� vez
            //assim j� comparamos o resultado esperado que declaramos com o resultado da calculadora que ele ta puxando
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TestMultiplicar(int val1, int val2, int resultado)
        {
            //Act
            int resultadoCalculadora = _calculadora.multiplicar(val1, val2);

            //Assent
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TestDividir(int val1, int val2, int resultado)
        {
            //Act
            int resultadoCalculadora = _calculadora.dividir(val1, val2);

            //Assent
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)] //assim vai dar um falso positivo
        public void TestSubtrair(int val1, int val2, int resultado)
        {
            //Act
            int resultadoCalculadora = _calculadora.subtrair(val1, val2);

            //Assent
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoPorZero() //regra de neg�cio impl�cita
        {
            //Assent
            //Assert.Throws<Exception>               // vc consegue usar heran�as enquanto executas testes, ent�o vc pode usar s� a exeption comum caso n souber qual usar
            Assert.Throws<DivideByZeroException>(    //tratando exe��o / no caso � a exe��o de divis�o por 0
                () => _calculadora.dividir(3, 0)             //tentativa de dividir por 0
            );
        }

        [Fact]
        public void TestarHistorico()
        {
            //Act
            _calculadora.somar(1, 2); //calculos simulados pra incluir no meu hist�rico e testar ele
            _calculadora.subtrair(3, 2);
            _calculadora.dividir(7, 7);
            _calculadora.multiplicar(8, 2);
            _calculadora.somar(3, 5);

            var lista = _calculadora.historico();

            //Assent
            Assert.NotEmpty(lista);         //vai verificar se essa lista n�o esta vazia
            Assert.Equal(3, lista.Count);   //verificar se a quantidade na lista � igual a 3
                                            //vc pode usar tbm assert.null ou asset.notnull, e n precisa ser t�o organizado assim, mas vamos pegar o costume
        }

        [Theory]
        [InlineData(-1, 2, 1)]
        [InlineData(4, -5, -1)]
        public void TestSomarNegativo(int val1, int val2, int resultado)
        {
            //Act
            int resultadoCalculadora = _calculadora.somar(val1, val2);

            //Assent
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(3, -2, -6)]
        [InlineData(-4, 5, -20)]
        public void TestMultiplicarNegativo(int val1, int val2, int resultado)
        {
            //Act
            int resultadoCalculadora = _calculadora.multiplicar(val1, val2);

            //Assent
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(-6, 2, -3)]
        [InlineData(5, -5, -1)]
        public void TestDividirNegativo(int val1, int val2, int resultado)
        {
            //Act
            int resultadoCalculadora = _calculadora.dividir(val1, val2);

            //Assent
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, -2, 8)]
        [InlineData(-5, 5, -10)]
        public void TestSubtrairNegativo(int val1, int val2, int resultado)
        {
            //Act
            int resultadoCalculadora = _calculadora.subtrair(val1, val2);

            //Assent
            Assert.Equal(resultado, resultadoCalculadora);
        }
    }
}