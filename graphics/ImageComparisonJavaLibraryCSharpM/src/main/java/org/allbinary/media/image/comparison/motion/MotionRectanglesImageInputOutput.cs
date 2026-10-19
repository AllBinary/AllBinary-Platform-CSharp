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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ImageOutputData = org.allbinary.input.automation.ImageOutputData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LongUtil = org.allbinary.logic.java.number.LongUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AutomaticCacheInterface = org.allbinary.logic.util.cache.AutomaticCacheInterface;
using PoolInterface = org.allbinary.logic.util.cache.PoolInterface;
using MediaDataFactory = org.allbinary.logic.visual.media.MediaDataFactory;
using ImagePersistanceUtil = org.allbinary.media.image.ImagePersistanceUtil;
using BufferedImageCacheable = org.allbinary.media.image.cache.BufferedImageCacheable;
using BufferedImageInfo = org.allbinary.media.image.cache.BufferedImageInfo;
using BufferedImageInfoFactory = org.allbinary.media.image.cache.BufferedImageInfoFactory;
using BufferedImagePoolSingleton = org.allbinary.media.image.cache.BufferedImagePoolSingleton;
using ImageComparisonResult = org.allbinary.media.image.comparison.ImageComparisonResult;
using ImageIOInterface = org.allbinary.media.image.io.ImageIOInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image.comparison.motion;

public class MotionRectanglesImageInputOutput : ImageIOInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly int NUMBER_OF_IMAGES = 1;
    public MotionRectanglesImageInputOutput()
    {
    }

    // throws Exception
    public virtual void save(long? frame)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        MotionRectanglesResultsFrameCacheable motionRectanglesResultsFrameCacheable = ((MotionRectanglesResultsFrameCacheable) (((AutomaticCacheInterface) AllMotionRectanglesResultsCacheSingleton.getInstance())).get(frame));
        if (motionRectanglesResultsFrameCacheable != null) {
            MotionRectangles motionRectangles = motionRectanglesResultsFrameCacheable.getMotionRectangles();
            this.save(motionRectangles, frame);
            motionRectanglesResultsFrameCacheable = ((MotionRectanglesResultsFrameCacheable) (((AutomaticCacheInterface) ConsolidatedMotionRectanglesResultsCacheSingleton.getInstance())).get(frame));
            motionRectangles = motionRectanglesResultsFrameCacheable.getMotionRectangles();
            this.save(motionRectangles, frame);
            motionRectanglesResultsFrameCacheable = ((MotionRectanglesResultsFrameCacheable) (((AutomaticCacheInterface) ConstrainedMotionRectanglesResultsCacheSingleton.getInstance())).get(frame));
            motionRectangles = motionRectanglesResultsFrameCacheable.getMotionRectangles();
            this.save(motionRectangles, frame);
        } else {
            this.logUtil.putF("No Motion Rectangle Results for Frame: " + frame, this, commonStrings.SAVE);
        }
    }

    // throws Exception
    public virtual void save(MotionRectangles motionRectangles, long? frame)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        StringMaker filePathStringBuffer = new StringMaker();
        filePathStringBuffer.append(ImageOutputData.SAVE_PATH);
        filePathStringBuffer.append(LongUtil.fillIn(frame.ToString()));
        filePathStringBuffer.append("_");
        filePathStringBuffer.append(motionRectangles.getName());
        StringMaker filePathStringBuffer1 = new StringMaker();
        filePathStringBuffer1.append(filePathStringBuffer.ToString());
        filePathStringBuffer1.append("_1");
        filePathStringBuffer1.append(MediaDataFactory.getInstance().JPG.getExtension());
        StringMaker filePathStringBuffer2 = new StringMaker();
        filePathStringBuffer2.append(filePathStringBuffer.ToString());
        filePathStringBuffer2.append("_2");
        filePathStringBuffer2.append(MediaDataFactory.getInstance().JPG.getExtension());
        StringMaker filePathStringBuffer3 = new StringMaker();
        filePathStringBuffer3.append(filePathStringBuffer.ToString());
        filePathStringBuffer3.append(MediaDataFactory.getInstance().JPG.getExtension());
        this.logUtil.putF("Motion Image File Path 1: " + filePathStringBuffer1.ToString(), this, commonStrings.SAVE);
        this.logUtil.putF("Motion Image File Path 2: " + filePathStringBuffer2.ToString(), this, commonStrings.SAVE);
        this.logUtil.putF("Motion Image File Path 2: " + filePathStringBuffer3.ToString(), this, commonStrings.SAVE);
        BufferedImageCacheable[] bufferedImageCacheables = new BufferedImageCacheable[this.NUMBER_OF_IMAGES];
        ImageComparisonResult imageComparisonInfo = motionRectangles.getImageComparisonResult();
        BufferedImage originalBufferedImage = imageComparisonInfo.getBufferedImages()[0];
        BufferedImageInfo bufferedImageInfo = BufferedImageInfoFactory.getInstance(imageComparisonInfo.imageWidth, imageComparisonInfo.imageHeight, originalBufferedImage.getType());
        PoolInterface poolInterface = BufferedImagePoolSingleton.getInstance();
        for (int index = 0; index < this.NUMBER_OF_IMAGES; index++) {
            bufferedImageCacheables[index] = ((BufferedImageCacheable) poolInterface.remove(bufferedImageInfo));
        }
        bufferedImageCacheables[0].getBufferedImage().setData(imageComparisonInfo.getBufferedImages()[1].getData());
        if (this.NUMBER_OF_IMAGES > 1) {
            bufferedImageCacheables[1].getBufferedImage().setData(imageComparisonInfo.getBufferedImages()[1].getData());
        }
        Graphics[] bufferedImageGraphicsArray = null;
        bufferedImageGraphicsArray = new Graphics[this.NUMBER_OF_IMAGES];
        for (int index = 0; index < this.NUMBER_OF_IMAGES; index++) {
            bufferedImageGraphicsArray[index] = bufferedImageCacheables[index].getBufferedImage().getGraphics();
        }
        BasicArrayList rectangelList = motionRectangles.getVector();
        int size = rectangelList.size();
        for (int index2 = 0; index2 < size; index2++) {
            MotionRectangle motionRectangle = ((MotionRectangle) rectangelList.get(index2));
            Rectangle rectangle = motionRectangle.getRectangle();
            for (int index = 0; index < this.NUMBER_OF_IMAGES; index++) {
                bufferedImageGraphicsArray[index].setColor(Color.ORANGE);
                bufferedImageGraphicsArray[index].drawRect(rectangle.x, rectangle.y, rectangle.width, rectangle.height);
            }
        }
        ImagePersistanceUtil imagePersistanceUtil = ImagePersistanceUtil.getInstance();
        if (this.NUMBER_OF_IMAGES > 1) {
            imagePersistanceUtil.saveWithImageIO(filePathStringBuffer1.ToString(), bufferedImageCacheables[1].getBufferedImage());
        }
        imagePersistanceUtil.saveWithImageIO(filePathStringBuffer2.ToString(), bufferedImageCacheables[0].getBufferedImage());
        if (this.NUMBER_OF_IMAGES > 2) {
            imagePersistanceUtil.saveWithImageIO(filePathStringBuffer3.ToString(), bufferedImageCacheables[2].getBufferedImage());
        }
    }

}

