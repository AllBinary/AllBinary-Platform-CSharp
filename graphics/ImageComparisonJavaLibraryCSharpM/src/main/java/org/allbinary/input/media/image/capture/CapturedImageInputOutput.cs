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
using ImageUtil = org.allbinary.media.image.ImageUtil;
using BufferedImageFrameCacheable = org.allbinary.media.image.cache.BufferedImageFrameCacheable;
using ImageIOInterface = org.allbinary.media.image.io.ImageIOInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.media.image.capture;

public class CapturedImageInputOutput : ImageIOInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    // throws Exception
    public virtual void save(long? frame)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        BufferedImageFrameCacheable capturedBufferedImageCacheable = (((BufferedImageFrameCacheable) (((AutomaticCacheInterface) CapturedBufferedImagesCacheSingleton.getInstance())).get(frame)));
        this.logUtil.putF(("Saving: " + capturedBufferedImageCacheable.ToString()), this, commonStrings.SAVE);
        this.save(capturedBufferedImageCacheable.getBufferedImage(), frame);
    }

    public virtual void save(BufferedImage bufferedImage, long? frame)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        ImageUtil imageUtil = ImageUtil.getInstance();
        StringMaker filePathStringBuffer = new StringMaker();
        filePathStringBuffer.append(ImageOutputData.SAVE_PATH);
        filePathStringBuffer.append(LongUtil.fillIn(frame.ToString()));
        filePathStringBuffer.append(MediaDataFactory.getInstance().JPG.getExtension());
        string filePath = filePathStringBuffer.ToString();
        this.logUtil.putF(("Image File Path: " + filePath + imageUtil.toString(bufferedImage)), this, commonStrings.SAVE);
        ImagePersistanceUtil imagePersistanceUtil = ImagePersistanceUtil.getInstance();
        imagePersistanceUtil.saveWithImageIO(filePath, bufferedImage);
    }

}

