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
//using Image = javax.microedition.lcdui.Image;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ImageScaleUtil = org.allbinary.media.image.ImageScaleUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.animation.image;

public class ScaleProcessor : ScaleBaseProcessor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ScaleProcessor instanceC = new ScaleProcessor();
    public static ScaleBaseProcessor getInstance()
    {
        return ScaleProcessor.instanceC;
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ImageScaleUtil imageScaleUtil = ImageScaleUtil.getInstance();
    public override void update(Image originalImage, Image[] originalImageArray, Image[] ximageToShowArray, int unused, float scaleX, float scaleY, float maxScaleX, float maxScaleY)
    {
        try {
            this.imageScaleUtil.scale2(originalImage, originalImageArray, ximageToShowArray, unused, scaleX, scaleY, maxScaleX, maxScaleY);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.UPDATE, e);
        }
    }

}

