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

namespace org.allbinary.media.image;

public class ImageToRotationImageArrayUtil
{
    private static readonly ImageToRotationImageArrayUtil instance = new ImageToRotationImageArrayUtil();
    public static ImageToRotationImageArrayUtil getInstance()
    {
        return ImageToRotationImageArrayUtil.instance;
    }

    private ImageToRotationImageArrayUtil()
    {
    }

    // throws Exception
    public virtual Image[] generate(Image image, int angleIncrement, int totalAngle)
    {
        ImageRotationUtil imageRotationUtil = ImageRotationUtil.getInstance();
        int totalFrames = totalAngle / angleIncrement;
        Image[] imageArray = new Image[totalFrames];
        imageArray[0] = image;
        for (int index = 1; index < totalFrames; index++) {
            imageArray[index] = imageRotationUtil.createRotatedImage(image, index * angleIncrement);
        }
        return imageArray;
    }

}

