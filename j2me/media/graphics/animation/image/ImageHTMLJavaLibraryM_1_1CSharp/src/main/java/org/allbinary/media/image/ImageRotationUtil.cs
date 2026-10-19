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

    public virtual Image rotateImage(Image originalImage, Image image, int totalAngle)
    {
        if (image.isMutable()) {
            PlaynMutableImage htmlImage = ((PlaynMutableImage) image);
            CanvasImage canvasImage = ((CanvasImage) htmlImage.getImage());
            CanvasSurface canvasSurface = htmlImage.getCanvasSurface(canvasImage);
            canvasSurface.translate(originalImage.getWidth() / 2, originalImage.getHeight() / 2);
            Image image2 = this.rotateImageCanvasSurface(originalImage, image, canvasSurface, totalAngle);
            this.drawImage(originalImage, image, canvasSurface);
            return image2;
        } else {
            return null;
        }
    }

    public virtual Image rotateImageCanvasSurfaceClear(Image originalImage, Image image, CanvasSurface canvasSurface, int totalAngle)
    {
        if (image.isMutable()) {
            canvasSurface.translate(-originalImage.getWidth() / 2, -originalImage.getHeight() / 2);
            canvasSurface.clear();
            canvasSurface.translate(originalImage.getWidth() / 2, originalImage.getHeight() / 2);
            return this.rotateImageCanvasSurface(originalImage, image, canvasSurface, totalAngle);
        } else {
            return null;
        }
    }

    public virtual Image rotateImageCanvasSurface(Image originalImage, Image image, CanvasSurface canvasSurface, int totalAngle)
    {
        if (image.isMutable()) {
            canvasSurface.rotate(((float) Math.ToRadians(totalAngle)));
            return image;
        } else {
            return null;
        }
    }

    public virtual void drawImage(Image originalImage, Image image, CanvasSurface canvasSurface)
    {
        playn.core.Image originalPlayNImage = null;
        if (originalImage.isMutable()) {
            PlaynMutableImage originalHTMLImage = ((PlaynMutableImage) originalImage);
            originalPlayNImage = ((playn.core.Image) originalHTMLImage.getImage());
        } else {
            PlaynImmutableImage originalHTMLImage = ((PlaynImmutableImage) originalImage);
            originalPlayNImage = ((playn.core.Image) originalHTMLImage.getImage());
        }
        canvasSurface.drawImage(originalPlayNImage, -originalImage.getWidth() / 2, -originalImage.getHeight() / 2);
    }

    // throws Exception
    public virtual Image createRotatedImage(Image originalImage, int rotationInDegrees)
    {
        Image image = ImageCreationUtil.getInstance().createImageWH(originalImage.getWidth(), originalImage.getHeight());
        Image rotatedImage = this.rotateImage(originalImage, image, rotationInDegrees);
        if (rotatedImage == null) {
            throw new Exception("Not Mutable");
        }
        return rotatedImage;
    }

}

