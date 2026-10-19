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
//using Graphics2D = java.awt.Graphics2D;
//using AffineTransform = java.awt.geom.AffineTransform;
//using BufferedImage = java.awt.image.BufferedImage;
//using Image = javax.microedition.lcdui.Image;
using ImageCache = org.allbinary.image.ImageCache;

namespace org.allbinary.media.image;

public class ImageScaleUtil
{
    private static readonly ImageScaleUtil instance = new ImageScaleUtil();
    public static ImageScaleUtil getInstance()
    {
        return ImageScaleUtil.instance;
    }

    private readonly ImageUtil imageUtil = ImageUtil.getInstance();
    private readonly ImageJ2SEUtil imageJ2SEUtil = ImageJ2SEUtil.getInstance();
    private readonly ImageCreationUtil imageCreationUtil = ImageCreationUtil.getInstance();
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
        int width = originalImage.getWidth();
        int height = originalImage.getHeight();
        float scaleX = scaleNominatorX / scaleDenominatorX;
        float scaleY = scaleNominatorY / scaleDenominatorY;
        Image image = null;
        if (cached) {
            image = imageCache.get(this.GetType().FullName, ((int) (((float) width) * scaleX)), ((int) (((float) height) * scaleY)));
        } else {
            image = imageCache.get("createImage", ((int) (((float) width) * scaleX)), ((int) (((float) height) * scaleY)));
        }
        this.scale(originalImage, image, scaleX, scaleY, true);
        return image;
    }

    // throws Exception
    public virtual void scale2(Image originalImage, Image[] originalImageArray, Image[] ximageToShowArray, int unused, float scaleX, float scaleY, float maxScaleX, float maxScaleY)
    {
        if (maxScaleX * originalImage.getWidth() > originalImageArray[0].getWidth() || maxScaleY * originalImage.getHeight() > originalImageArray[0].getHeight()) {
            originalImageArray[0] = this.imageCreationUtil.createImage(originalImage.getWidth(), originalImage.getHeight(), maxScaleX, maxScaleY);
        }
        this.scale(originalImage, originalImageArray[0], scaleX, scaleY, false);
    }

    public virtual void scale(Image originalImage, Image newMaxSizeImage, float scaleX, float scaleY, bool clear)
    {
        BufferedImage bufferedImage = this.imageUtil.getBufferedImage(originalImage);
        BufferedImage newBufferedImage = this.imageUtil.getBufferedImage(newMaxSizeImage);
        AffineTransform at = AffineTransform.getScaleInstance(scaleX, scaleY);
        Graphics2D g = newBufferedImage.createGraphics();
        if (clear) {
            g.setBackground(this.imageJ2SEUtil.TRANSPARENT_COLOR);
            g.clearRect(0, 0, newBufferedImage.getWidth(), newBufferedImage.getHeight());
        }
        g.drawRenderedImage(bufferedImage, at);
        g.dispose();
    }

}

