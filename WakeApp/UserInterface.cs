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
            HeaderV2();

            //Clock();
        }

        private void HeaderV2()
        {
            string header = @"    __        __      _             _" + Environment.NewLine +
                            @"    \ \      / /__ _ | | __ ___    / \    _ __   _ __  " + Environment.NewLine +
                            @"     \ \ /\ / // _` || |/ // _ \  / _ \  | '_ \ | '_ \ " + Environment.NewLine +
                            @"      \ V  V /| (_| ||   <|  __/ / ___ \ | |_) || |_) |" + Environment.NewLine +
                            @"       \_/\_/  \__,_||_|\_\\___|/_/   \_\| .__/ | .__/ " + Environment.NewLine +
                            @"    ─────────────────────────────────────|_|────|_|────";
            Write(header);
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
