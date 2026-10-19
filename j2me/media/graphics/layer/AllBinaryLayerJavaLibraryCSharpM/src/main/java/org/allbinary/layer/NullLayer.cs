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

namespace org.allbinary.layer;

public class NullLayer : Layer
{
    private static readonly NullLayer instance = new NullLayer();
    public static NullLayer getInstance()
    {
        return NullLayer.instance;
    }

    private NullLayer() : base(0, 0)
    {
        // base(0, 0) is called from the constructor declaration
    }

    public override void paint(Graphics graphics)
    {
    }

}

