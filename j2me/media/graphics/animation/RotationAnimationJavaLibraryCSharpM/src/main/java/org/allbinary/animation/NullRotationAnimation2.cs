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
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation;

public class NullRotationAnimation2 : NullRotationAnimation
{
    public NullRotationAnimation2() : base(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), new IndexedAnimationBehavior(1, 250))
    {
        // Constructor invocation emitted in the initializer.
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
    }

}

