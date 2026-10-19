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
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;

namespace org.allbinary.animation;

public class ColorLessVectorAnimation : VectorAnimation
{
    public ColorLessVectorAnimation(int[][][] currentPoints, AnimationBehavior animationBehavior) : base(currentPoints, BasicColorFactory.getInstance().WHITE, animationBehavior)
    {
        // base(currentPoints, BasicColorFactory.getInstance().WHITE, animationBehavior) is called from the constructor declaration
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.paintVectors(graphics, x, y);
    }

}

