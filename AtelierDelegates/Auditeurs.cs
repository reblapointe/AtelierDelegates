using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


// PAS TOUCHE, CE N'EST PAS VOTRE CODE!

namespace AtelierDelegates
{
    public sealed class Archiviste
    {
        private readonly string fichier;

        public Archiviste()
        {
            fichier = "log.txt";
        }
        public bool Archiver(string message)
        {
            try
            {
                File.AppendAllText(fichier, $"({DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}) {message}\n");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public sealed class Alarmiste
    {
        public void Crier(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message.ToUpper());
            Console.ResetColor();
        }
    }

    public sealed class InterpreteurMalVoyant
    {
        public static void Beep()
        {
            Console.Beep();
        }
    }

    public sealed class Journaliste
    {
        public static void MettreALaUne(string nom, string message)
        {
            Console.Title = $"{nom} a dit \"{message}\"";
        }
    }

    public sealed class Conspirationniste
    {
        static readonly Random rand = new Random();

        public static string Ameliorer(string m)
        {
            string[] mots = m.Split(" ");
            StringBuilder sortie = new StringBuilder();

            foreach (string mot in mots)
            {
                if (mot.Length > 4 && rand.Next(10) == 0)
                    sortie.Append($"\"{mot}\"");
                else
                    sortie.Append(mot);
                sortie.Append(" ");
            }
            return sortie.ToString().Replace("président", "lézard").Replace("reine", "lézarde");
        }
    }

    public sealed class DeVinci
    {
        public static void EcrireDeDroiteAGauche(string message)
        {
            int nbLignes = message.Length / ConstantesDeConsole.LARGEUR_CONSOLE;
            for (int i = 0; i <= nbLignes; i++)
            {
                int debut = i * ConstantesDeConsole.LARGEUR_CONSOLE;
                int longueurChunk = Math.Min(ConstantesDeConsole.LARGEUR_CONSOLE, message.Length - debut);
                char[] chunk = message.Substring(debut, longueurChunk).ToCharArray();
                Array.Reverse(chunk);
                Console.WriteLine("{0," + ConstantesDeConsole.LARGEUR_CONSOLE + "}", new string(chunk));
            }
        }
    }

}
