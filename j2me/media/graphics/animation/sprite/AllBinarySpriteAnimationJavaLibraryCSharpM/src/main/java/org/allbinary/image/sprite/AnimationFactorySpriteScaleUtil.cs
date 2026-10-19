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
//using Sprite = javax.microedition.lcdui.game.Sprite;
using SpriteFactory = org.allbinary.game.layer.SpriteFactory;
using OpenGLUtil = org.allbinary.graphics.opengles.OpenGLUtil;
using ImageCache = org.allbinary.image.ImageCache;
using ImageCacheFactory = org.allbinary.image.ImageCacheFactory;
using OpenGLESImageExclusionUtil = org.allbinary.image.opengles.OpenGLESImageExclusionUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using J2SEMath = org.allbinary.logic.math.J2SEMath;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ImageScaleUtil = org.allbinary.media.image.ImageScaleUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.image.sprite;

public class AnimationFactorySpriteScaleUtil
{
    private static readonly AnimationFactorySpriteScaleUtil instance = new AnimationFactorySpriteScaleUtil();
    public static AnimationFactorySpriteScaleUtil getInstance()
    {
        return AnimationFactorySpriteScaleUtil.instance;
    }

    private readonly ImageCache imageCache = ImageCacheFactory.getInstance();
    private readonly ImageScaleUtil imageScaleUtil = ImageScaleUtil.getInstance();
    private readonly OpenGLUtil openGLUtil = OpenGLUtil.getInstance();
    private readonly J2SEMath j2seMath = J2SEMath.getInstance();
    private readonly OpenGLESImageExclusionUtil openGLESImageExclusionUtil = OpenGLESImageExclusionUtil.getInstance();
    // throws Exception
    public virtual Sprite createImage(Image image, int width, int height, int scaleWidth, int scaleHeight)
    {
        SpriteFactory spriteFactory = SpriteFactory.getInstance();
        Sprite sprite = null;
        Image scaledImage = null;
        if (scaleWidth != 0 && scaleHeight != 0) {
            float scaleX = (((float) scaleWidth)) / (((float) width));
            float scaleY = (((float) scaleHeight)) / (((float) height));
            if ((scaleX == 1.0f && scaleY == 1.0f) || (scaleX == 0.0f || scaleY == 0.0f)) {
                scaledImage = this.openGLUtil.addImage(image);
                sprite = spriteFactory.createSprite(scaledImage, width, height);
            } else {
                if (this.openGLESImageExclusionUtil.isCustomScaling(image)) {
                    int width2 = this.j2seMath.round(((float) (scaleWidth)) - 0.5f);
                    int height2 = this.j2seMath.round(((float) (scaleHeight)) - 0.5f);
                    int multiplesOf16Width = width2 / 16;
                    int by16Width = multiplesOf16Width * 16;
                    scaleX = (((float) by16Width)) / ((float) width);
                    int multiplesOf16Height = height2 / 16;
                    int by16Height = multiplesOf16Height * 16;
                    scaleY = (((float) by16Height)) / ((float) height);
                    if (scaleWidth < width) {
                        scaleX = scaleX * 2.35f;
                    }
                    if (scaleHeight < height) {
                        scaleY = scaleY * 2.35f;
                    }
                }
                scaledImage = this.imageScaleUtil.createImage2(this.imageCache, image, scaleX, 1.0f, scaleY, 1.0f, true);
                sprite = spriteFactory.createSprite(scaledImage, ((int) (((float) width) * scaleX)), ((int) (((float) height) * scaleY)));
            }
        } else {
            scaledImage = this.openGLUtil.addImage(image);
            sprite = spriteFactory.createSprite(scaledImage, width, height);
        }
        return sprite;
    }

}

