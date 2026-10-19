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
using Animation = org.allbinary.animation.Animation;

namespace org.allbinary.animation.caption;

public class CaptionAnimation : Animation
{
    private readonly Animation animationInterface;
    private readonly Animation overlayAnimationInterface;
    private readonly int captionDx;
    private readonly int captionDy;
    private readonly int dx;
    private readonly int dy;
    public CaptionAnimation(Animation animationInterface, Animation overlayAnimationInterface, int captionDx, int captionDy, int dx, int dy)
    {
        this.animationInterface = animationInterface;
        this.overlayAnimationInterface = overlayAnimationInterface;
        this.captionDx = captionDx;
        this.captionDy = captionDy;
        this.dx = dx;
        this.dy = dy;
    }

    // throws Exception
    public override void nextFrame()
    {
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.animationInterface.paintXY(graphics, x + this.captionDx, y + this.captionDy);
        this.overlayAnimationInterface.paintXY(graphics, x + this.captionDx + this.dx, y + this.captionDy + this.dy);
    }

    public override void paintThreedXYZ(Graphics graphics, int x, int y, int z)
    {
        this.animationInterface.paintThreedXYZ(graphics, x + this.captionDx, y + this.captionDy, z);
        this.overlayAnimationInterface.paintThreedXYZ(graphics, x + this.captionDx + this.dx, y + this.captionDy + this.dy, z);
    }

}

