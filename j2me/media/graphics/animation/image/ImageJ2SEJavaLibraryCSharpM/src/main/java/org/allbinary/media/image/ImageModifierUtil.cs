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
//using BufferedImage = java.awt.image.BufferedImage;
//using ColorModel = java.awt.image.ColorModel;
//using WritableRaster = java.awt.image.WritableRaster;
//using Image = javax.microedition.lcdui.Image;
using Anchor = org.allbinary.graphics.Anchor;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image;

public class ImageModifierUtil
{
    private static readonly ImageModifierUtil instance = new ImageModifierUtil();
    public static ImageModifierUtil getInstanceOrCreate()
    {
        return ImageModifierUtil.instance;
    }

    private readonly ImageUtil imageUtil = ImageUtil.getInstance();
    public virtual void setBasicColorP(BasicColor basicColor)
    {
    }

    private readonly int[] colorArray = new int[1];
    public virtual void setColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
        BufferedImage newBufferedImage = this.imageUtil.getBufferedImage(image);
        short r = basicColor.red;
        short g = basicColor.green;
        short b = basicColor.blue;
        int width = image.getWidth();
        int height = image.getHeight();
        ColorModel colorModel = null;
        object dataElements = null;
        int ax = 0;
        int rx = 0;
        int gx = 0;
        int bx = 0;
        for (int index = 0; index < width; index++) {
            for (int index2 = 0; index2 < height; index2++) {
                colorModel = newBufferedImage.getColorModel();
                dataElements = newBufferedImage.getRaster().getDataElements(index, index2, null);
                ax = colorModel.getAlpha(dataElements);
                rx = colorModel.getRed(dataElements);
                gx = colorModel.getGreen(dataElements);
                bx = colorModel.getBlue(dataElements);
                if (rx != 0 || gx != 0 || bx != 0) {
                    newBufferedImage.setRGB(index, index2, (ax << 24) | (r << 16) | (g << 8) | ((int) (b)));
                }
            }
        }
    }

    public virtual void changeColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
        BufferedImage newBufferedImage = this.imageUtil.getBufferedImage(image);
        float MAX = 255f;
        float r = (((float) basicColor.red)) / MAX;
        float g = (((float) basicColor.green)) / MAX;
        float b = (((float) basicColor.blue)) / MAX;
        int width = image.getWidth();
        int height = image.getHeight();
        ColorModel colorModel = null;
        object dataElements = null;
        int ax = 0;
        int rx = 0;
        int gx = 0;
        int bx = 0;
        for (int index = 0; index < width; index++) {
            for (int index2 = 0; index2 < height; index2++) {
                colorModel = newBufferedImage.getColorModel();
                dataElements = newBufferedImage.getRaster().getDataElements(index, index2, null);
                ax = colorModel.getAlpha(dataElements);
                rx = colorModel.getRed(dataElements);
                gx = colorModel.getGreen(dataElements);
                bx = colorModel.getBlue(dataElements);
                rx = ((int) (rx * r));
                gx = ((int) (gx * g));
                bx = ((int) (bx * b));
                newBufferedImage.setRGB(index, index2, (ax << 24) | (rx << 16) | (gx << 8) | (bx));
            }
        }
    }

    public virtual void setAlpha(Image unusedOriginalImage, Image image, int imageIndex, int alphaInt)
    {
        sbyte alpha = ((sbyte) alphaInt);
        BufferedImage newBufferedImage = this.imageUtil.getBufferedImage(image);
        int width = image.getWidth();
        int height = image.getHeight();
        WritableRaster raster = newBufferedImage.getAlphaRaster();
        for (int index = 0; index < width; index++) {
            for (int index2 = 0; index2 < height; index2++) {
                raster.getPixel(index, index2, this.colorArray);
                this.colorArray[0] = ((int) alpha) & this.colorArray[0];
                raster.setPixel(index, index2, this.colorArray);
            }
        }
    }

    public virtual Image[] getImageArray(Image[] originalImageArray)
    {
        try {
            Image[] newImageArray = new Image[originalImageArray.Length];
            int size = newImageArray.Length;
            Image originalImage = null;
            for (int index = 0; index < size; index++) {
                originalImage = originalImageArray[index];
                Image image = ImageCreationUtil.getInstance().createImageWH(originalImage.getWidth(), originalImage.getHeight());
                image.getGraphics().drawImage(originalImage, 0, 0, Anchor.TOP_LEFT);
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

