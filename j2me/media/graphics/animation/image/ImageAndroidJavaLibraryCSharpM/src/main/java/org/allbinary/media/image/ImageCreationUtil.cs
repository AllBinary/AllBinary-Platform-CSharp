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
using GameFeatureImageCacheFactory = org.allbinary.image.GameFeatureImageCacheFactory;

namespace org.allbinary.media.image;

public class ImageCreationUtil
{
    private static readonly ImageCreationUtil instance = new ImageCreationUtil();
    public static ImageCreationUtil getInstance()
    {
        return ImageCreationUtil.instance;
    }

    private ImageCreationUtil()
    {
    }

    // throws Exception
    public virtual Image createImageWH(int width, int height)
    {
        Image image = GameFeatureImageCacheFactory.getInstance().get(this.GetType().FullName, width, height);
        return image;
    }

    // throws Exception
    public virtual Image createImage(int width, int height, float maxScaleX, float maxScaleY)
    {
        Image image = GameFeatureImageCacheFactory.getInstance().get(this.GetType().FullName, ((int) (((float) width) * maxScaleX)) + 1, ((int) (((float) height) * maxScaleY)) + 1);
        return image;
    }

}

