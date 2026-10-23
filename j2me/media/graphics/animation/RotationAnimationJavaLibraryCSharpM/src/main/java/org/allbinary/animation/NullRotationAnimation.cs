// Generated Code Do Not Modify

using System;
using System.Linq;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation;

public class NullRotationAnimation : RotationAnimation
{
    public static NullRotationAnimation createTotalAngle(AngleInfo angleInfo, short totalAngle, AnimationBehavior animationBehavior)
    {
        return new NullRotationAnimation(angleInfo, CircularIndexUtil.createInstance(totalAngle / angleInfo.getAngleIncrementInfo().getAngleIncrement()), animationBehavior);
    }

    public static NullRotationAnimation createQuarter(AnimationBehavior animationBehavior)
    {
        return new NullRotationAnimation(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), animationBehavior);
    }

    public NullRotationAnimation(AngleInfo angleInfo, CircularIndexUtil circularIndexUtil, AnimationBehavior animationBehavior) : base(angleInfo, circularIndexUtil, animationBehavior)
    {
        // base(angleInfo, circularIndexUtil, animationBehavior) is called from the constructor declaration
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return 0;
    }

}

