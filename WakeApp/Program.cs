using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace WakeApp
{
    internal class Program
    {
        public int arrivalTime;     // Ankunftszeit
        public int routeDuration;   // Fahrtwegdauer
        public int getReadyTime;    // Fertigmachzeit
        public int otherDelays;     // andere Verzögerungen
        public bool bufferTime;     // Pufferzeit - zum Ausgleich von möglichen Stau's oder Zugverspätungen

        static void Main(string[] args)
        {
            #region WakeApp-Infos
            ///<summary>
            ///
            /// Autoren: Elias Sahm, Jonas Foltin
            /// Erstelldatum: 26.05.2022
            /// ---------------------------------
            /// 
            /// Anforderungen:
            ///     1. Planen Sie ihr Vorgehen mit passenden Dokumenten (Klassendiagramm, ERM, ...)
            ///     2. Entwickeln Sie eine textbasierte Anwendung für die Konsole/das Terminal
            ///         a.Die App soll zunächst die notwendigen Daten abfragen.
            ///         (Ankunftszeit/Zielzeit, Dauer des Fahrtweges, benötigte Zeit zum Fertigmachen am Morgen, weitere Verzögerungen)
            ///         b. Im Anschluss soll die App die Weckzeit berechnen.
            ///         c. Überlegen Sie sich eine benutzerfreundliche Menüführung. Eine Berechnung kann mehrfach ausgeführt werden.
            ///         d. Fangen Sie mögliche Fehleingaben ab.
            ///         e. Testen Sie Ihr Programm mit unterschiedlichen Daten.
            ///     3. Speichern Sie die eingegebenen Daten in einer Datenbank oder Datei, sodass diese App beim nächsten Start des Programms wieder zur Verfügung stehen.
            ///     4. Verwenden Sie das Versionskontrollsystem GIT.
            ///     
            /// Aufgabenteilung in der Word-Datei "Anforderungen Vorlage" (im Moodle Kurs und im Git-Repository hinterlegt).
            /// 
            ///</summary>
            #endregion

            // Console Settings
            Title = "WakeApp";
            SetWindowSize(110, 25);
            SetBufferSize(110, 25);

            // User Interface
            UserInterface UI = new UserInterface();
            UI.Display();

            ReadKey();
        }
    }
}