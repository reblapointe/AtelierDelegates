using System;
using System.Collections.Generic;
using System.Text;

// PAS TOUCHE, CE N'EST PAS VOTRE CODE!

namespace AtelierDelegates
{
    public sealed class President
    {
        public static void Parle(Action<string> micro)
        {
            Console.WriteLine("\n\n=== Monsieur le président, le monde vous écoute. ===");
            string s = Console.ReadLine();
            Console.WriteLine(new string('-', ConstantesDeConsole.LARGEUR_CONSOLE));
            micro.Invoke(s);
            Console.WriteLine("\n\n" + new string('-', ConstantesDeConsole.LARGEUR_CONSOLE));
        }
    }
}
