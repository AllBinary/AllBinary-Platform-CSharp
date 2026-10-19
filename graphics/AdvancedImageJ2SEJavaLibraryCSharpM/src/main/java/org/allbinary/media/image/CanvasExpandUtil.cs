/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.media.image;

public class CanvasExpandUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly CanvasExpandUtil instance = new CanvasExpandUtil();
    public static CanvasExpandUtil getInstance()
    {
        return CanvasExpandUtil.instance;
    }

    private readonly StringUtil stringUtil = StringUtil.getInstance();
    // throws Exception
    public virtual void process(ImageProcessorInput imageProcessorInput, int increaseX, int increaseY, ImageProcessedVisitor visitor)
    {
        ImageUtil imageUtil = ImageUtil.getInstance();
        BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
        BufferedImage[] subBufferedImageArray = new BufferedImage[bufferedImageArray.Length];
        int size = bufferedImageArray.Length;
        BufferedImage bufferedImage = null;
        for (int index = 0; index < size; index++) {
            bufferedImage = bufferedImageArray[index];
            subBufferedImageArray[index] = imageUtil.createBufferedImage(bufferedImage, bufferedImage.getWidth() + increaseX, bufferedImage.getHeight() + increaseY, false);
            visitor.visit(subBufferedImageArray[index], this.stringUtil.EMPTY_STRING, index);
        }
    }

}

