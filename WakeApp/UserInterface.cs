using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace WakeApp
{
    internal class UserInterface
    {
        public void Display()
        {
            Border();
            Header();
            Clock();
        }

        private void Border()
        {
            // │ ┤ ┼ ├ ┐ ┌ └ ┘ ┴ ┬ ─
            // ║ ╣ ╬ ╠ ╗ ╔ ╝ ╚ ╩ ╦ ═

            string border = "\n   ╔════════════════════════════════════════════════════════════════════════════════════════════════════════╗" + "\n" +
                            "   ║                                                                                                        ║" + "\n" +
                            "   ║                                                                                                        ║" + "\n" +
                            "   ║                                                                                                        ║" + "\n" +
                            "   ║                                                                                                        ║" + "\n" +
                            "   ║                                                                                                        ║" + "\n" +
                            "   ║                                                                                                        ║" + "\n" +
                            "   ╠══════════════════════════════════════════════════════════════════════════════╦═════════════════════════╣" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ║                                                                              ║                         ║" + "\n" +
                            "   ╚══════════════════════════════════════════════════════════════════════════════╩═════════════════════════╝";
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine(border);
            ForegroundColor = ConsoleColor.White;
        }

        private void Header()
        {
            ForegroundColor = ConsoleColor.Cyan;
            SetCursorPosition(28, 2);
            Write(",--.   ,--.        ,--.            ,---.");
            SetCursorPosition(28, 3);
            Write("|  |   |  | ,--,--.|  |,-. ,---.  /  O  \\  ,---.  ,---.");
            SetCursorPosition(28, 4);
            Write("|  |.'.|  |' ,-.  ||     /| .-. :|  .-.  || .-. || .-. |");
            SetCursorPosition(28, 5);
            Write("|   ,'.   |\\ '-'  ||  \\  \\|   --.|  | |  || '-' /| '-' /");
            SetCursorPosition(28, 6);
            Write("'--'   '--' `--`--'`--'`--'`----'`--' `--'|  |-' |  |-'");
            SetCursorPosition(28, 7);
            Write("                                          `--'   `--'");
            ForegroundColor = ConsoleColor.White;
        }

        private void Clock()
        {
            SetCursorPosition(85, 9);
            Write("        _____");
            SetCursorPosition(85, 10);
            Write("  .-._.'_───_`._.-.");
            SetCursorPosition(85, 11);
            Write(" (_.'.-´  12 `-.`._)");
            SetCursorPosition(85, 12);
            Write("  /,' 11      1 `.\\");
            SetCursorPosition(85, 13);
            Write(" // 10      /   2 \\\\");
            SetCursorPosition(85, 14);
            Write("::         /       ;;");
            SetCursorPosition(85, 15);
            Write("|| 9  ────O      3 ||");
            SetCursorPosition(85, 16);
            Write("::                 ;;");
            SetCursorPosition(85, 17);
            Write(" \\\\ 8           4 //");
            SetCursorPosition(85, 18);
            Write("  \\`. 7       5 ,'/");
            SetCursorPosition(85, 19);
            Write("   '.`-.__6__.-'.'");
            SetCursorPosition(85, 20);
            Write("    /'-._____.-'\\");
            SetCursorPosition(85, 21);
            Write("    '--'     '--'");

        }
    }
}
