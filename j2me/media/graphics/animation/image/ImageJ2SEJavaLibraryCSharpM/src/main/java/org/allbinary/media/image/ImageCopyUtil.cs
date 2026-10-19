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
//using BufferedImage = java.awt.image.BufferedImage;
//using Image = javax.microedition.lcdui.Image;
using Anchor = org.allbinary.graphics.Anchor;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using J2SEImmutableImage = org.microemu.device.j2se.J2SEImmutableImage;

namespace org.allbinary.media.image;

public class ImageCopyUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageCopyUtil instance = new ImageCopyUtil();
    public static ImageCopyUtil getInstance()
    {
        return ImageCopyUtil.instance;
    }

    private readonly ImageUtil imageUtil = ImageUtil.getInstance();
    private readonly ImageCreationUtil imageCreationUtil = ImageCreationUtil.getInstance();
    private ImageCopyUtil()
    {
    }

    private int anchor = Anchor.TOP_LEFT;
    // throws Exception
    public virtual Image createImageForRotation(Image originalImage)
    {
        return this.createImage(originalImage);
    }

    // throws Exception
    public virtual Image createImage(Image originalImage)
    {
        Image image = this.imageCreationUtil.createImageWH(originalImage.getWidth(), originalImage.getHeight());
        if (image.isMutable()) {
            image.getGraphics().drawImage(originalImage, 0, 0, this.anchor);
            return image;
        } else {
            throw new Exception("Not Mutable");
        }
    }

    // throws Exception
    public virtual Image createImageScale(Image originalImage, float canvasScale, bool resize)
    {
        int newWidth = ((int) (originalImage.getWidth() * canvasScale));
        int newHeight = ((int) (originalImage.getHeight() * canvasScale));
        if (resize) {
            if (newWidth < newHeight) {
                newWidth = newHeight;
            }
            if (newHeight < newWidth) {
                newHeight = newWidth;
            }
        }
        BufferedImage originalBufferedImage = this.imageUtil.getBufferedImage(originalImage);
        BufferedImage bufferedImage = this.imageUtil.createBufferedImageWithLargerCanvas(originalBufferedImage, newWidth, newHeight);
        J2SEImmutableImage image = new J2SEImmutableImage(bufferedImage);
        return image;
    }

}

