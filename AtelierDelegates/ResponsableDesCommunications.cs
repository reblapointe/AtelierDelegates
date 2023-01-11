using System;

namespace AtelierDelegates
{
    class ResponsableDesCommunications
    {
        public static void Main(string[] _)
        {
            bool continuer = true;

            Action<string> archiviste = (m) => new Archiviste().Archiver(m);
            Action<string> alarmiste = new Alarmiste().Crier;
            Action<string> beeper = (m) => InterpreteurMalVoyant.Beep();
            Action<string> journaliste = (m) => Journaliste.MettreALaUne("Le président", m);
            Action<string> conspirationniste = (m) => Console.WriteLine(Conspirationniste.Ameliorer(m));
            Action<string> deVinci = DeVinci.EcrireDeDroiteAGauche;
            Action<string> phraseDeFin = (m) => continuer = !(m.Trim().ToUpper() == "LA TERRE AUX TERRIENS!");

            Action<string> auditeurs = archiviste + alarmiste + beeper + journaliste + conspirationniste + deVinci + phraseDeFin;

            int messages = 0;
            while (continuer)
            {
                President.Parler(auditeurs);
                if (++messages == 3)
                    auditeurs -= alarmiste;
            }

            Console.WriteLine("\n\n");
        }
    }
}
