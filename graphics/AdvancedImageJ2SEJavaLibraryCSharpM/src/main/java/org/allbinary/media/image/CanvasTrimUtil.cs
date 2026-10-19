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
//using IOException = java.io.IOException;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.media.image;

public class CanvasTrimUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly CanvasTrimUtil instance = new CanvasTrimUtil();
    public static CanvasTrimUtil getInstance()
    {
        return CanvasTrimUtil.instance;
    }

    private readonly StringUtil stringUtil = StringUtil.getInstance();
    // throws IOException
    public virtual void process(ImageProcessorInput imageProcessorInput, int cutCanvasFromLeftReduction, int cutCanvasFromTopReduction, int cutCanvasFromRightReduction, int cutCanvasFromBottomReduction, ImageProcessedVisitor visitor)
    {
        BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
        BufferedImage[] subBufferedImageArray = new BufferedImage[bufferedImageArray.Length];
        int size = bufferedImageArray.Length;
        BufferedImage bufferedImage = null;
        for (int index = 0; index < size; index++) {
            bufferedImage = bufferedImageArray[index];
            subBufferedImageArray[index] = bufferedImage.getSubimage(cutCanvasFromLeftReduction, cutCanvasFromTopReduction, bufferedImage.getWidth() - cutCanvasFromLeftReduction - cutCanvasFromRightReduction, bufferedImage.getHeight() - cutCanvasFromTopReduction - cutCanvasFromBottomReduction);
            visitor.visit(subBufferedImageArray[index], this.stringUtil.EMPTY_STRING, index);
        }
    }

}

