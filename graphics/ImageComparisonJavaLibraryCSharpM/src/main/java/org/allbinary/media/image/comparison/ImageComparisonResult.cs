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
//using BufferedImage = java.awt.image.BufferedImage;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ImageUtil = org.allbinary.media.image.ImageUtil;
using PixelDelta = org.allbinary.media.image.comparison.pixel.PixelDelta;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image.comparison;

public class ImageComparisonResult
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly BufferedImage[] bufferedImages = new BufferedImage[2];
    public readonly string name;
    public readonly bool isSameHeight = false;
    public readonly bool isSameWidth = false;
    public readonly int imageHeight;
    public readonly int imageWidth;
    private readonly BasicArrayList nonMatchingPixelVector;
    private readonly long? frameOne;
    private readonly long? frameTwo;
    public int pixelsThatMatch = 0;
    public int pixelsIgnored = 0;
    private int tolerance = 0;
    private float matchingPercent = ((float) (-1));
    public ImageComparisonResult(string name, BufferedImage bufferedImage, BufferedImage bufferedImage2, long? frameOne, long? frameTwo, int tolerance)
    {
        this.name = name;
        this.nonMatchingPixelVector = new BasicArrayListD();
        this.bufferedImages[0] = bufferedImage;
        this.bufferedImages[1] = bufferedImage2;
        this.frameOne = frameOne;
        this.frameTwo = frameTwo;
        this.setTolerance(0);
        int imageHeight = bufferedImage.getHeight();
        int imageWidth = bufferedImage.getWidth();
        if (bufferedImage.getHeight() != bufferedImage2.getHeight()) {
            this.isSameHeight = false;
            if (imageHeight > bufferedImage2.getHeight()) {
                imageHeight = bufferedImage2.getHeight();
            }
        } else {
            this.isSameHeight = true;
        }
        if (bufferedImage.getWidth() != bufferedImage2.getWidth()) {
            this.isSameWidth = false;
            if (imageWidth > bufferedImage2.getWidth()) {
                imageWidth = bufferedImage2.getWidth();
            }
        } else {
            this.isSameWidth = true;
        }
        this.imageWidth = imageWidth;
        this.imageHeight = imageHeight;
        if (!this.isSameWidth || !this.isSameHeight) {
            ImageUtil imageUtil = ImageUtil.getInstance();
            this.logUtil.putF("Images were not the same size? Most likely a resolution change.", this, this.commonStrings.CONSTRUCTOR);
            this.logUtil.putF("1: " + imageUtil.toString(bufferedImage), this, this.commonStrings.CONSTRUCTOR);
            this.logUtil.putF("2: " + imageUtil.toString(bufferedImage2), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public virtual float getMatchingPercent()
    {
        if (this.matchingPercent == ((float) (-1))) {
            this.matchingPercent = ((float) this.pixelsThatMatch) / ((float) (this.imageWidth * this.imageHeight));
        }
        return this.matchingPercent;
    }

    public virtual void add(PixelDelta pixel)
    {
        this.nonMatchingPixelVector.add(pixel);
    }

    public virtual BasicArrayList getNonMatchingPixelVector()
    {
        return this.nonMatchingPixelVector;
    }

    public override string ToString()
    {
        return new StringMaker().append("ImageComparisonInfo: ").append(this.name).append(" Number Of Matching Pixels: ").appendint(this.pixelsThatMatch).append("\nNumber Of Non-Matching Pixels: ").appendint(this.getNonMatchingPixelVector().size()).append("\nNumber Of Pixels Ignored: ").appendint(this.pixelsIgnored).append("\nMatching Percentage: ").appendfloat(this.getMatchingPercent()).ToString();
    }

    public virtual BufferedImage[] getBufferedImages()
    {
        return this.bufferedImages;
    }

    public virtual int getTolerance()
    {
        return this.tolerance;
    }

    private void setTolerance(int tolerance)
    {
        this.tolerance = tolerance;
    }

    public virtual long? getFrameOne()
    {
        return this.frameOne;
    }

    public virtual long? getFrameTwo()
    {
        return this.frameTwo;
    }

}

