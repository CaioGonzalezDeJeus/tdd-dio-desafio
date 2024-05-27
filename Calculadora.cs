using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTalents
{
    public class Calculadora
    {
        private List<string> listaHistorico; //declarando uma lista pro nosso histórico
        private DateTime data;

        public Calculadora(DateTime data)
        {
            listaHistorico = new List<string>(); //toda vez que eu instanciar a classe calculadora então, a lista já vai ser inicializada
            this.data = data;
        }

        //as 5 regras de negócio exigidas
        public int somar(int val1, int val2)
        {
            int resultado = val1 + val2;
            //        (posição que eu quero inserir, "mensagem" + resultado)         
            listaHistorico.Insert(0, "Resultado: " + resultado + " - Data: " + data); //inserindo valo assim(empurrando os numeros pra traz, os 3 primeiros da lista, são as 3 ultimas operações que eu fiz
            return resultado;

            //return val1 + val2;
        }
        public int subtrair(int val1, int val2)
        {
            int resultado = val1 - val2;
            listaHistorico.Insert(0, "Resultado: " + resultado + " - Data: " + data);
            return resultado;
        }
        public int multiplicar(int val1, int val2)
        {
            int resultado = val1 * val2;
            listaHistorico.Insert(0, "Resultado: " + resultado + " - Data: " + data);
            return resultado;
        }
        public int dividir(int val1, int val2)
        {
            int resultado = val1 / val2;
            listaHistorico.Insert(0, "Resultado: " + resultado + " - Data: " + data);
            return resultado;
        }
        public List<string> historico()
        {
            //List<string> res;   // lista pra gente armazenar, n precisa inicializar, mas o debaixo já retorna uma lista, então n vamos precisar dele

            //          (aPartirDeQualQueroRemover, tamanho da lista), assim vai deixar os 3 primeiros da lista e remover todo o resto desnecessario
            listaHistorico.RemoveRange(3, listaHistorico.Count -3); // remover da lista, todos aqueles que eu preciso, nesse caso só vamos deixar os 3 primeiros
            //-3 é pq, se eu tenho 5 no histórico, o 5 n existe pq começa no 0, então eu temovo esses que eu vou usar

            return listaHistorico;
        }
    }
}
