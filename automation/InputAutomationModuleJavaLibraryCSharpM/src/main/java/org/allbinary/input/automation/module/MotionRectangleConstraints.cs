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
//using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;
using MotionRectangleConstraintsInterface = org.allbinary.media.image.comparison.motion.MotionRectangleConstraintsInterface;

namespace org.allbinary.input.automation.module;

public class MotionRectangleConstraints : MotionRectangleConstraintsInterface
{
    private Dimension minDimension = null;
    private Dimension maxDimension = null;
    private int maxMotionRectangles = 0;
    private int minArea = 0;
    public MotionRectangleConstraints()
    {
    }

    public virtual Dimension getMinDimension()
    {
        return this.minDimension;
    }

    public virtual Dimension getMaxDimension()
    {
        return this.maxDimension;
    }

    public virtual bool isTooSmall(Rectangle rectangle)
    {
        if (rectangle.width < this.getMinDimension().width || rectangle.height < this.getMinDimension().height) {
            return true;
        } else {
            return false;
        }
    }

    public virtual bool isAreaTooSmall(Rectangle rectangle)
    {
        if (rectangle.width * rectangle.height < this.getMinArea()) {
            return true;
        } else {
            return false;
        }
    }

    public virtual bool isTooBig(Rectangle rectangle)
    {
        if (rectangle.width > this.getMaxDimension().width || rectangle.height > this.getMaxDimension().height) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public virtual bool isValid(long? frame, BufferedImage bufferedImage, Rectangle rectangle)
    {
        throw new SystemException();
    }

    public virtual void setMinDimension(Dimension minDimension)
    {
        this.minDimension = minDimension;
    }

    public virtual void setMaxDimension(Dimension maxDimension)
    {
        this.maxDimension = maxDimension;
    }

    public virtual int getMaxMotionRectangles()
    {
        return this.maxMotionRectangles;
    }

    public virtual void setMaxMotionRectangles(int maxMotionRectangles)
    {
        this.maxMotionRectangles = maxMotionRectangles;
    }

    public virtual int getMinArea()
    {
        return this.minArea;
    }

    public virtual void setMinArea(int minArea)
    {
        this.minArea = minArea;
    }

}

