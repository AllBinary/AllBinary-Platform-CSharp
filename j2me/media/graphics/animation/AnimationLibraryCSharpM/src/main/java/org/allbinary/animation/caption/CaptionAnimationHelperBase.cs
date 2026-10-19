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
using Animation = org.allbinary.animation.Animation;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.animation.caption;

public class CaptionAnimationHelperBase : Animation
{
    public static readonly CaptionAnimationHelperBase INSTANCE = new CaptionAnimationHelperBase();
    public virtual bool isShowing()
    {
        return false;
    }

    public virtual void tick()
    {
    }

    public virtual void update(string message, BasicColor basicColor)
    {
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
    }

}

