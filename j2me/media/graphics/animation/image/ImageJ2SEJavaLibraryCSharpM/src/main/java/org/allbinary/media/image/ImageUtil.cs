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
//using GraphicsConfiguration = java.awt.GraphicsConfiguration;
//using GraphicsDevice = java.awt.GraphicsDevice;
//using GraphicsEnvironment = java.awt.GraphicsEnvironment;
//using Transparency = java.awt.Transparency;
//using AffineTransform = java.awt.geom.AffineTransform;
//using BufferedImage = java.awt.image.BufferedImage;
//using Image = javax.microedition.lcdui.Image;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using J2SEImmutableImage = org.microemu.device.j2se.J2SEImmutableImage;
using J2SEMutableImage = org.microemu.device.j2se.J2SEMutableImage;

namespace org.allbinary.media.image;

public class ImageUtil
{
    private static readonly ImageUtil instance = new ImageUtil();
    public static ImageUtil getInstance()
    {
        return ImageUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private string IIOIMAGE_POOL_NAME = "IIOIMAGE_POOL_NAME";
    private readonly string CREATE_BUFFERED_IMAGE = "createBufferedImage";
    private ImageUtil()
    {
    }

    private GraphicsConfiguration getDefaultConfiguration()
    {
        GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
        GraphicsDevice gd = ge.getDefaultScreenDevice();
        return gd.getDefaultConfiguration();
    }

    public virtual BufferedImage create(int width, int height)
    {
        GraphicsConfiguration graphicsConfiguration = this.getDefaultConfiguration();
        return graphicsConfiguration.createCompatibleImage(width, height, Transparency.TRANSLUCENT);
    }

    // throws Exception
    public virtual BufferedImage[] createBufferedImageForResize(BufferedImage[] bufferedImageArray, int percent, bool scale)
    {
        int size = bufferedImageArray.Length;
        BufferedImage[] scaledBufferedImageArray = new BufferedImage[size];
        BufferedImage bufferedImage = null;
        for (int index = 0; index < size; index++) {
            bufferedImage = bufferedImageArray[index];
            int newWidth = ((int) (bufferedImage.getWidth() * percent / 100));
            int newHeight = ((int) (bufferedImage.getHeight() * percent / 100));
            scaledBufferedImageArray[index] = this.createBufferedImage(bufferedImage, newWidth, newHeight, scale);
        }
        return scaledBufferedImageArray;
    }

    // throws Exception
    public virtual BufferedImage[] createBufferedImage2(BufferedImage[] bufferedImageArray, float percent, bool scale)
    {
        int size = bufferedImageArray.Length;
        BufferedImage[] scaledBufferedImageArray = new BufferedImage[size];
        BufferedImage bufferedImage = null;
        for (int index = 0; index < size; index++) {
            bufferedImage = bufferedImageArray[index];
            int newWidth = ((int) (bufferedImage.getWidth() * percent));
            int newHeight = ((int) (bufferedImage.getHeight() * percent));
            scaledBufferedImageArray[index] = this.createBufferedImage(bufferedImage, newWidth, newHeight, scale);
        }
        return scaledBufferedImageArray;
    }

    // throws Exception
    public virtual BufferedImage[] createBufferedImage3(BufferedImage[] bufferedImageArray, int width, int height, bool scale)
    {
        int size = bufferedImageArray.Length;
        BufferedImage[] scaledBufferedImageArray = new BufferedImage[size];
        for (int index = 0; index < size; index++) {
            scaledBufferedImageArray[index] = this.createBufferedImage(bufferedImageArray[index], width, height, scale);
        }
        return scaledBufferedImageArray;
    }

    // throws Exception
    public virtual BufferedImage createBufferedImageForSave(BufferedImage bufferedImage, int newWidth, int newHeight)
    {
        return this.createBufferedImage(bufferedImage, newWidth, newHeight, true);
    }

    // throws Exception
    public virtual BufferedImage createBufferedImage(BufferedImage bufferedImage, int newWidth, int newHeight, bool scale)
    {
        return this.createBufferedImageAllowTranslate(bufferedImage, newWidth, newHeight, scale, false);
    }

    // throws Exception
    public virtual BufferedImage createBufferedImageAllowTranslate(BufferedImage bufferedImage, int newWidth, int newHeight, bool scale, bool allowTranslate)
    {
        double width = bufferedImage.getWidth();
        double height = bufferedImage.getHeight();
        double d_newWidth = ((double) newWidth);
        double d_newHeight = ((double) newHeight);
        double widthRatio = d_newWidth / width;
        double heightRatio = d_newHeight / height;
        double ratioX = 1.0;
        double ratioY = 1.0;
        if (scale) {
            ratioX = widthRatio;
            ratioY = heightRatio;
        }
        AffineTransform affineTransform = AffineTransform.getScaleInstance(ratioX, ratioY);
        if (!scale && allowTranslate) {
            double dx = (((double) newWidth) - width) / 2.0;
            double dy = (((double) newHeight) - height) / 2.0;
            affineTransform.translate(dx, dy);
        }
        BufferedImage newBufferedImage = new BufferedImage(newWidth, newHeight, BufferedImage.TYPE_INT_ARGB_PRE);
        Graphics2D graphics = newBufferedImage.createGraphics();
        graphics.drawRenderedImage(bufferedImage, affineTransform);
        return newBufferedImage;
    }

    // throws Exception
    public virtual BufferedImage createBufferedImageWithLargerCanvas(BufferedImage bufferedImage, int newWidth, int newHeight)
    {
        double width = bufferedImage.getWidth();
        double height = bufferedImage.getHeight();
        double d_newWidth = ((double) newWidth);
        double d_newHeight = ((double) newHeight);
        double widthRatio = d_newWidth / width;
        double heightRatio = d_newHeight / height;
        int dx2 = ((int) (((double) newWidth) - width));
        int dy2 = ((int) (((double) newHeight) - height));
        int dx = dx2 / 2;
        int dy = dy2 / 2;
        int dx4 = dx2 / 4;
        int dy4 = dy2 / 4;
        BufferedImage newBufferedImage = new BufferedImage(newWidth, newHeight, BufferedImage.TYPE_INT_ARGB_PRE);
        Graphics2D graphics = newBufferedImage.createGraphics();
        graphics.drawImage(bufferedImage, dx4, dy4, null);
        return newBufferedImage;
    }

    public virtual BufferedImage convertToBufferedImage(java.awt.Image toolkitImage)
    {
        if (toolkitImage == null) {
            return null;
        }
        BufferedImage bufferedImage = new BufferedImage(toolkitImage.getWidth(null), toolkitImage.getHeight(null), BufferedImage.TYPE_INT_ARGB);
        Graphics2D g2d = bufferedImage.createGraphics();
        g2d.drawImage(toolkitImage, 0, 0, null);
        g2d.dispose();
        return bufferedImage;
    }

    public virtual BufferedImage getBufferedImage(Image image)
    {
        BufferedImage bufferedImage = null;
        if (image.isMutable()) {
            J2SEMutableImage j2seImage = ((J2SEMutableImage) image);
            bufferedImage = ((BufferedImage) j2seImage.getImage());
        } else {
            J2SEImmutableImage j2seImage = ((J2SEImmutableImage) image);
            bufferedImage = ((BufferedImage) j2seImage.getImage());
        }
        return bufferedImage;
    }

    public virtual string toString(BufferedImage bufferedImage)
    {
        CommonLabels commonLabels = CommonLabels.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(" BufferedImage -");
        stringBuffer.append(commonLabels.WIDTH_LABEL);
        stringBuffer.appendint(((int) bufferedImage.getWidth()));
        stringBuffer.append(commonLabels.HEIGHT_LABEL);
        stringBuffer.appendint(((int) bufferedImage.getHeight()));
        stringBuffer.append(" Type: ");
        stringBuffer.appendint(((int) bufferedImage.getType()));
        return stringBuffer.ToString();
    }

}

