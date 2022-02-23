using System;
using System.Collections.Generic;

namespace AtelierDelegates
{
    class ResponsableDesCommunications
    {

        public static void Main(string[] args)
        {
            // Créer les délégués
            Action<string> imprimerConsole = Console.WriteLine;

            // Rassembler les délégués dans auditeurs
            Action<string> auditeurs = imprimerConsole;

            bool continuer = true;

            while (continuer)
            {
                President.Parler(auditeurs);
            }

            Console.WriteLine("\n\n");
        }
    }
}
