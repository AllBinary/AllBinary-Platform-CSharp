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

namespace org.allbinary.graphics.color;

public class BasicColorUtil
{
    private static readonly BasicColorUtil instance = new BasicColorUtil();
    public static BasicColorUtil getInstance()
    {
        return BasicColorUtil.instance;
    }

    public readonly BasicColor[] ZERO_ARRAY = new BasicColor[0];
    public readonly int ALPHA = 0xFF000000;
    public readonly bool isAlpha = true;
    public readonly bool ffOpaque = true;
    public virtual int getRGB(int red, int green, int blue)
    {
        int value = 0;
        if (this.isAlpha) {
            if (this.ffOpaque) {
                value = this.ALPHA;
            }
        }
        value = (red << 16) | value;
        value = (green << 8) | value;
        value = blue | value;
        return value;
    }

    public virtual int getARGB(int alphaValue, int r, int g, int b)
    {
        return ((alphaValue << 24) & this.ALPHA) + ((r << 16) & 0x00FF0000) + ((g << 8) & 0x0000FF00) + (b & 0x000000FF);
    }

    public virtual int get(int alphaValue, int color)
    {
        return ((alphaValue << 24) & this.ALPHA) + color;
    }

    public virtual int invert(int color)
    {
        return (0xFFFFFF - color) | this.ALPHA;
    }

}

