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
//using Image = javax.microedition.lcdui.Image;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using ImageCache = org.allbinary.image.ImageCache;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image;

public class ImageScaleUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageScaleUtil instance = new ImageScaleUtil();
    public static ImageScaleUtil getInstance()
    {
        return ImageScaleUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ImageCopyUtil imageCopyUtil = ImageCopyUtil.getInstance();
    private readonly GameFeatureFactory gameFeatureFactory = GameFeatureFactory.getInstance();
    private readonly Features features = Features.getInstance();
    private readonly string NO_COPY = "SWT should not copy images after initial loading as the alpha is not honored";
    private ImageScaleUtil()
    {
    }

    // throws Exception
    public virtual Image createImage2(ImageCache imageCache, Image originalImage, float scaleNominatorX, float scaleDenominatorX, float scaleNominatorY, float scaleDenominatorY, bool cached)
    {
        return this.createImage3(imageCache, originalImage, scaleNominatorX, scaleDenominatorX, scaleNominatorY, scaleDenominatorY, cached, true);
    }

    // throws Exception
    public virtual Image createImage3(ImageCache imageCache, Image originalImage, float scaleNominatorX, float scaleDenominatorX, float scaleNominatorY, float scaleDenominatorY, bool cached, bool mutable)
    {
        if (!this.features.isFeature(this.gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION)) {
            this.logUtil.putF(this.NO_COPY, this, this.commonStrings.CONSTRUCTOR);
            return originalImage;
        }
        int width = originalImage.getWidth();
        int height = originalImage.getHeight();
        float scaleX = scaleNominatorX / scaleDenominatorX;
        float scaleY = scaleNominatorY / scaleDenominatorY;
        Image scaledImage = this.imageCopyUtil.createImageWH(originalImage, ((int) (scaleX * ((float) width))), ((int) (scaleY * ((float) height))), mutable);
        return scaledImage;
    }

    // throws Exception
    public virtual void scale2(Image originalImage, Image[] originalImageArray, Image[] ximageToShowArray, int unused, float scaleX, float scaleY, float maxScaleX, float maxScaleY)
    {
        this.scale(originalImage, originalImageArray, ximageToShowArray, unused, scaleX, scaleY, maxScaleX, maxScaleY, true);
    }

    // throws Exception
    public virtual void scale(Image originalImage, Image[] originalImageArray, Image[] ximageToShowArray, int unused, float scaleX, float scaleY, float maxScaleX, float maxScaleY, bool mutable)
    {
        int width = originalImage.getWidth();
        int height = originalImage.getHeight();
        Image scaledImage = this.imageCopyUtil.createImageWH(originalImage, ((int) (scaleX * ((float) width))), ((int) (scaleY * ((float) height))), mutable);
        originalImageArray[0] = scaledImage;
    }

}

