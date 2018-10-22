using System.Collections;
using System.Collections.Generic;

public static class GlobalStuff {

    /*
     * this is where I will be storing game
     * states and such.
     *
     * things like what table I'm using,
     * modifiers for the game (multiball, fastball, etc.)
     * and whatever else would be need to be accessed across
     * multiple scripts
     */

    public static bool start { get; set; }

    private static int _spinSpeed = 1;

    public static int spinSpeed { get { return _spinSpeed; } set
        {
            if (value > 3)
            {
                _spinSpeed = -3;
            }
            else
            {
                _spinSpeed = value;
            }
        }
    }

}
