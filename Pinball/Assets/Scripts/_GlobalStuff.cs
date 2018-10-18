using System.Collections;
using System.Collections.Generic;

public static class GlobalStuff {

    public static bool start { get; set; }

    private static int _spinSpeed = 1;

    public static int spinSpeed { get { return _spinSpeed; } set
        {
            if (value <= 3)
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
