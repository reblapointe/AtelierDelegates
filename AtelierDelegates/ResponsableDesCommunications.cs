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

            // Rassembler les délégués
            Action<string> auditeurs = imprimerConsole;

            bool continuer = true;

            while (continuer)
            {
                President.Parle(auditeurs);
            }

            Console.WriteLine("\n\n");
        }
    }
}
