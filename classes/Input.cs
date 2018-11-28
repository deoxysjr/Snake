using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Input
    {
        private static readonly Hashtable Keytable = new Hashtable();

        public static bool KeyPressed(Keys key)
        {
            if (Keytable[key] == null)
                return false;
            else
                return (bool)Keytable[key];
        }

        public static void ChangeState(Keys key, bool state)
        {
            Keytable[key] = state;
        }
    }
}
