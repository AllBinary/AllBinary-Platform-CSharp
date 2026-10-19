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
using ImageUtil = org.allbinary.media.image.ImageUtil;
using PixelDelta = org.allbinary.media.image.comparison.pixel.PixelDelta;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image.search;

public class ImageComparisonSearch
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public bool isSameHeight = false;
    public bool isSameWidth = false;
    public int pixelsThatMatch = 0;
    public int pixelsIgnored = 0;
    public int imageHeight;
    public int imageWidth;
    private int tolerance = 0;
    private BasicArrayList nonMatchingPixelVector;
    private BufferedImage[] bufferedImages = null;
    private float matchingPercent = ((float) (-1));
    public ImageComparisonSearch(BufferedImage bufferedImage, BufferedImage bufferedImage2, int tolerance)
    {
        this.nonMatchingPixelVector = new BasicArrayListD();
        this.setBufferedImages(new BufferedImage[2]);
        this.getBufferedImages()[0] = bufferedImage;
        this.getBufferedImages()[1] = bufferedImage2;
        this.imageHeight = bufferedImage.getHeight();
        this.imageWidth = bufferedImage.getWidth();
        if (bufferedImage.getHeight() != bufferedImage2.getHeight()) {
            this.isSameHeight = false;
            if (this.imageHeight > bufferedImage2.getHeight()) {
                this.imageHeight = bufferedImage2.getHeight();
            }
        } else {
            this.isSameHeight = true;
        }
        if (bufferedImage.getWidth() != bufferedImage2.getWidth()) {
            this.isSameWidth = false;
            if (this.imageWidth > bufferedImage2.getWidth()) {
                this.imageWidth = bufferedImage2.getWidth();
            }
        } else {
            this.isSameWidth = true;
        }
        if (!this.isSameWidth || !this.isSameHeight) {
            ImageUtil imageUtil = ImageUtil.getInstance();
            this.logUtil.putF("Images were not the same size? Most likely a resolution change.", this, this.commonStrings.CONSTRUCTOR);
            this.logUtil.putF("1: " + imageUtil.toString(bufferedImage), this, this.commonStrings.CONSTRUCTOR);
            this.logUtil.putF("2: " + imageUtil.toString(bufferedImage2), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    private float getMatchingPercent()
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
        return "ImageComparisonInfo: " + " Number Of Matching Pixels: " + this.pixelsThatMatch + "\nNumber Of Non-Matching Pixels: " + this.getNonMatchingPixelVector().size() + "\nNumber Of Pixels Ignored: " + this.pixelsIgnored + "\nMatching Percentage: " + this.getMatchingPercent();
    }

    public virtual BufferedImage[] getBufferedImages()
    {
        return this.bufferedImages;
    }

    private void setBufferedImages(BufferedImage[] bufferedImages)
    {
        this.bufferedImages = bufferedImages;
    }

    public virtual int getTolerance()
    {
        return this.tolerance;
    }

    public virtual void setTolerance(int tolerance)
    {
        this.tolerance = tolerance;
    }

}

