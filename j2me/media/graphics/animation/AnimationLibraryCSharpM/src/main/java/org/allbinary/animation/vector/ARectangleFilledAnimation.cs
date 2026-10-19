// Generated Code Do Not Modify

using System;
using System.Linq;
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;

namespace org.allbinary.animation.vector;

public class ARectangleFilledAnimation : RectangleFilledAnimation
{
    public int x = 0;
    public int y = 0;
    public ARectangleFilledAnimation() : base(0, 0, BasicColorFactory.getInstance().BLACK)
    {
        // base(0, 0, BasicColorFactory.getInstance().BLACK) is called from the constructor declaration
    }

    public override void nextFrame()
    {
    }

    public override void paintXY(Graphics graphics, int unusedX, int unusedY)
    {
        base.paintXY(graphics, this.x, this.y);
    }

}

