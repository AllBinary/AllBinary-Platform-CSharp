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

namespace org.allbinary.media.image;

public class ImageJ2MEScaleUtil
{
    private static readonly ImageJ2MEScaleUtil instance = new ImageJ2MEScaleUtil();
    public static ImageJ2MEScaleUtil getInstance()
    {
        return ImageJ2MEScaleUtil.instance;
    }

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
        int sourceWidth = image.getWidth();
        int sourceHeight = image.getHeight();
        int[] originalData = new int[image.getWidth() * image.getHeight()];
        image.getRGB(originalData, 0, image.getWidth(), 0, 0, image.getWidth(), image.getHeight());
        int[] scaledData = new int[width * height];
        int heightRatioFactor = (8 * sourceHeight) / height;
        int widthRatioFactor = (8 * sourceWidth) / width;
        int scaledIndex = scaledData.Length - 1;
        int dx = 0;
        int dy = 0;
        for (int index = height; --index >= 0; ) {
            dy = (index * heightRatioFactor) >> 3;
            for (int index2 = width; --index2 >= 0; ) {
                dx = (index2 * widthRatioFactor) >> 3;
                scaledData[scaledIndex--] = originalData[(sourceWidth * dy) + dx];
            }
        }
        Image scaledImage = Image.createRGBImage(scaledData, width, height, true);
        return scaledImage;
    }

}

