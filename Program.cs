using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace desafioTarget1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            inverteString();
        }

        static void fibonacci(int valor)
        {
            int ultimoValor = 0;
            int valor1 = 1;
            int valor2 = 1;

            while (ultimoValor < valor)
            {
                ultimoValor = valor1 + valor2;
                valor1 = valor2;
                valor2 = ultimoValor;
            }

            if (ultimoValor == valor)
            {
                Console.WriteLine("O número informado pertence à sequência de Fibonacci.");
            } else
            {
                Console.WriteLine("O número informado NÃO pertence à sequência de Fibonacci.");
            }

            Console.ReadKey();
        }

        static void mediaFaturamento()
        {
            List<int> dias = new List<int>();
            List<float> valores = new List<float>();

            int iMenorValor = 0;
            int iMaiorValor = 0;
            float soma = 0;
            float media = 0;
            int nDiasAcimaMedia = 0;

            XmlDocument document = new XmlDocument();
            document.Load("..\\..\\dados.xml");

            XmlNodeList nodes = document.SelectNodes("dados/row");

            foreach (XmlNode node in nodes)
            {
                int d = Convert.ToInt32(node["dia"].InnerText);
                float v = float.Parse(node["valor"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
                dias.Add(d);
                valores.Add(v);
            }

            for (int i = 0; i < dias.Count; i++)
            {
                while (valores[i] == 0)
                {
                    dias.RemoveAt(i);
                    valores.RemoveAt(i);
                    continue;
                }

                soma = soma + valores[i];
            }

            media = soma / valores.Count;
            iMenorValor = valores.FindIndex(item => item == valores.Min(x => x));
            iMaiorValor = valores.FindIndex(item => item == valores.Max(x => x));

            for (int j = 0; j < dias.Count; j++)
            {
                if (valores[j] > media)
                {
                    nDiasAcimaMedia++;
                }
            }

            Console.WriteLine($"O MAIOR valor de faturamento ocorreu no dia {dias[iMaiorValor]} com faturamento de {valores[iMaiorValor]}.");
            Console.WriteLine($"O MENOR valor de faturamento ocorreu no dia {dias[iMenorValor]} com faturamento de {valores[iMenorValor]}.");
            Console.WriteLine($"Houveram {nDiasAcimaMedia} dias nos quais o faturamento superou a média mensal.");

            Console.ReadKey();
        }

        static void faturamentoDistribuidora()
        {
            float saoPaulo = 67836.43F;
            float rioDeJaneiro = 36678.66F;
            float minasGerais = 29229.88F;
            float espiritoSanto = 27165.48F;
            float outros = 19849.53F;


            double calculaPorcent(double valor)
            {
                float total = saoPaulo + rioDeJaneiro + minasGerais + espiritoSanto + outros;
                valor = valor / total * 100;
                valor = Math.Round(valor, 2);
                return valor;
            }

            Console.WriteLine($"São Paulo teve contribuição de {calculaPorcent(saoPaulo)}%.");
            Console.WriteLine($"Rio de Janeiro teve contribuição de {calculaPorcent(rioDeJaneiro)}%.");
            Console.WriteLine($"Minas Gerais teve contribuição de {calculaPorcent(minasGerais)}%.");
            Console.WriteLine($"Espírito Santo teve contribuição de {calculaPorcent(espiritoSanto)}%.");
            Console.WriteLine($"Outros estados tiveram contribuição de {calculaPorcent(outros)}%.");

            Console.ReadKey();
        }

        static void inverteString()
        {
            string entrada = "amarelo";
            string saida = "";
            int tamanho = entrada.Length;

            for (int i = tamanho; i > 0; i--)
            {
                saida += entrada[i-1];
            }

            Console.WriteLine(saida);

            Console.ReadKey();
        }
    }
}
