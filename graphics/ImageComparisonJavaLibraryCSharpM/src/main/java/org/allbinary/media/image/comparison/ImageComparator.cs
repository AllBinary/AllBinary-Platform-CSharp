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
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using ColorCacheFactory = org.allbinary.graphics.color.ColorCacheFactory;
using ColorCacheable = org.allbinary.graphics.color.ColorCacheable;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AutomaticCacheInterface = org.allbinary.logic.util.cache.AutomaticCacheInterface;
using PixelDeltaFactory = org.allbinary.media.image.comparison.pixel.PixelDeltaFactory;

namespace org.allbinary.media.image.comparison;

public class ImageComparator
{
    private readonly ImageComparatorConstraintsInterface imageComparatorConstraintsInterface;
    public ImageComparator(ImageComparatorConstraintsInterface imageComparatorConstraintsInterface)
    {
        this.imageComparatorConstraintsInterface = imageComparatorConstraintsInterface;
    }

    // throws Exception
    private void process(ImageComparisonResult imageComparisonInfo, GPoint point)
    {
        bool isCollsionWithAvoidRectangles = this.imageComparatorConstraintsInterface.isCollisionWithAvoidRectangles(point);
        if (!isCollsionWithAvoidRectangles) {
            int rgb1 = imageComparisonInfo.getBufferedImages()[0].getRGB(point.getX(), point.getY());
            int rgb2 = imageComparisonInfo.getBufferedImages()[1].getRGB(point.getX(), point.getY());
            AutomaticCacheInterface automaticCacheInterface = ColorCacheFactory.getInstance();
            int? colorInteger = (rgb1).ToString();
            ColorCacheable colorCacheable = ((ColorCacheable) automaticCacheInterface.get(colorInteger));
            Color color = colorCacheable.getColor();
            int? colorInteger2 = (rgb2).ToString();
            ColorCacheable colorCacheable2 = ((ColorCacheable) automaticCacheInterface.get(colorInteger));
            Color color2 = colorCacheable.getColor();
            if (this.imageComparatorConstraintsInterface.isColorAllowed(0, point, color) || this.imageComparatorConstraintsInterface.isColorAllowed(1, point, color2)) {
                if (Math.Abs(rgb1 - rgb2) <= imageComparisonInfo.getTolerance()) {
                    imageComparisonInfo.pixelsThatMatch++;
                } else {
                    imageComparisonInfo.add(PixelDeltaFactory.getInstance(point.getX(), point.getY(), rgb1, rgb2));
                }
            }
        } else {
            imageComparisonInfo.pixelsIgnored++;
        }
    }

    // throws Exception
    public virtual ImageComparisonResult compare(BufferedImage bufferedImage1, BufferedImage bufferedImage2, long? frameOne, long? frameTwo, int tolerance)
    {
        return this.compare(bufferedImage1, bufferedImage2, frameOne, frameTwo, tolerance, StringUtil.getInstance().EMPTY_STRING);
    }

    // throws Exception
    public virtual ImageComparisonResult compare(BufferedImage bufferedImage1, BufferedImage bufferedImage2, long? frameOne, long? frameTwo, int tolerance, string name)
    {
        if (bufferedImage1 == null || bufferedImage2 == null) {
            throw new Exception("Input images must not be null.");
        }
        ImageComparisonResult imageComparisonInfo = new ImageComparisonResult(name, bufferedImage1, bufferedImage2, frameOne, frameTwo, tolerance);
        for (int indexY = 0; indexY < imageComparisonInfo.imageHeight; indexY++) {
            for (int indexX = 0; indexX < imageComparisonInfo.imageWidth; indexX++) {
                this.process(imageComparisonInfo, PointFactory.getInstance().createXY(indexX, indexY));
                if (imageComparisonInfo.getNonMatchingPixelVector().size() > this.imageComparatorConstraintsInterface.getMaxNonMatchingPixelDeltas()) {
                    break;
                }
            }
        }
        return imageComparisonInfo;
    }

}

