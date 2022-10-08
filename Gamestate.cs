using Android.Icu.Text;
using Java.Util.Functions;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace tamagotchi
{
    abstract class Gamestate
    {
        public void update()
        {
            return;
        }

        public void handleInput(GamePadState gamepad, KeyboardState keyboard)
        {
            return;
        }
    }
}
