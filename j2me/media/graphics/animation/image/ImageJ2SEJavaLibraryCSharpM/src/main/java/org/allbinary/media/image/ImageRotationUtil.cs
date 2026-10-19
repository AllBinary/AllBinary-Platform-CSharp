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
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using J2SEImmutableImage = org.microemu.device.j2se.J2SEImmutableImage;
using J2SEMutableImage = org.microemu.device.j2se.J2SEMutableImage;

namespace org.allbinary.media.image;

public class ImageRotationUtil
{
    private static readonly ImageRotationUtil instance = new ImageRotationUtil();
    public static ImageRotationUtil getInstance()
    {
        return ImageRotationUtil.instance;
    }

    private readonly ImageJ2SERotationUtil imageJ2SERotationUtil = ImageJ2SERotationUtil.getInstance();
    private ImageRotationUtil()
    {
    }

    public virtual void rotateImage(Image originalImage, Image image, int totalAngle)
    {
        if (image.isMutable()) {
            J2SEMutableImage j2seImage = ((J2SEMutableImage) image);
            BufferedImage newBufferedImage = ((BufferedImage) j2seImage.getImage());
            java.awt.Image originalAwtImage = null;
            if (originalImage.isMutable()) {
                J2SEMutableImage originalJ2SEImage = ((J2SEMutableImage) originalImage);
                originalAwtImage = ((java.awt.Image) originalJ2SEImage.getImage());
            } else {
                J2SEImmutableImage originalJ2SEImage = ((J2SEImmutableImage) originalImage);
                originalAwtImage = ((java.awt.Image) originalJ2SEImage.getImage());
            }
            this.imageJ2SERotationUtil.rotateImage(originalAwtImage, newBufferedImage, totalAngle);
        } else {
            PreLogUtil.putOE("Not Mutable", this, "getRotatedImage", new Exception());
        }
    }

    // throws Exception
    public virtual Image createRotatedImage(Image originalImage, int rotationInDegrees)
    {
        Image image = ImageCreationUtil.getInstance().createImageWH(originalImage.getWidth(), originalImage.getHeight());
        if (image.isMutable()) {
            java.awt.Image originalAwtImage = null;
            if (originalImage.isMutable()) {
                J2SEMutableImage originalJ2SEImage = ((J2SEMutableImage) originalImage);
                originalAwtImage = ((java.awt.Image) originalJ2SEImage.getImage());
            } else {
                J2SEImmutableImage originalJ2SEImage = ((J2SEImmutableImage) originalImage);
                originalAwtImage = ((java.awt.Image) originalJ2SEImage.getImage());
            }
            J2SEMutableImage j2seImage = ((J2SEMutableImage) image);
            BufferedImage newBufferedImage = ((BufferedImage) j2seImage.getImage());
            BufferedImage bufferedImage = this.imageJ2SERotationUtil.createRotatedImage(originalAwtImage, newBufferedImage, rotationInDegrees);
            return image;
        } else {
            throw new Exception("Not Mutable");
        }
    }

}

