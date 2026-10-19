/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using ModifierOpenGLESImageProcessor = org.allbinary.image.opengles.ModifierOpenGLESImageProcessor;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using ImageData = org.eclipse.swt.graphics.ImageData;
using SwtImmutableImage = org.microemu.device.swt.SwtImmutableImage;
using SwtMutableImage = org.microemu.device.swt.SwtMutableImage;

namespace org.allbinary.media.image;

public class ImageModifierUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageModifierUtil instance = new ImageModifierUtil();
    public static ImageModifierUtil getInstanceOrCreate()
    {
        return ImageModifierUtil.instance;
    }

    private readonly ImageCopyUtil imageCopyUtil = ImageCopyUtil.getInstance();
    private readonly Features features = Features.getInstance();
    public virtual void setBasicColorP(BasicColor basicColor)
    {
    }

    public virtual void setColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
        org.eclipse.swt.graphics.Image newBufferedImage = null;
        if (image.isMutable()) {
            SwtMutableImage swtImage = ((SwtMutableImage) image);
            newBufferedImage = ((org.eclipse.swt.graphics.Image) swtImage.getImage());
        } else {
            SwtImmutableImage swtImage = ((SwtImmutableImage) image);
            newBufferedImage = ((org.eclipse.swt.graphics.Image) swtImage.getImage());
        }
        short r = basicColor.red;
        short g = basicColor.green;
        short b = basicColor.blue;
        int width = image.getWidth();
        int height = image.getHeight();
        ImageData imageData = newBufferedImage.getImageData();
        if (imageData.depth == 24) {
            int rx = 0;
            int gx = 0;
            int bx = 0;
            int index3 = 0;
            for (int index = 0; index < width; index++) {
                for (int index2 = 0; index2 < height; index2++) {
                    index3 = (index2 * imageData.bytesPerLine) + (index * 4);
                    rx = (imageData.data[index3] & 0xFF) << 16;
                    gx = (imageData.data[index3 + 1] & 0xFF) << 8;
                    bx = (imageData.data[index3 + 2] & 0xFF);
                    if (rx != 0 || gx != 0 || bx != 0) {
                        imageData.data[index3] = ((sbyte) r);
                        imageData.data[index3 + 1] = ((sbyte) g);
                        imageData.data[index3 + 2] = ((sbyte) b);
                    }
                }
            }
        }
    }

    public virtual void changeColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
        if (this.features.isFeature(OpenGLFeatureFactory.getInstance().OPENGL)) {
            if (image.getType() >= OpenGLESImage.TYPE) {
                OpenGLESImage openGLESImage = (((OpenGLESImage) image));
                openGLESImage.imageProcessor = ModifierOpenGLESImageProcessor.getInstance();
                openGLESImage.openGLESImageProperties.redf = basicColor.getRedComponent();
                openGLESImage.openGLESImageProperties.greenf = basicColor.getGreenComponent();
                openGLESImage.openGLESImageProperties.bluef = basicColor.getBlueComponent();
                return;
            }
        }
        org.eclipse.swt.graphics.Image newBufferedImage = null;
        if (image.isMutable()) {
            SwtMutableImage swtImage = ((SwtMutableImage) image);
            newBufferedImage = ((org.eclipse.swt.graphics.Image) swtImage.getImage());
        } else {
            SwtImmutableImage swtImage = ((SwtImmutableImage) image);
            newBufferedImage = ((org.eclipse.swt.graphics.Image) swtImage.getImage());
        }
        float MAX = 255f;
        float r = (((float) basicColor.red)) / MAX;
        float g = (((float) basicColor.green)) / MAX;
        float b = (((float) basicColor.blue)) / MAX;
        int rx = 0;
        int gx = 0;
        int bx = 0;
        ImageData imageData = newBufferedImage.getImageData();
        if (imageData.depth == 24) {
            int size = imageData.data.Length;
            for (int index = 0; index < size; index += 4) {
                rx = (imageData.data[index] & 0xFF) << 16;
                gx = (imageData.data[index + 1] & 0xFF) << 8;
                bx = (imageData.data[index + 2] & 0xFF);
                rx = ((int) (rx * r));
                gx = ((int) (gx * g));
                bx = ((int) (bx * b));
                imageData.data[index] = ((sbyte) rx);
                imageData.data[index + 1] = ((sbyte) gx);
                imageData.data[index + 2] = ((sbyte) bx);
            }
        }
    }

    public virtual void setAlpha(Image unusedOriginalImage, Image image, int imageIndex, int alphaInt)
    {
        if (this.features.isFeature(OpenGLFeatureFactory.getInstance().OPENGL)) {
            if (image.getType() >= OpenGLESImage.TYPE) {
                OpenGLESImage openGLESImage = (((OpenGLESImage) image));
                openGLESImage.imageProcessor = ModifierOpenGLESImageProcessor.getInstance();
                openGLESImage.openGLESImageProperties.alphaf = (((float) alphaInt)) / 255f;
                return;
            }
        }
        this.setAlphaSWT(image, alphaInt);
    }

    public virtual void setAlphaSWT(Image image, int alphaInt)
    {
        sbyte alpha = ((sbyte) alphaInt);
        org.eclipse.swt.graphics.Image newBufferedImage = null;
        if (image.isMutable()) {
            SwtMutableImage swtImage = ((SwtMutableImage) image);
            newBufferedImage = ((org.eclipse.swt.graphics.Image) swtImage.getImage());
        } else {
            SwtImmutableImage swtImage = ((SwtImmutableImage) image);
            newBufferedImage = ((org.eclipse.swt.graphics.Image) swtImage.getImage());
        }
        newBufferedImage.getImageData().alpha = alpha;
    }

    public virtual Image[] getImageArray(Image[] originalImageArray)
    {
        try {
            Image[] newImageArray = new Image[originalImageArray.Length];
            int size = newImageArray.Length;
            Image originalImage = null;
            for (int index = 0; index < size; index++) {
                originalImage = originalImageArray[index];
                Image image = this.imageCopyUtil.createImage(originalImage);
                newImageArray[index] = image;
            }
            return newImageArray;
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE(commonStrings.EXCEPTION, this, "getImageArray", e);
            return originalImageArray;
        }
    }

    public virtual void handleImage(Image[] imageArray, int index, Image image)
    {
    }

    public virtual void reset()
    {
    }

}

