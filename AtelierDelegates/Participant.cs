using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierDelegates
{
    public class ConstantesDeConsole
    {
        public const int LARGEUR_CONSOLE = 120;
    }
    class ParticipantOrdinaire
    {
        public void Imprimer(string message)
        {
            Console.Error.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute} : {message} ");
        }
    }

    class ParticipantTitre
    {
        public void ChangerTitre(string message)
        {
            Console.Title = message;
        }
    }

    class ParticipantCouleur
    {
        public ConsoleColor Fond { get; set; }
        public ConsoleColor Police { get; set; }

        public void EcrireEnCouleur(string message)
        {
            Console.ForegroundColor = Police;
            Console.BackgroundColor = Fond;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }
    }

    class ParticipantSonore
    {
        readonly Random rand = new Random();
        public void FaireDuBruit(string s)
        {
            Console.WriteLine("**BEEP**");
            Console.Beep(rand.Next(200, 2000), Math.Min(2000, Math.Max(50, s.Length * 50)));
        }
    }

    class DaVinci
    {
        public void EcrireDeDroiteAGauche(string message)
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


    class EmetteurDeMessages
    {
        public static void Main(string[] args)
        {
            Action<string> ordinaire = new ParticipantOrdinaire().Imprimer;
            Action<string> err = new ParticipantCouleur() { Fond = ConsoleColor.DarkRed, Police = ConsoleColor.Yellow }.EcrireEnCouleur;
            Action<string> beeper = new ParticipantSonore().FaireDuBruit;
            Action<string> titre = new ParticipantTitre().ChangerTitre;
            Action<string> daVinci = new DaVinci().EcrireDeDroiteAGauche;

            EmetteurDeMessages emetteur = new EmetteurDeMessages();

            Action<string> participants = ordinaire + err + titre + daVinci + beeper;
            Console.WriteLine("\n\n" + new string('-', ConstantesDeConsole.LARGEUR_CONSOLE));
            participants.Invoke("Allo");

            participants -= ordinaire;

            Console.WriteLine("\n\n" + new string('-', ConstantesDeConsole.LARGEUR_CONSOLE));
            participants.Invoke("Le plate est parti! Vite, on dit des niaiseries!");

            Console.WriteLine("\n\n" + new string('-', ConstantesDeConsole.LARGEUR_CONSOLE)); 
            participants.Invoke("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt " +
                "ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut " +
                "aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore " +
                "eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt " +
                "mollit anim id est laborum.");

            Console.WriteLine("\n\n");

        }
    }
}
