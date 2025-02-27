/*
3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
• O menor valor de faturamento ocorrido em um dia do mês;
• O maior valor de faturamento ocorrido em um dia do mês;
• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

IMPORTANTE:
a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            string caminho = "faturamento.json"; // Ajuste o caminho conforme necessário
            
            // Verifica se o arquivo existe antes de tentar ler
            if (!File.Exists(caminho))
            {
                Console.WriteLine("Erro: O arquivo JSON não foi encontrado.");
                return;
            }

            string json = File.ReadAllText(caminho);

            // Deserializar corretamente o JSON
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Garante que os nomes não diferenciem maiúsculas/minúsculas
            };

            List<FaturamentoDiario> faturamento = JsonSerializer.Deserialize<List<FaturamentoDiario>>(json, options);

            // Verifica se os dados foram carregados corretamente
            if (faturamento == null || faturamento.Count == 0)
            {
                Console.WriteLine("Erro: O JSON está vazio ou inválido.");
                return;
            }

            // Imprimir os dados carregados para depuração
            Console.WriteLine("Lista carregada do JSON:");
            foreach (var item in faturamento)
            {
                Console.WriteLine($"Dia: {item.Dia}, Valor: R${item.Valor:F2}");
            }

            Console.WriteLine("\n--- Iniciando o processamento ---\n");

            // Filtrar dias com faturamento maior que zero
            faturamento = faturamento.Where(f => f.Valor > 0).ToList();

            if (!faturamento.Any())
            {
                Console.WriteLine("Nenhum dia com faturamento disponível para análise.");
                return;
            }

            double menor = faturamento.Min(f => f.Valor);
            double maior = faturamento.Max(f => f.Valor);
            double media = faturamento.Average(f => f.Valor);
            int diasAcimaDaMedia = faturamento.Count(f => f.Valor > media);

            Console.WriteLine($"Menor faturamento: R${menor:F2}");
            Console.WriteLine($"Maior faturamento: R${maior:F2}");
            Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaDaMedia}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}

// Classe para representar os dados do JSON
class FaturamentoDiario
{
    public int Dia { get; set; }
    public double Valor { get; set; }
}
