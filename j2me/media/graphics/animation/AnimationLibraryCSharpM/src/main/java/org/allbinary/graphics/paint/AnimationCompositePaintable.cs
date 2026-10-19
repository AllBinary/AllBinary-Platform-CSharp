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
using Animation = org.allbinary.animation.Animation;

namespace org.allbinary.graphics.paint;

public class AnimationCompositePaintable : InitUpdatePaintable
{
    private readonly Animation animationInterface;
    public AnimationCompositePaintable(Animation animationInterface)
    {
        this.animationInterface = animationInterface;
    }

    public override void paint(Graphics graphics)
    {
        this.animationInterface.paintXY(graphics, 0, 0);
    }

    public override void paintThreed(Graphics graphics)
    {
        this.animationInterface.paintThreedXYZ(graphics, 0, 0, 0);
    }

}

