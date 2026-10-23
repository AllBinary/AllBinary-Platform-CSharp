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
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.layer;

public class Layer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly int? ID = SmallIntegerSingletonFactory.getInstance().getAt(0);
    public int x = 0;
    public int y = 0;
    public int z = 3;
    private int width = 0;
    private int height = 0;
    private bool visible = true;
    public Layer(int width, int height)
    {
        this.setLayerWidth(width);
        this.setLayerHeight(height);
    }

    public virtual void setPosition(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public virtual void moveDXY(int dx, int dy)
    {
        this.x += dx;
        this.y += dy;
    }

    public virtual void moveDXYZ(int dx, int dy, int dz)
    {
        this.x += dx;
        this.y += dy;
        this.z += dz;
    }

    public int getXP()
    {
        return this.x;
    }

    public int getYP()
    {
        return this.y;
    }

    public int getZP()
    {
        return this.z;
    }

    public int getWidth()
    {
        return this.width;
    }

    public int getHeight()
    {
        return this.height;
    }

    public virtual long getDepth()
    {
        return 0L;
    }

    public virtual void setVisible(bool visible)
    {
        this.visible = visible;
    }

    public bool isVisible()
    {
        return this.visible;
    }

    public virtual void paint(Graphics graphics)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        CanvasStrings canvasStrings = CanvasStrings.getInstance();
        this.logUtil.putF(commonStrings.NOT_IMPLEMENTED, this, canvasStrings.PAINT);
    }

    public virtual void setLayerWidth(int width)
    {
        if (width < 0) {
            throw new ArgumentException();
        }
        this.width = width;
    }

    public virtual void setLayerHeight(int height)
    {
        if (height < 0) {
            throw new ArgumentException();
        }
        this.height = height;
    }

    public virtual void toStringAppend(StringMaker stringBuffer)
    {
    }

}

