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
//using Image = javax.microedition.lcdui.Image;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using AngleInfo = org.allbinary.math.AngleInfo;

namespace org.allbinary.animation.image;

public class AdjustedImageBaseRotationAnimation : ImageBaseRotationAnimation
{
    private int dx = 0;
    private int dy = 0;
    public AdjustedImageBaseRotationAnimation(Image image, AngleInfo angleInfo, short totalAngle, int dx, int dy, AnimationBehavior animationBehavior) : base(image, angleInfo, totalAngle, animationBehavior)
    {
        // base(image, angleInfo, totalAngle, animationBehavior) is called from the constructor declaration
        this.init(dx, dy);
    }

    // throws Exception
    public virtual void init(int dx, int dy)
    {
        this.dx = dx;
        this.dy = dy;
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        base.paintXY(graphics, x + this.dx, y + this.dy);
    }

}

