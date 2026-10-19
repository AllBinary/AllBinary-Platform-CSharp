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
//using Color = java.awt.Color;
//using Rectangle = java.awt.Rectangle;
//using BufferedImage = java.awt.image.BufferedImage;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using RectangleCollisionUtil = org.allbinary.collision.RectangleCollisionUtil;
using GPoint = org.allbinary.graphics.GPoint;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ImageComparatorConstraintsInterface = org.allbinary.media.image.comparison.ImageComparatorConstraintsInterface;

namespace org.allbinary.input.automation.module;

public class ImageComparatorConstraints : ImageComparatorConstraintsInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private BasicArrayList avoidVector = null;
    private int maxNonMatchingPixelDeltas = 0;
    private int doImageComparisonEveryNthFrame;
    public ImageComparatorConstraints(int doImageComparisonEveryNthFrame)
    {
        this.doImageComparisonEveryNthFrame = doImageComparisonEveryNthFrame;
        this.setAvoidVector(new BasicArrayListD());
    }

    public virtual BasicArrayList getAvoidVector()
    {
        return this.avoidVector;
    }

    public virtual bool isColorAllowed(int frame, GPoint point, Color color)
    {
        throw new SystemException();
    }

    public virtual bool isCollisionWithAvoidRectangles(Rectangle rectangle)
    {
        bool isCollsionWithAvoidRectangles = false;
        BasicArrayList avoidVector = this.getAvoidVector();
        int size = avoidVector.size();
        for (int index = 0; index < size; index++) {
            Rectangle avoidRectangle = ((Rectangle) avoidVector.get(index));
            if (RectangleCollisionUtil.isCollision(avoidRectangle, rectangle)) {
                isCollsionWithAvoidRectangles = true;
            }
        }
        return isCollsionWithAvoidRectangles;
    }

    public virtual bool isCollisionWithAvoidRectangles(GPoint point)
    {
        bool isCollsionWithAvoidRectangles = false;
        BasicArrayList avoidVector = this.getAvoidVector();
        int size = avoidVector.size();
        for (int index = 0; index < size; index++) {
            Rectangle avoidRectangle = ((Rectangle) avoidVector.get(index));
            if (RectangleCollisionUtil.isCollision(avoidRectangle, point)) {
                isCollsionWithAvoidRectangles = true;
                break;
            }
        }
        return isCollsionWithAvoidRectangles;
    }

    public virtual void setAvoidVector(BasicArrayList avoidVector)
    {
        this.avoidVector = avoidVector;
    }

    public virtual int getMaxNonMatchingPixelDeltas()
    {
        return this.maxNonMatchingPixelDeltas;
    }

    public virtual void setMaxNonMatchingPixelDeltas(int maxNonMatchingPixelDeltas)
    {
        this.maxNonMatchingPixelDeltas = maxNonMatchingPixelDeltas;
    }

    public virtual bool isFrameAllowed(int frame)
    {
        int remainder = ((frame + 1) % this.doImageComparisonEveryNthFrame);
        this.logUtil.putF(" Frame: " + frame + " remainder: " + remainder + " this.doImageComparisonEveryNthFrame: " + this.doImageComparisonEveryNthFrame, this, "isCollisionWithAvoidRectangles");
        if (remainder == 0) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public virtual bool isImageValid(BufferedImage bufferedImage)
    {
        throw new SystemException();
    }

    public virtual void log()
    {
        BasicArrayList avoidVector = this.getAvoidVector();
        int size = avoidVector.size();
        for (int index = 0; index < size; index++) {
            Rectangle avoidRectangle = ((Rectangle) avoidVector.get(index));
            this.logUtil.putF("Avoid Rectangle: " + avoidRectangle, this, "log");
        }
    }

}

