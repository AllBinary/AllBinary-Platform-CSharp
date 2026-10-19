/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;

namespace org.allbinary.animation.text;

public class AdjustCustomTextAnimation : CustomTextAnimation
{
    private int dx;
    private int dy;
    public AdjustCustomTextAnimation(string text, int fontSize, int dx, int dy, AnimationBehavior animationBehavior) : base(text, fontSize, animationBehavior)
    {
        // base(text, fontSize, animationBehavior) is called from the constructor declaration
        this.dx = dx;
        this.dy = dy;
    }

    public override int getDx()
    {
        return this.dx;
    }

    public override void setDx(int dx)
    {
        this.dx = dx;
    }

    public override int getDy()
    {
        return this.dy;
    }

    public override void setDy(int dy)
    {
        this.dy = dy;
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        base.paintXY(graphics, x + this.dx, y + this.dy);
    }

}

