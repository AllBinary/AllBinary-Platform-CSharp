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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.animation;

public class TimedVectorAnimation : VectorAnimation
{
    private TimeDelayHelper timeElapsedHelper = new TimeDelayHelper(200);
    public TimedVectorAnimation(int[][][] currentPoints, BasicColor basicColor, AnimationBehavior animationBehavior) : base(currentPoints, basicColor, animationBehavior)
    {
        // base(currentPoints, basicColor, animationBehavior) is called from the constructor declaration
    }

    public override void nextFrame()
    {
        if (this.timeElapsedHelper.isTime(GameTickTimeDelayHelperFactory.getInstance().startTime)) {
            base.nextFrame();
        }
    }

}

