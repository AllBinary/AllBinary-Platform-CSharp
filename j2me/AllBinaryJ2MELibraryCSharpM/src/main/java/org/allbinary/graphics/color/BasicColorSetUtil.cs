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
//using Graphics = javax.microedition.lcdui.Graphics;

namespace org.allbinary.graphics.color;

public class BasicColorSetUtil
{
    private static readonly BasicColorSetUtil instance = new BasicColorSetUtil();
    public static BasicColorSetUtil getInstance()
    {
        return BasicColorSetUtil.instance;
    }

    protected BasicColorSetUtil()
    {
    }

    public virtual void setBasicColorP(Graphics graphics, BasicColor basicColor)
    {
        graphics.setColor(((int) basicColor));
    }

    public virtual void setBasicColorP3(Graphics graphics, BasicColor basicColor, int value)
    {
        graphics.setColor(value);
    }

}

