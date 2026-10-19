// Generated Code Do Not Modify

using System;
using System.Linq;

namespace org.allbinary.graphics.form;

public class ScreenInfo
{
    private static readonly ScreenInfo instance = new ScreenInfo();
    public static ScreenInfo getInstance()
    {
        return ScreenInfo.instance;
    }

    public readonly int SMALL_WIDTH = 320;
    public readonly int SMALL_HEIGHT = 240;
    public readonly int MEDIUM_WIDTH = 800;
    public readonly int MEDIUM_HEIGHT = 600;
}

