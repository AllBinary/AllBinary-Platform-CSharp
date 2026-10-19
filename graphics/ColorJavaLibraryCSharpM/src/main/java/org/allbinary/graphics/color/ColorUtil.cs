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
//using java.awt;

namespace org.allbinary.graphics.color;

public class ColorUtil
{
    private static readonly ColorUtil instance = new ColorUtil();
    public static ColorUtil getInstance()
    {
        return ColorUtil.instance;
    }

    public virtual bool isGreyishOrWhiteLike(Color color)
    {
        if (Math.Abs(color.getRed() - color.getGreen()) > 20 || Math.Abs(color.getRed() - color.getBlue()) > 20 || Math.Abs(color.getGreen() - color.getBlue()) > 20) {
            return false;
        }
        return true;
    }

    public virtual bool isDark(Color color)
    {
        if (color.getRed() < 0x77 && color.getRed() < 0x77 && color.getRed() < 0x77) {
            return true;
        }
        return false;
    }

}

