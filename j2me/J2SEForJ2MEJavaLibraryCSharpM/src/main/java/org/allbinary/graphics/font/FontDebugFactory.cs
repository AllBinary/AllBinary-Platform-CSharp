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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;

namespace org.allbinary.graphics.font;

public class FontDebugFactory
{
    private static readonly FontDebugFactory instance = new FontDebugFactory();
    public static FontDebugFactory getInstance()
    {
        return FontDebugFactory.instance;
    }

    public virtual void setFont(Font font, Graphics graphics)
    {
        graphics.setFont(font);
    }

}

