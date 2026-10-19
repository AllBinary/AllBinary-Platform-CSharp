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
//using Graphics = javax.microedition.lcdui.Graphics;
using GPoint = org.allbinary.graphics.GPoint;
using Layer = org.allbinary.layer.Layer;

namespace org.allbinary.game.layer;

public class LinePathAnimation
{
    private static readonly LinePathAnimation instance = new LinePathAnimation();
    public static LinePathAnimation getInstance()
    {
        return LinePathAnimation.instance;
    }

    public virtual void paint(Graphics graphics, GPoint point, GPoint nextPoint, Layer tiledLayer)
    {
        graphics.drawLine(nextPoint.getX(), nextPoint.getY(), point.getX(), point.getY());
    }

}

