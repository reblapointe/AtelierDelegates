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
            Action<string> conspirationniste = (m) => Console.WriteLine(Conspirationniste.Ameliorer(m));
            Action<string> deVinci = DeVinci.EcrireDeDroiteAGauche;

            Action<string> auditeurs = archiviste + alarmiste + beeper + journaliste + conspirationniste + deVinci + Continuer;

            int messages = 0;
            while(continuer)
            {
                President.Parle(auditeurs);
                if (++messages == 3)
                    auditeurs -= alarmiste;
            }

            Console.WriteLine("\n\n");
        }
    }
}
