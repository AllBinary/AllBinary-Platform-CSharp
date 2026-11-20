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
using Graphics = javax.microedition.lcdui.Graphics;

namespace org.allbinary.animation;

public class NullIndexedAnimationInner : NullIndexedAnimation
{
    public NullIndexedAnimationInner() : base(new IndexedAnimationBehavior(1, 250))
    {
        // base(new IndexedAnimationBehavior(1, 250)) is called from the constructor declaration
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
    }

}

