using System;

namespace AtelierDelegates
{
    class ResponsableDesCommunications
    {
        public static void Main(string[] _)
        {
            bool continuer = true;

            // Création des délégués pour chaque auditeur
            Action<string> console = Console.WriteLine;

            // Combiner tous les délégués en un seul
            Action<string> auditeurs = console;

            // Faire parler le président
            while (continuer)
            {
                President.Parler(auditeurs);
            }

            Console.WriteLine("\n\n");
        }
    }
}
