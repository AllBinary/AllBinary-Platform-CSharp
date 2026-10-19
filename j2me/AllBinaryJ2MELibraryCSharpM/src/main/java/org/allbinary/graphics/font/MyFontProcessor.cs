/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;

namespace org.allbinary.graphics.font;

public class MyFontProcessor
{
    public static int defaultCharWidth(Font font)
    {
        return font.charWidth('C');
    }

    public static int defaultStringWidth(Font font, int size)
    {
        return MyFontProcessor.defaultCharWidth(font) * size;
    }

    private static readonly MyFontProcessor instance = new MyFontProcessor();
    public static MyFontProcessor getInstance()
    {
        return MyFontProcessor.instance;
    }

    public virtual void process(Graphics graphics)
    {
    }

}

