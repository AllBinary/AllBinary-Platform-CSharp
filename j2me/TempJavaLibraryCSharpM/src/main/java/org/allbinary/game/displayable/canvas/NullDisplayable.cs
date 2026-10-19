// Generated Code Do Not Modify

using System;
using System.Linq;
//using Canvas = javax.microedition.lcdui.Canvas;
//using Graphics = javax.microedition.lcdui.Graphics;

namespace org.allbinary.game.displayable.canvas;

//Temp should not be in any build
public class NullDisplayable : Canvas
{
    private static readonly NullDisplayable SINGLETON = new NullDisplayable();
    public static NullDisplayable getInstance()
    {
        return NullDisplayable.SINGLETON;
    }

    private NullDisplayable()
    {
    }

    public override void paint(Graphics graphics)
    {
    }

}

