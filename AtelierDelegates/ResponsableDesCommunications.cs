using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AtelierDelegates
{
    class ResponsableDesCommunications
    {
        public static void Main(string[] args)
        {
            bool continuer = true;
            
            // Créer les délégués
            Action<string> imprimerConsole = Console.WriteLine;
            
            // Rassembler les délégués des auditeurs
            Action<string> auditeurs = imprimerConsole;
            
            while (continuer)
            {
                President.Parler(auditeurs);
            }

            Console.WriteLine("\n\n");
        }
    }
}
