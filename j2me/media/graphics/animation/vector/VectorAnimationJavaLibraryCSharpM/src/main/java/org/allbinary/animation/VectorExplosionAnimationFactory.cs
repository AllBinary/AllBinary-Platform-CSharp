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

namespace org.allbinary.animation;

public class VectorExplosionAnimationFactory : ProceduralAnimationInterfaceFactoryInterface
{
    private readonly VectorExplosionGenerator vectorExplosionGenerator = VectorExplosionGenerator.getInstance();
    private BasicColor basicColor = BasicColorFactory.getInstance().WHITE;
    public readonly AnimationBehaviorFactory animationBehaviorFactory;
    public VectorExplosionAnimationFactory(BasicColor basicColor, AnimationBehaviorFactory animationBehaviorFactory)
    {
        this.animationBehaviorFactory = animationBehaviorFactory;
        this.setBasicColorP(basicColor);
    }

    // throws Exception
    public virtual Animation getInstanceAnimation(Animation animationInterface)
    {
        VectorAnimationInterface vectorRotationAnimationInterface = ((VectorAnimationInterface) animationInterface);
        int frame = vectorRotationAnimationInterface.getFrame();
        int[][] framePoints = vectorRotationAnimationInterface.getPoints(frame);
        int[][][] points = this.vectorExplosionGenerator.getInstance(framePoints, 6, this.vectorExplosionGenerator.ROTATION);
        return new VectorRotationAnimation(points, this.getBasicColorP(), this.animationBehaviorFactory.getOrCreateInstance());
    }

    private void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
    }

    private BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

}

