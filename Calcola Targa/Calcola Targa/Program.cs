using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Console.Write("Inserisci una targa nel formato 'AA000AA': ");
        string targa = Console.ReadLine().ToUpper();

        int valoreTarga = CalcolaValoreTarga(targa);

        Console.WriteLine($"Il valore della targa {targa} è: {valoreTarga}");
        Console.ReadKey();
    }

    static int CalcolaValoreTarga(string targa)
    {
        if (targa.Length != 7)
        {
            Console.WriteLine("Formato di targa non valido. Assicurati che sia nel formato 'AA000AA'.");
            return -1; // Valore di errore
        }

        int valore = 0;

        for (int i = 0; i < targa.Length; i++)
        {
            char carattere = targa[i];

            if (i < 2)
            {
                if (char.IsLetter(carattere))
                {
                    valore = valore * 26 + ((int)carattere - (int)'A');
                }
                else
                {
                    Console.WriteLine("Formato di targa non valido. Assicurati che le prime due posizioni siano lettere.");
                    return -1; // Valore di errore
                }
            }
            else if (i >= 2 && i < 5)
            {
                if (char.IsDigit(carattere))
                {
                    valore = valore * 10 + ((int)carattere - (int)'0');
                }
                else
                {
                    Console.WriteLine("Formato di targa non valido. Assicurati che le tre cifre centrali siano numeri.");
                    return -1; // Valore di errore
                }
            }
            else if (i >= 5 && i < 7)
            {
                if (char.IsLetter(carattere))
                {
                    valore = valore * 26 + ((int)carattere - (int)'A');
                }
                else
                {
                    Console.WriteLine("Formato di targa non valido. Assicurati che le ultime due posizioni siano lettere.");
                    return -1; // Valore di errore
                }
            }
        }

        return valore;
    }
}






