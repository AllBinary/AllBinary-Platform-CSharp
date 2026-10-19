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
using AnimationInterface = org.allbinary.animation.AnimationInterface;
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
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly TouchButtonInput touchButtonInput;
    private readonly Animation animationInterface;
    public readonly Rectangle rawRectangle;
    public readonly int xBorder;
    public readonly int yBorder;
    public Rectangle rectangle = RectangleFactory.SINGLETON;
    public readonly CellPosition cellPosition;
    public int animationX = 0;
    public int animationY = 0;
    public TouchButton(TouchButtonInput touchButtonInput, AnimationInterface animationInterface, Rectangle rawRectangle, CellPosition cellPosition, int xBorder, int yBorder)
    {
        this.touchButtonInput = touchButtonInput;
        this.animationInterface = ((Animation) animationInterface);
        this.rawRectangle = rawRectangle;
        this.cellPosition = cellPosition;
        this.xBorder = xBorder;
        this.yBorder = yBorder;
        this.updateRectangle();
        this.logUtil.putF(new StringMaker().append("Created: ").append(this.ToString()).ToString(), this, this.commonStrings.CONSTRUCTOR);
    }

    public override void paint(Graphics graphics)
    {
        this.animationInterface.paintXY(graphics, animationX, this.animationY);
    }

    protected virtual void updateRectangle()
    {
        try {
            int x = this.rawRectangle.getWidth() * this.cellPosition.getColumn();
            int y = this.rawRectangle.getHeight() * this.cellPosition.getRow();
            PointFactory pointFactory = PointFactory.getInstance();
            this.rectangle = new Rectangle(pointFactory.createXY(x + this.xBorder, y + this.yBorder), this.rawRectangle.getWidth(), this.rawRectangle.getHeight());
            GPoint point = this.rectangle.getPoint();
            this.animationX = point.getX();
            this.animationY = point.getY();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "updateRectangle", e);
        }
    }

    public virtual CellPosition getCellPositionP()
    {
        return this.cellPosition;
    }

    public virtual Rectangle getRectangleP()
    {
        return this.rectangle;
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
        stringBuffer.append(stringUtil.toString(this.rectangle));
        stringBuffer.append(" CellPosition: ");
        stringBuffer.append(stringUtil.toString(this.cellPosition));
        stringBuffer.append(" xBorder: ");
        stringBuffer.appendint(this.xBorder);
        stringBuffer.append(" yBorder: ");
        stringBuffer.appendint(this.yBorder);
        return stringBuffer.ToString();
    }

}

