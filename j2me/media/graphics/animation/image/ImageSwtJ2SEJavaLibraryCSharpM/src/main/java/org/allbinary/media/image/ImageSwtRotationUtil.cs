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
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using SWT = org.eclipse.swt.SWT;
using GC = org.eclipse.swt.graphics.GC;
using ImageData = org.eclipse.swt.graphics.ImageData;

namespace org.allbinary.media.image;

public class ImageSwtRotationUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageSwtRotationUtil instance = new ImageSwtRotationUtil();
    public static ImageSwtRotationUtil getInstance()
    {
        return ImageSwtRotationUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ImageUtil imageUtil = ImageUtil.getInstance();
    private readonly GameFeatureFactory gameFeatureFactory = GameFeatureFactory.getInstance();
    private readonly Features features = Features.getInstance();
    private readonly string NO_COPY = "SWT should not copy images after initial loading as the alpha is not honored";
    private ImageSwtRotationUtil()
    {
    }

    public virtual org.eclipse.swt.graphics.Image getRotatedImage(org.eclipse.swt.graphics.Image bufferedImage, int totalAngle)
    {
        if (!this.features.isFeature(this.gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION)) {
            this.logUtil.putF(this.NO_COPY, this, this.commonStrings.CONSTRUCTOR);
            return bufferedImage;
        }
        return bufferedImage;
    }

    private org.eclipse.swt.graphics.Image getRotatedImage2(org.eclipse.swt.graphics.Image bufferedImage, org.eclipse.swt.graphics.Image newBufferedImage, GC gc, float angle)
    {
        if (!this.features.isFeature(this.gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION)) {
            this.logUtil.putF(this.NO_COPY, this, this.commonStrings.CONSTRUCTOR);
            return bufferedImage;
        }
        return bufferedImage;
    }

    public virtual org.eclipse.swt.graphics.Image rotateImage(org.eclipse.swt.graphics.Image originalSwtImage, org.eclipse.swt.graphics.Image newSwtImage, GC gc, int totalAngle)
    {
        return this.getRotatedImage2(originalSwtImage, newSwtImage, gc, totalAngle);
    }

    public virtual org.eclipse.swt.graphics.Image getRotatedImageSWT(org.eclipse.swt.graphics.Image bufferedImage, org.eclipse.swt.graphics.Image newSwtImage, GC gc, int totalAngle)
    {
        return this.getRotatedImage2(bufferedImage, newSwtImage, gc, totalAngle);
    }

    public virtual org.eclipse.swt.graphics.Image[] getRotatedImages(org.eclipse.swt.graphics.Image bufferedImage, int numberOfFrames, int totalAngle)
    {
        org.eclipse.swt.graphics.Image[] bufferedImageArray = new org.eclipse.swt.graphics.Image[numberOfFrames];
        int angle = 0;
        int size = bufferedImageArray.Length;
        for (int index = 0; index < size; index++) {
            angle = (totalAngle / size) * index;
            bufferedImageArray[index] = this.getRotatedImage(bufferedImage, angle);
        }
        return bufferedImageArray;
    }

    public virtual org.eclipse.swt.graphics.Image createSpriteImage(org.eclipse.swt.graphics.Image[] bufferedImageArray)
    {
        int columns = 9;
        int rows = 0;
        int size = bufferedImageArray.Length;
        if (size < columns) {
            columns = size;
        }
        rows = (size / columns);
        if (size % columns != 0) {
            rows++;
        }
        org.eclipse.swt.graphics.Image firstBufferedImage = bufferedImageArray[0];
        ImageData imageData = firstBufferedImage.getImageData();
        org.eclipse.swt.graphics.Image bufferedImage = this.imageUtil.create(imageData.width * columns, imageData.height * rows);
        GC gc = new GC(bufferedImage);
        gc.setAntialias(SWT.ON);
        gc.setInterpolation(SWT.HIGH);
        int columnIndex = 0;
        int rowIndex = 0;
        org.eclipse.swt.graphics.Image nextBufferedImage = null;
        for (int index = 0; index < size; index++) {
            if (index / 9 != 0 && index % 9 == 0) {
                rowIndex++;
                columnIndex = 0;
            }
            nextBufferedImage = bufferedImageArray[index];
            imageData = nextBufferedImage.getImageData();
            gc.drawImage(bufferedImage, 0, 0, bufferedImage.getBounds().width, bufferedImage.getBounds().height, imageData.width * columnIndex, imageData.height * rowIndex, imageData.width, imageData.height);
            columnIndex++;
        }
        gc.dispose();
        return bufferedImage;
    }

}

