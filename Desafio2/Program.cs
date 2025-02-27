/*
2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.

IMPORTANTE: Esse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código;
*/
using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine(FibonacciCheck(num) ? "Pertence à sequência de Fibonacci" : "Não pertence à sequência de Fibonacci");
    }

    static bool FibonacciCheck(int num)
    {
        int a = 0, b = 1, temp;
        while (b < num)
        {
            temp = a + b;
            a = b;
            b = temp;
        }
        return b == num || num == 0;
    }
}
