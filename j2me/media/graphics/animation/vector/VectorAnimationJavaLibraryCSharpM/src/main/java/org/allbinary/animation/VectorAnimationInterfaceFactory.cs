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
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation;

public class VectorAnimationInterfaceFactory : AnimationInterfaceFactoryInterface
{
    private int[][][] currentPoints;
    private BasicColor basicColor = BasicColorFactory.getInstance().WHITE;
    public readonly AnimationBehaviorFactory animationBehaviorFactory;
    public VectorAnimationInterfaceFactory(int[][][] currentPoints, BasicColor basicColor, AnimationBehaviorFactory animationBehaviorFactory)
    {
        this.currentPoints = currentPoints;
        this.setBasicColorP(basicColor);
        this.animationBehaviorFactory = animationBehaviorFactory;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        return new VectorAnimation(this.currentPoints, this.getBasicColorP(), this.animationBehaviorFactory.getOrCreateInstance());
    }

    protected virtual void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
    }

    protected virtual BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

