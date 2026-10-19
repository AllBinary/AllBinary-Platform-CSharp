/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2023 AllBinary
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
using PlaynImmutableImage = org.microemu.device.playn.PlaynImmutableImage;
using PlaynMutableImage = org.microemu.device.playn.PlaynMutableImage;
using Canvas = playn.core.Canvas;
using CoreImage = playn.core.CoreImage;
using ImageImpl = playn.core.ImageImpl;
using PlayN = playn.core.PlayN;
using HtmlGraphics = playn.html.HtmlGraphics;
using HtmlImage = playn.html.HtmlImage;

namespace org.allbinary.media.image;

public class ImageJ2MEScaleUtil
{
    private static readonly ImageJ2MEScaleUtil instance = new ImageJ2MEScaleUtil();
    public static ImageJ2MEScaleUtil getInstance()
    {
        return ImageJ2MEScaleUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private ImageJ2MEScaleUtil()
    {
    }

    // throws Exception
    public virtual Image[] scaleArray(Image[] images, int width, int height)
    {
        Image[] scaledImages = new Image[images.Length];
        for (int index = images.Length; --index >= 0; ) {
            scaledImages[index] = this.scale(images[index], width, height);
        }
        return scaledImages;
    }

    // throws Exception
    public virtual Image scale(Image image, int width, int height)
    {
        CoreImage originalPlayNImage = null;
        if (image.isMutable()) {
            PlaynMutableImage originalHTMLImage = ((PlaynMutableImage) image);
            originalPlayNImage = ((CoreImage) originalHTMLImage.getImage());
        } else {
            PlaynImmutableImage originalHTMLImage = ((PlaynImmutableImage) image);
            originalPlayNImage = ((CoreImage) originalHTMLImage.getImage());
        }
        Image scaledImage = Image.createImageWH(width, height);
        PlaynMutableImage htmlImage = ((PlaynMutableImage) scaledImage);
        ImageImpl scaledPlayNImage = ((ImageImpl) htmlImage.getImage());
        Canvas canvas = (((HtmlGraphics) PlayN.getInstance().graphics())).get(((HtmlImage) scaledPlayNImage));
        (((ImageImpl) originalPlayNImage)).draw(canvas.gc(), 0, 0, scaledImage.getWidth(), scaledImage.getHeight(), 0, 0, image.getWidth(), image.getHeight());
        return scaledImage;
    }

}

