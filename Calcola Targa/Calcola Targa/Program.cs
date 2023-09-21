using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Inserisci una targa nel formato AA000AA: ");
        string inputTarga = Console.ReadLine();

        if (IsValidTargaFormat(inputTarga))
        {
            string targaConvertita = ConvertiTarga(inputTarga);
            int valoreTarga = CalcolaValoreTarga(targaConvertita);
            Console.WriteLine($"Il valore della targa convertita {targaConvertita} è: {valoreTarga}");
        }
        else
        {
            Console.WriteLine("Il formato della targa non è valido.");
        }
        Console.ReadKey();
    }

    static bool IsValidTargaFormat(string targa)
    {
        string pattern = "^[A-Z]{2}\\d{3}[A-Z]{2}$";
        return Regex.IsMatch(targa, pattern);
    }

    static string ConvertiTarga(string targa)
    {
        // Converti la targa nel formato "AAAA000".
        return $"{targa.Substring(0, 2)}{targa.Substring(5, 2)}{targa.Substring(2, 3)}";
    }

    static int CalcolaValoreTarga(string targa)
    {
        int valore = 0;

        for (int i = 0; i < targa.Length; i++)
        {
            if (char.IsDigit(targa[i]))
            {
                valore *= 10; // Sistema numerico posizionale.
                valore += targa[i] - '0'; // Converto il carattere numerico in un valore numerico.
            }
            else if (char.IsLetter(targa[i]))
            {
                valore *= 26; // Ci sono 26 lettere nell'alfabeto inglese.
                valore += char.ToUpper(targa[i]) - 'A'; // Converto la lettera in maiuscolo e la trasformo in un valore da 0 a 25.
            }
        }

        return valore;
    }
}
