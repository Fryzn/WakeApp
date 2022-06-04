using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace WakeApp
{
    internal class AlarmClock : Program
    {
        private int userIndex;
        private string userInput;
        private int currentLeftPos;
        private int currentTopPos;
        private DateTime alarmTime;

        public bool Run()
        {
            ForegroundColor = ConsoleColor.White;

            // User Interface
            UserInterface UI = new UserInterface();
            UI.Display();

            bool newAlarmClock = false;
            if (valuesInConfig)
            {
                SetCursorPosition(4, 7);
                Write("»Es wurde ein gespeicherter Wecker gefunden.\n" +
                    "     Soll der Wecker verwendet werden?\n" +
                    "     Ja [ ] - Nein [ ] (Pfeil-Tasten)\n");

                ConsoleKey keyPressed;
                userIndex = 0;
                do
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    if (userIndex == 0)
                    {
                        SetCursorPosition(9, 9);
                        Write("×");
                        SetCursorPosition(20, 9);
                        Write(" ");
                    }
                    else if (userIndex == 1)
                    {
                        SetCursorPosition(9, 9);
                        Write(" ");
                        SetCursorPosition(20, 9);
                        Write("×");
                    }
                    ForegroundColor = ConsoleColor.White;

                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    keyPressed = keyInfo.Key;

                    if (keyPressed == ConsoleKey.LeftArrow)
                    {
                        userIndex--;
                        if (userIndex <= -1)
                        {
                            userIndex = 1;
                        }
                    }
                    else if (keyPressed == ConsoleKey.RightArrow)
                    {
                        userIndex++;
                        if (userIndex >= 2)
                        {
                            userIndex = 0;
                        }
                    }
                }
                while (keyPressed != ConsoleKey.Enter);

                if (userIndex == 1)
                {
                    newAlarmClock = true;
                }
            }
            else
            {
                SetCursorPosition(4, 7);
                Write("»Es wurde kein Wecker-Profil gefunden.\n" +
                    "     Drücken Sie eine beliebige Taste um fortzfahren...");
                newAlarmClock = true;
                ReadKey();
            }

            do
            {
                if (newAlarmClock)
                {
                    Clear();
                    UI.Display();

                    SetCursorPosition(4, 7);
                    Write("»Neuen Wecker erstellen.\n" +
                        "     Bitte geben Sie folgende Werte an: \n\n");

                    bool correctValue = false;
                    while (!correctValue)
                    {
                        SetCursorPosition(4, 10);
                        Write("»Ihre Ankunftszeit (HH:mm):\n" +
                            "     = ");
                        correctValue = SetArrivalTime();
                    }
                    Write(" - Ankunftszeit gesetzt...");

                    correctValue = false;
                    while (!correctValue)
                    {
                        SetCursorPosition(4, 13);
                        Write("»Ihre Fahrtzeit/Dauer in Minuten:\n" +
                            "     = ");
                        correctValue = SetDelays(1);
                    }
                    Write(" - Fahrzeit gesetzt...");

                    correctValue = false;
                    while (!correctValue)
                    {
                        SetCursorPosition(4, 16);
                        Write("»Ihre Zeit zum fertigmachen in Minuten:\n" +
                            "     = ");
                        correctValue = SetDelays(2);
                    }
                    Write(" - Fertigmachzeit gesetzt...");

                    correctValue = false;
                    while (!correctValue)
                    {
                        SetCursorPosition(4, 19);
                        Write("»Andere mögliche Verzögerungen in Minuten:\n" +
                            "     = ");
                        correctValue = SetDelays(3);
                    }
                    Write(" - Andere Verspätungen gesetzt...");

                    correctValue = false;
                    while (!correctValue)
                    {
                        SetCursorPosition(4, 22);
                        Write("»Zusätzliche Pufferzeit von 5-10 Minuten hinzufügen?\n" +
                            "     = 5 min. [ ] - 10 min. [ ] - Nein [ ] (Pfeil-Tasten)");
                        correctValue = SetBufferTime();
                    }
                    SetCursorPosition(5, 24);
                    Write("- Pufferzeit gesetzt...");

                    // Xml Handler
                    XmlConfig Config = new XmlConfig();
                    Config.Save();
                }


            }
            while (setAlarmClock);
            return false;
        }

        private bool SetArrivalTime()
        {
            try
            {
                CursorVisible = true;
                userInput = String.Empty;
                currentLeftPos = CursorLeft;
                currentTopPos = CursorTop;

                ConsoleKey keyPressed;
                do
                {
                    SetCursorPosition(currentLeftPos, currentTopPos);
                    ForegroundColor = ConsoleColor.Cyan;
                    Write(userInput);
                    ForegroundColor = ConsoleColor.White;

                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    keyPressed = keyInfo.Key;

                    if (keyPressed == ConsoleKey.D0 | keyPressed == ConsoleKey.D1 | keyPressed == ConsoleKey.D2 | keyPressed == ConsoleKey.D3 | keyPressed == ConsoleKey.D4 |
                        keyPressed == ConsoleKey.D5 | keyPressed == ConsoleKey.D6 | keyPressed == ConsoleKey.D7 | keyPressed == ConsoleKey.D8 | keyPressed == ConsoleKey.D9 |
                        keyPressed == ConsoleKey.NumPad0 | keyPressed == ConsoleKey.NumPad1 | keyPressed == ConsoleKey.NumPad2 | keyPressed == ConsoleKey.NumPad3 |
                        keyPressed == ConsoleKey.NumPad4 | keyPressed == ConsoleKey.NumPad5 | keyPressed == ConsoleKey.NumPad6 | keyPressed == ConsoleKey.NumPad7 |
                        keyPressed == ConsoleKey.NumPad8 | keyPressed == ConsoleKey.NumPad9 |
                        keyPressed == ConsoleKey.OemPeriod)
                    {
                        if (userInput.Length < 5)
                        {
                            userInput += keyInfo.KeyChar;
                        }
                    }
                    else if (keyPressed == ConsoleKey.Backspace)
                    {
                        userInput = userInput.Substring(0, userInput.Length - 1);
                        SetCursorPosition(currentLeftPos + userInput.Length, currentTopPos);
                        Write(" ");
                    }
                }
                while (keyPressed != ConsoleKey.Enter);

                CursorVisible = false;
                arrivalTime = userInput;
                alarmTime = DateTime.Parse(userInput);
                return true;
            }
            catch
            {
                SetCursorPosition(4, currentTopPos + 1);
                Write("»Fehlerhafte Eingabe...\n" +
                    "     Bitte beachten Sie das vorgegebene Format (HH:mm).");
                System.Threading.Thread.Sleep(3000);
                SetCursorPosition(currentLeftPos, currentTopPos);
                Write("      \n" +
                    "                           \n" +
                    "                                                        ");
                return false;
            }
        }

        private bool SetDelays(int id)
        {
            try
            {
                CursorVisible = true;
                userInput = String.Empty;
                currentLeftPos = CursorLeft;
                currentTopPos = CursorTop;

                ConsoleKey keyPressed;
                do
                {
                    SetCursorPosition(currentLeftPos, currentTopPos);
                    ForegroundColor = ConsoleColor.Cyan;
                    Write(userInput);
                    ForegroundColor = ConsoleColor.White;

                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    keyPressed = keyInfo.Key;

                    if (keyPressed == ConsoleKey.D0 | keyPressed == ConsoleKey.D1 | keyPressed == ConsoleKey.D2 | keyPressed == ConsoleKey.D3 | keyPressed == ConsoleKey.D4 |
                        keyPressed == ConsoleKey.D5 | keyPressed == ConsoleKey.D6 | keyPressed == ConsoleKey.D7 | keyPressed == ConsoleKey.D8 | keyPressed == ConsoleKey.D9 |
                        keyPressed == ConsoleKey.NumPad0 | keyPressed == ConsoleKey.NumPad1 | keyPressed == ConsoleKey.NumPad2 | keyPressed == ConsoleKey.NumPad3 |
                        keyPressed == ConsoleKey.NumPad4 | keyPressed == ConsoleKey.NumPad5 | keyPressed == ConsoleKey.NumPad6 | keyPressed == ConsoleKey.NumPad7 |
                        keyPressed == ConsoleKey.NumPad8 | keyPressed == ConsoleKey.NumPad9)
                    {
                        if (userInput.Length < 3)
                        {
                            userInput += keyInfo.KeyChar;
                        }
                    }
                    else if (keyPressed == ConsoleKey.Backspace)
                    {
                        userInput = userInput.Substring(0, userInput.Length - 1);
                        SetCursorPosition(currentLeftPos + userInput.Length, currentTopPos);
                        Write(" ");
                    }
                }
                while (keyPressed != ConsoleKey.Enter);

                CursorVisible = false;
                switch (id)
                {
                    case 1:
                        routeDuration = userInput;
                        alarmTime.AddMinutes(-Convert.ToInt32(routeDuration));
                        break;
                    case 2:
                        getReadyTime = userInput;
                        alarmTime.AddMinutes(-Convert.ToInt32(getReadyTime));
                        break;
                    case 3:
                        otherDelays = userInput;
                        alarmTime.AddMinutes(-Convert.ToInt32(otherDelays));
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool SetBufferTime()
        {
            userIndex = 0;
            ConsoleKey keyPressed;
            do
            {
                ForegroundColor = ConsoleColor.Cyan;
                if (userIndex == 0)
                {
                    SetCursorPosition(15, 23);
                    Write("×");
                    SetCursorPosition(29, 23);
                    Write(" ");
                    SetCursorPosition(40, 23);
                    Write(" ");
                }
                else if (userIndex == 1)
                {
                    SetCursorPosition(15, 23);
                    Write(" ");
                    SetCursorPosition(29, 23);
                    Write("×");
                    SetCursorPosition(40, 23);
                    Write(" ");
                }
                else if (userIndex == 2)
                {
                    SetCursorPosition(15, 23);
                    Write(" ");
                    SetCursorPosition(29, 23);
                    Write(" ");
                    SetCursorPosition(40, 23);
                    Write("×");
                }
                ForegroundColor = ConsoleColor.White;

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    userIndex--;
                    if(userIndex <= -1)
                    {
                        userIndex = 2;
                    }
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    userIndex++;
                    if (userIndex >= 3)
                    {
                        userIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);
            
            switch (userIndex)
            {
                case 0:
                    bufferTime = "5";
                    alarmTime.AddMinutes(-Convert.ToInt32(bufferTime));
                    break;
                case 1:
                    bufferTime = "10";
                    alarmTime.AddMinutes(-Convert.ToInt32(bufferTime));
                    break;
                case 2:
                    bufferTime = "0";
                    alarmTime.AddMinutes(-Convert.ToInt32(bufferTime));
                    break;
            }
            return true;
        }
    }
}
