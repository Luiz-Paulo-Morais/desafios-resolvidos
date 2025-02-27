/*
5) Escreva um programa que inverta os caracteres de um string.

IMPORTANTE:
a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
b) Evite usar funções prontas, como, por exemplo, reverse;
*/

using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma string para inverter: ");
        string entrada = Console.ReadLine();
        string invertida = InverterString(entrada);
        Console.WriteLine($"String invertida: {invertida}");
    }

    static string InverterString(string str)
    {
        char[] caracteres = str.ToCharArray();
        for (int i = 0, j = caracteres.Length - 1; i < j; i++, j--)
        {
            (caracteres[i], caracteres[j]) = (caracteres[j], caracteres[i]);
        }
        return new string(caracteres);
    }
}
