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
using Animation = org.allbinary.animation.Animation;
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using CellPosition = org.allbinary.graphics.CellPosition;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;

namespace org.allbinary.input.motion.button;

public class FullTouchButton : TouchButton
{
    // throws Exception
    public static FullTouchButton createButton(TouchButtonInput touchButtonInput, TouchButtonResource touchButtonResource, Rectangle rawRectangle, CellPosition cellPosition, int xBorder, int yBorder)
    {
        return new FullTouchButton(touchButtonInput, FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(touchButtonResource.RESOURCE).getInstance(0), FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(touchButtonResource.HINT).getInstance(0), rawRectangle, cellPosition, xBorder, yBorder);
    }

    public FullTouchButton(TouchButtonInput touchButtonInput, Animation animationInterface, Animation hintAnimationInterface, Rectangle rawRectangle, CellPosition cellPosition, int xBorder, int yBorder) : base(touchButtonInput, animationInterface, hintAnimationInterface, rawRectangle, cellPosition, xBorder, yBorder)
    {
        // base(touchButtonInput, animationInterface, hintAnimationInterface, rawRectangle, cellPosition, xBorder, yBorder) is called from the constructor declaration
    }

    protected override void updateRectangle()
    {
        try {
            PointFactory pointFactory = PointFactory.getInstance();
            int x = this.rawRectangle.getWidth() * this.cellPositionP.getColumn();
            int y = this.rawRectangle.getHeight() * this.cellPositionP.getRow();
            this.rectangleP = new Rectangle(pointFactory.createXY(x, y), this.rawRectangle.getWidth() + (2 * this.xBorder), this.rawRectangle.getHeight() + (2 * this.yBorder));
            GPoint point = this.rectangleP.getPoint();
            this.animationX = point.getX() + this.xBorder;
            this.animationY = point.getY() + this.yBorder;
            this.hintAnimationY = this.animationY - this.rectangleP.getHeight() >> 1;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "updateRectangle", e);
        }
    }

}

