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
using AnimationFactoryInitializationVisitor = org.allbinary.animation.image.AnimationFactoryInitializationVisitor;
using BaseImageAnimationFactory = org.allbinary.animation.image.BaseImageAnimationFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ScaleProperties = org.allbinary.media.ScaleProperties;
using ImageJ2MEScaleUtil = org.allbinary.media.image.ImageJ2MEScaleUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.image;

public class AnimationFactoryImageScaleUtil
{
    private static readonly AnimationFactoryImageScaleUtil instance = new AnimationFactoryImageScaleUtil();
    public static AnimationFactoryImageScaleUtil getInstance()
    {
        return AnimationFactoryImageScaleUtil.instance;
    }

    private readonly ImageJ2MEScaleUtil imageScaleUtil = ImageJ2MEScaleUtil.getInstance();
    // throws Exception
    public virtual Image createImage(Image image, int width, int height, int scaleWidth, int scaleHeight)
    {
        Image scaledImage = null;
        if (scaleWidth != 0 && scaleHeight != 0) {
            float scaleX = (((float) scaleWidth)) / (((float) width));
            float scaleY = (((float) scaleHeight)) / (((float) height));
            if ((scaleX == 1.0f && scaleY == 1.0f) || (scaleX == 0.0f || scaleY == 0.0f)) {
                scaledImage = image;
            } else {
                int scaledWidth = ((int) (scaleX * ((float) width)));
                int scaledHeight = ((int) (scaleY * ((float) height)));
                scaledImage = this.imageScaleUtil.scale(image, scaledWidth, scaledHeight);
            }
        } else {
            scaledImage = image;
        }
        return scaledImage;
    }

    // throws Exception
    public virtual void processAdjust(BaseImageAnimationFactory baseImageAnimationFactory)
    {
        ScaleProperties scaleProperties = baseImageAnimationFactory.getScalePropertiesP();
        if (scaleProperties.scaleWidth != 0 && scaleProperties.scaleHeight != 0) {
            AnimationFactoryInitializationVisitor animationFactoryInitializationVisitor = baseImageAnimationFactory.getAnimationFactoryInitializationVisitorP();
            float scaleX = (((float) scaleProperties.scaleWidth)) / (((float) animationFactoryInitializationVisitor.width));
            float scaleY = (((float) scaleProperties.scaleHeight)) / (((float) animationFactoryInitializationVisitor.height));
            if ((scaleX == 1.0f && scaleY == 1.0f) || (scaleX == 0.0f || scaleY == 0.0f)) {
            } else {
                animationFactoryInitializationVisitor.dx = ((int) (animationFactoryInitializationVisitor.originalDx * scaleX));
                animationFactoryInitializationVisitor.dy = ((int) (animationFactoryInitializationVisitor.originalDy * scaleY));
            }
        } else {
        }
    }

}

