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
using PlaynImmutableImage = org.microemu.device.playn.PlaynImmutableImage;
using PlaynMutableImage = org.microemu.device.playn.PlaynMutableImage;
using CanvasImage = playn.core.CanvasImage;
using CanvasSurface = playn.core.CanvasSurface;

namespace org.allbinary.media.image;

public class ImageRotationUtil
{
    private static readonly ImageRotationUtil instance = new ImageRotationUtil();
    public static ImageRotationUtil getInstance()
    {
        return ImageRotationUtil.instance;
    }

    private ImageRotationUtil()
    {
    }

    // throws Exception
    public virtual Image createRotatedImage(Image originalImage, int rotationInDegrees)
    {
        Image image = ImageCreationUtil.getInstance().getInstance(originalImage.getWidth(), originalImage.getHeight());
        if (image.isMutable()) {
            playn.core.Image originalPlayNImage = null;
            if (originalImage.isMutable()) {
                PlaynMutableImage originalHTMLImage = ((PlaynMutableImage) originalImage);
                originalPlayNImage = ((playn.core.Image) originalHTMLImage.getImage());
            } else {
                PlaynImmutableImage originalHTMLImage = ((PlaynImmutableImage) originalImage);
                originalPlayNImage = ((playn.core.Image) originalHTMLImage.getImage());
            }
            PlaynMutableImage htmlImage = ((PlaynMutableImage) image);
            CanvasImage canvasImage = ((CanvasImage) htmlImage.getImage());
            CanvasSurface canvasSurface = htmlImage.getCanvasSurface(canvasImage);
            canvasSurface.translate(originalPlayNImage.width() / 2, originalPlayNImage.height() / 2);
            canvasSurface.rotate(((float) Math.ToRadians(rotationInDegrees)));
            canvasSurface.drawImage(originalPlayNImage, -originalPlayNImage.width() / 2, -originalPlayNImage.height() / 2);
            return image;
        } else {
            throw new Exception("Not Mutable");
        }
    }

}

