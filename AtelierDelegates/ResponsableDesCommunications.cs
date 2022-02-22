using System;
using System.Collections.Generic;

namespace AtelierDelegates
{
    class ResponsableDesCommunications
    {
        static bool continuer = true;

        public static void Continuer(string message)
        {
            continuer = !message.ToUpper().Contains("QUE DIEU VOUS GARDE");
        }

        public static void Main(string[] args)
        {
            Action<string> archiviste = (m) => new Archiviste().Archiver(m);
            Action<string> alarmiste = new Alarmiste().Crier;
            Action<string> beeper = (m) => InterpreteurMalVoyant.Beep();
            Action<string> journaliste = (m) => Journaliste.MettreALaUne("Le président", m);
            Action<string> deVinci = DeVinci.EcrireDeDroiteAGauche;
            Action<string> conspirationniste = (m) => Console.WriteLine(Conspirationniste.Ameliorer(m));


            Action<string> auditeurs = archiviste + alarmiste + journaliste + deVinci + beeper + conspirationniste + Continuer;

            int messages = 0;
            while(continuer)
            {
                President.Parle(auditeurs);
                if (++messages == 3)
                    auditeurs -= conspirationniste;
            }

            Console.WriteLine("\n\n");
        }

    }
}
