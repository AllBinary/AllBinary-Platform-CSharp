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
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using CellPosition = org.allbinary.graphics.CellPosition;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using Paintable = org.allbinary.graphics.paint.Paintable;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.motion.button;

public class TouchButton : Paintable
{
    // throws Exception
    public static TouchButton createButton(TouchButtonInput touchButtonInput, TouchButtonResource touchButtonResource, Rectangle rawRectangle, CellPosition cellPosition, int xBorder, int yBorder)
    {
        return new TouchButton(touchButtonInput, FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(touchButtonResource.RESOURCE).getInstance(0), FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(touchButtonResource.HINT).getInstance(0), rawRectangle, cellPosition, xBorder, yBorder);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly TouchButtonInput touchButtonInput;
    private readonly Animation animationInterface;
    private readonly Animation hintAnimationInterface;
    public readonly Rectangle rawRectangle;
    public readonly int xBorder;
    public readonly int yBorder;
    public Rectangle rectangleP = RectangleFactory.SINGLETON;
    public readonly CellPosition cellPositionP;
    public int animationX = 0;
    public int animationY = 0;
    public int hintAnimationY = 0;
    public TouchButton(TouchButtonInput touchButtonInput, Animation animationInterface, Animation hintAnimationInterface, Rectangle rawRectangle, CellPosition cellPosition, int xBorder, int yBorder)
    {
        this.touchButtonInput = touchButtonInput;
        this.animationInterface = animationInterface;
        this.hintAnimationInterface = hintAnimationInterface;
        this.rawRectangle = rawRectangle;
        this.cellPositionP = cellPosition;
        this.xBorder = xBorder;
        this.yBorder = yBorder;
        this.updateRectangle();
        this.logUtil.putF(new StringMaker().append("Created: ").append(this.ToString()).ToString(), this, this.commonStrings.CONSTRUCTOR);
    }

    public virtual void paintHint(Graphics graphics)
    {
        this.hintAnimationInterface.paintXY(graphics, this.animationX, this.hintAnimationY);
    }

    public override void paint(Graphics graphics)
    {
        this.animationInterface.paintXY(graphics, this.animationX, this.animationY);
    }

    public virtual void updateRectangle()
    {
        try {
            PointFactory pointFactory = PointFactory.getInstance();
            int x = this.rawRectangle.getWidth() * this.cellPositionP.getColumn();
            int y = this.rawRectangle.getHeight() * this.cellPositionP.getRow();
            this.rectangleP = new Rectangle(pointFactory.createXY(x + this.xBorder, y + this.yBorder), this.rawRectangle.getWidth(), this.rawRectangle.getHeight());
            GPoint point = this.rectangleP.getPoint();
            this.animationX = point.getX();
            this.animationY = point.getY();
            this.hintAnimationY = this.animationY - 32;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "updateRectangle", e);
        }
    }

    public virtual CellPosition getCellPosition()
    {
        return this.cellPositionP;
    }

    public virtual Rectangle getRectangle()
    {
        return this.rectangleP;
    }

    public virtual TouchButtonInput getTouchButtonInput()
    {
        return this.touchButtonInput;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        StringUtil stringUtil = StringUtil.getInstance();
        stringBuffer.append("TouchButton: ");
        stringBuffer.append(stringUtil.toString(this.getRectangle()));
        stringBuffer.append(" CellPosition: ");
        stringBuffer.append(stringUtil.toString(this.cellPositionP));
        stringBuffer.append(" xBorder: ");
        stringBuffer.appendint(this.xBorder);
        stringBuffer.append(" yBorder: ");
        stringBuffer.appendint(this.yBorder);
        return stringBuffer.ToString();
    }

}

