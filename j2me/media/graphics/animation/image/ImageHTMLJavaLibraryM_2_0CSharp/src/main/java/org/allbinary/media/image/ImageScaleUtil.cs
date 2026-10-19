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
using ImageCache = org.allbinary.image.ImageCache;
using PlaynImmutableImage = org.microemu.device.playn.PlaynImmutableImage;
using PlaynMutableImage = org.microemu.device.playn.PlaynMutableImage;
using Canvas = playn.core.Canvas;
using CoreImage = playn.core.CoreImage;
using ImageImpl = playn.core.ImageImpl;
using HTMLPlaynUtil = playn.html.HTMLPlaynUtil;

namespace org.allbinary.media.image;

public class ImageScaleUtil
{
    private static readonly ImageScaleUtil instance = new ImageScaleUtil();
    public static ImageScaleUtil getInstance()
    {
        return ImageScaleUtil.instance;
    }

    private readonly HTMLPlaynUtil playnUtil = HTMLPlaynUtil.getInstance();
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
        float scaleX = scaleNominatorX / scaleDenominatorX;
        float scaleY = scaleNominatorY / scaleDenominatorY;
        return this.createImage(imageCache, originalImage, scaleX, scaleY, cached);
    }

    // throws Exception
    public virtual Image createImage(ImageCache imageCache, Image originalImage, float scaleX, float scaleY, bool cached)
    {
        return this.createImageInternal(originalImage, scaleX, scaleY);
    }

    // throws Exception
    public virtual Image createImageInternal(Image originalImage, float scaleX, float scaleY)
    {
        Image image = ImageCreationUtil.getInstance().createImageWH(((int) (originalImage.getWidth() * scaleX)), ((int) (originalImage.getHeight() * scaleY)));
        if (image.isMutable()) {
            CoreImage originalPlayNImage = null;
            if (originalImage.isMutable()) {
                PlaynMutableImage originalHTMLImage = ((PlaynMutableImage) originalImage);
                originalPlayNImage = ((CoreImage) originalHTMLImage.getImage());
            } else {
                PlaynImmutableImage originalHTMLImage = ((PlaynImmutableImage) originalImage);
                originalPlayNImage = ((CoreImage) originalHTMLImage.getImage());
            }
            PlaynMutableImage htmlImage = ((PlaynMutableImage) image);
            ImageImpl canvasImage = ((ImageImpl) htmlImage.getImage());
            Canvas canvas = this.playnUtil.getCanvas(canvasImage);
            canvas.drawScale(originalPlayNImage, 0, 0, image.getWidth(), image.getHeight(), 0, 0, originalImage.getWidth(), originalImage.getHeight());
            return image;
        } else {
            throw new Exception("Not Mutable");
        }
    }

}

