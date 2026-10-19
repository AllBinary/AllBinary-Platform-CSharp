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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using PlaynMutableImage = org.microemu.device.playn.PlaynMutableImage;
using CanvasImage = playn.core.CanvasImage;
using CanvasSurface = playn.core.CanvasSurface;

namespace org.allbinary.media.image;

public class ImageModifierUtil
{
    private static readonly ImageModifierUtil instance = new ImageModifierUtil();
    public static ImageModifierUtil getInstanceOrCreate()
    {
        return ImageModifierUtil.instance;
    }

    public virtual void setColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
    }

    public virtual void changeColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
    }

    public virtual void setAlpha(Image originalImage, Image image, int imageIndex, int alphaInt)
    {
    }

    public virtual Image[] getImageArray(Image[] originalImageArray)
    {
        return originalImageArray;
    }

    public virtual void handleImage(Image[] imageArray, int index, Image image)
    {
    }

    public virtual void reset()
    {
    }

}

