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
using AndroidUtil = org.allbinary.AndroidUtil;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.animation.vector;

public class AdjustedCircleAnimation : CircleAnimation
{
    public static AdjustedCircleAnimation createAnimation(int width, int height, int xAdjustment, int yAdjustment, BasicColor basicColor)
    {
        AdjustedCircleAnimation adjustedCircleAnimation = new AdjustedCircleAnimation(width, height, basicColor);
        adjustedCircleAnimation.initXY(xAdjustment, yAdjustment);
        return adjustedCircleAnimation;
    }

    public static AdjustedCircleAnimation createW(int width, int height, int innerWidth, BasicColor basicColor)
    {
        AdjustedCircleAnimation adjustedCircleAnimation = new AdjustedCircleAnimation(width, height, basicColor);
        adjustedCircleAnimation.init(innerWidth);
        return adjustedCircleAnimation;
    }

    private int xAdjustment = 0;
    private int yAdjustment = 0;
    public AdjustedCircleAnimation(int width, int height, BasicColor basicColor) : base(width, height, basicColor)
    {
        // base(width, height, basicColor) is called from the constructor declaration
    }

    private void initXY(int xAdjustment, int yAdjustment)
    {
        this.xAdjustment = xAdjustment;
        this.yAdjustment = yAdjustment;
    }

    private void init(int innerWidth)
    {
        if (AndroidUtil.isAndroid()) {
            int widthPortion = (((innerWidth / 3) * 10) / 7);
            this.xAdjustment = -((this.width >> 1) - widthPortion);
            this.yAdjustment = this.xAdjustment;
        } else {
            this.xAdjustment = -((this.width >> 1) - innerWidth);
            this.yAdjustment = this.xAdjustment;
        }
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
        graphics.drawArc(x + this.xAdjustment, y + this.yAdjustment, this.width, this.height, 0, this.TOTAL_ANGLE);
    }

}

