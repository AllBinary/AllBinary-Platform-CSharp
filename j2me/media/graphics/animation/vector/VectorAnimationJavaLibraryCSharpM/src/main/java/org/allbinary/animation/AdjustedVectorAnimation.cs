/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 legal agreement.
 * 
 * You may obtain the AllBinary Open License Version 1 legal agreement from
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository.
 * 
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.animation;

public class AdjustedVectorAnimation : VectorAnimation
{
    private int dx;
    private int dy;
    public AdjustedVectorAnimation(int[][][] currentPoints, BasicColor basicColor, int dx, int dy, AnimationBehavior animationBehavior) : base(currentPoints, basicColor, animationBehavior)
    {
        // base(currentPoints, basicColor, animationBehavior) is called from the constructor declaration
        this.dx = dx;
        this.dy = dy;
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        base.paintXY(graphics, x + this.dx, y + this.dy);
    }

}

