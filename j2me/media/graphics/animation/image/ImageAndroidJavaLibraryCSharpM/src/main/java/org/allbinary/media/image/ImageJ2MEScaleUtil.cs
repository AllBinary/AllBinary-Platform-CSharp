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
using GameFeatureImageCacheFactory = org.allbinary.image.GameFeatureImageCacheFactory;

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
        for (int index = 0; index < images.Length; index++) {
            Image image = images[index];
            images[index] = ImageScaleUtil.getInstance().createImage2(GameFeatureImageCacheFactory.getInstance(), image, ((float) width) / 2f, ((float) image.getWidth()), ((float) height), ((float) image.getHeight()), false);
        }
        return images;
    }

    // throws Exception
    public virtual Image scale(Image image, int width, int height)
    {
        return ImageScaleUtil.getInstance().createImage2(GameFeatureImageCacheFactory.getInstance(), image, ((float) width), ((float) image.getWidth()), ((float) height), ((float) image.getHeight()), false);
    }

}

