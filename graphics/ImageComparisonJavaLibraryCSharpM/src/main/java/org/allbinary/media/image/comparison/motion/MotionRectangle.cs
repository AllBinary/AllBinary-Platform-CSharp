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
//using Rectangle = java.awt.Rectangle;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.media.image.comparison.motion;

public class MotionRectangle : Cloneable
{
    private Rectangle rectangle = null;
    private BasicArrayList pixelDeltaVector = null;
    public MotionRectangle(Rectangle rectangle)
    {
        this.setRectangle(rectangle);
        this.setPixelDeltaVector(new BasicArrayListD());
    }

    public virtual Rectangle getRectangle()
    {
        return this.rectangle;
    }

    public virtual void setRectangle(Rectangle rectangle)
    {
        this.rectangle = rectangle;
    }

    public virtual BasicArrayList getPixelDeltaVector()
    {
        return this.pixelDeltaVector;
    }

    public virtual void setPixelDeltaVector(BasicArrayList pixelDeltaVector)
    {
        this.pixelDeltaVector = pixelDeltaVector;
    }

    public virtual object clone()
    {
        MotionRectangle motionRectangle = new MotionRectangle(((Rectangle) this.getRectangle().clone()));
        motionRectangle.setPixelDeltaVector(((BasicArrayList) this.getPixelDeltaVector().clone()));
        return motionRectangle;
    }

}

