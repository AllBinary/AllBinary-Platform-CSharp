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
using Paint = android.graphics.Paint;
using PorterDuff = android.graphics.PorterDuff;
using PorterDuffColorFilter = android.graphics.PorterDuffColorFilter;
//using Image = javax.microedition.lcdui.Image;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.media.image;

public class ImageModifierUtil
{
    public static ImageModifierUtil getInstanceOrCreate()
    {
        return new ImageModifierUtil();
    }

    public readonly Paint paint = new Paint(Paint.ANTI_ALIAS_FLAG);
    public virtual void setColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
        this.paint.setColorFilter(new PorterDuffColorFilter(((int) basicColor), PorterDuff.Mode.SRC_IN));
    }

    public virtual void changeColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
        this.paint.setColorFilter(new PorterDuffColorFilter(((int) basicColor), PorterDuff.Mode.SRC_IN));
    }

    public virtual void setAlpha(Image originalImage, Image image, int imageIndex, int alphaInt)
    {
        if (alphaInt != this.paint.getAlpha()) {
            this.paint.setAlpha(alphaInt);
        }
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

