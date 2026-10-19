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
        Image scaledImage = ImageCopyUtil.getInstance().createImageWH(image, width, height, true);
        return scaledImage;
    }

}

