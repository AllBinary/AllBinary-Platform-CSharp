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
using PoolInterface = org.allbinary.logic.util.cache.PoolInterface;
using BufferedImageCacheable = org.allbinary.media.image.cache.BufferedImageCacheable;
using BufferedImageInfo = org.allbinary.media.image.cache.BufferedImageInfo;
using BufferedImageInfoFactory = org.allbinary.media.image.cache.BufferedImageInfoFactory;
using BufferedImagePoolSingleton = org.allbinary.media.image.cache.BufferedImagePoolSingleton;
using PixelDelta = org.allbinary.media.image.comparison.pixel.PixelDelta;

namespace org.allbinary.media.image.comparison;

public class ChangedPixelsUtil
{
    private static readonly int START_X = 0;
    private static readonly int START_Y = 0;
    private static readonly int OFFSET = 0;
    private static readonly int SCAN_SIZE = 0;
    private static readonly int[] CLEAR_INT_ARRAY = new int[1800 * 1600];
    private ChangedPixelsUtil()
    {
    }

    // throws Exception
    public static BufferedImageCacheable[] generateBufferedImageChacheables(ImageComparisonResult imageComparisonInfo)
    {
        BufferedImageCacheable[] bufferedImageCacheables = null;
        BufferedImage originalBufferedImage = imageComparisonInfo.getBufferedImages()[0];
        bufferedImageCacheables = new BufferedImageCacheable[2];
        BufferedImageInfo bufferedImageInfo = BufferedImageInfoFactory.getInstance(imageComparisonInfo.imageWidth, imageComparisonInfo.imageHeight, originalBufferedImage.getType());
        PoolInterface poolInterface = BufferedImagePoolSingleton.getInstance();
        for (int index = 0; index < bufferedImageCacheables.Length; index++) {
            BufferedImageCacheable bufferedImageCacheable = ((BufferedImageCacheable) poolInterface.remove(bufferedImageInfo));
            bufferedImageCacheables[index] = bufferedImageCacheable;
            bufferedImageCacheables[index].getBufferedImage().setRGB(ChangedPixelsUtil.START_X, ChangedPixelsUtil.START_Y, bufferedImageInfo.getWidth(), bufferedImageInfo.getHeight(), ChangedPixelsUtil.CLEAR_INT_ARRAY, ChangedPixelsUtil.OFFSET, ChangedPixelsUtil.SCAN_SIZE);
        }
        BasicArrayList vector = imageComparisonInfo.getNonMatchingPixelVector();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            PixelDelta pixelDelta = ((PixelDelta) vector.get(index));
            if (pixelDelta.getColorDelta() == null) {
                Console.Write("ColorDelta");
                Environment.Exit(0);
            }
            bufferedImageCacheables[0].getBufferedImage().setRGB(pixelDelta.getPoint().getX(), pixelDelta.getPoint().getY(), pixelDelta.getColorDelta().getRgb1());
            bufferedImageCacheables[1].getBufferedImage().setRGB(pixelDelta.getPoint().getX(), pixelDelta.getPoint().getY(), pixelDelta.getColorDelta().getRgb2());
        }
        return bufferedImageCacheables;
    }

}

