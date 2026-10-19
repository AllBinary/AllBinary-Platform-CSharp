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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image;

public class ImageArrayRotationUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageArrayRotationUtil instance = new ImageArrayRotationUtil();
    public static ImageArrayRotationUtil getInstance()
    {
        return ImageArrayRotationUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string TOTAL_ANGLE = "totalAngle: ";
    // throws IOException
    public virtual void process(ImageProcessorInput imageProcessorInput, string input, ImageProcessedVisitor visitor)
    {
        int? totalAngle = null;
        if (input == this.commonStrings.UP) {
            totalAngle = (-90).ToString();
        } else if (input == this.commonStrings.DOWN) {
            totalAngle = (90).ToString();
        } else {
            totalAngle = (input).ToString();
        }
        BufferedImage generatedBufferedImage = null;
        BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
        for (int index = 0; index < bufferedImageArray.Length; index++) {
            this.logUtil.putF(this.TOTAL_ANGLE + totalAngle, this, this.commonStrings.RUN);
            generatedBufferedImage = ImageJ2SERotationUtil.getInstance().getRotatedImage(bufferedImageArray[index], ((int) totalAngle));
            visitor.visit(generatedBufferedImage, input, index);
        }
    }

}

