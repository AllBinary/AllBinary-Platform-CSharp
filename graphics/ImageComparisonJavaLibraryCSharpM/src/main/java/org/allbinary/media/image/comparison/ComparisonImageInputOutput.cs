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
using ImageOutputData = org.allbinary.input.automation.ImageOutputData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LongUtil = org.allbinary.logic.java.number.LongUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AutomaticCacheInterface = org.allbinary.logic.util.cache.AutomaticCacheInterface;
using MediaDataFactory = org.allbinary.logic.visual.media.MediaDataFactory;
using ImagePersistanceUtil = org.allbinary.media.image.ImagePersistanceUtil;
using BufferedImageCacheable = org.allbinary.media.image.cache.BufferedImageCacheable;
using ImageIOInterface = org.allbinary.media.image.io.ImageIOInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image.comparison;

public class ComparisonImageInputOutput : ImageIOInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly string ROOT_NAME = "_Changed_";
    public ComparisonImageInputOutput()
    {
    }

    // throws Exception
    public virtual void save(long? frame)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        if (frame > 0) {
            ImageComparisonResultFrameCacheable imageComparisonResultFrameCacheable = ((ImageComparisonResultFrameCacheable) (((AutomaticCacheInterface) ImageComparisonResultCacheSingleton.getInstance())).get(frame));
            if (imageComparisonResultFrameCacheable != null) {
                ImageComparisonResult imageComparisonResult = imageComparisonResultFrameCacheable.getImageComparisonResult();
                this.save(imageComparisonResult, imageComparisonResultFrameCacheable.getFrame());
            } else {
                this.logUtil.putF("Comparison Results Not Available for Output: " + frame, this, commonStrings.SAVE);
            }
        } else {
            this.logUtil.putF("No Comparison Results: for first frame: " + frame, this, commonStrings.SAVE);
        }
    }

    // throws Exception
    public virtual void save(ImageComparisonResult imageComparisonResult, long? frame)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        StringMaker filePathStringBuffer = new StringMaker();
        filePathStringBuffer.append(ImageOutputData.SAVE_PATH);
        filePathStringBuffer.append(LongUtil.fillIn(frame.ToString()));
        filePathStringBuffer.append(ComparisonImageInputOutput.ROOT_NAME);
        StringMaker filePathStringBuffer1 = new StringMaker();
        filePathStringBuffer1.append(filePathStringBuffer.ToString());
        filePathStringBuffer1.append("_1");
        filePathStringBuffer1.append(MediaDataFactory.getInstance().JPG.getExtension());
        string filePath1 = filePathStringBuffer1.ToString();
        StringMaker filePathStringBuffer2 = new StringMaker();
        filePathStringBuffer2.append(filePathStringBuffer.ToString());
        filePathStringBuffer2.append("_2");
        filePathStringBuffer2.append(MediaDataFactory.getInstance().JPG.getExtension());
        string filePath2 = filePathStringBuffer2.ToString();
        BufferedImageCacheable[] bufferedImageCacheables = ChangedPixelsUtil.generateBufferedImageChacheables(imageComparisonResult);
        this.logUtil.putF("Comparison Image File Path 1: " + filePath1, this, commonStrings.SAVE);
        this.logUtil.putF("Comparison Image File Path 2: " + filePath2, this, commonStrings.SAVE);
        BufferedImage[] bufferedImageArray = new BufferedImage[2];
        bufferedImageArray[0] = bufferedImageCacheables[0].getBufferedImage();
        bufferedImageArray[1] = bufferedImageCacheables[1].getBufferedImage();
        ImagePersistanceUtil imagePersistanceUtil = ImagePersistanceUtil.getInstance();
        imagePersistanceUtil.saveWithImageIO(filePath1, bufferedImageArray[0]);
        imagePersistanceUtil.saveWithImageIO(filePath2, bufferedImageArray[1]);
    }

}

