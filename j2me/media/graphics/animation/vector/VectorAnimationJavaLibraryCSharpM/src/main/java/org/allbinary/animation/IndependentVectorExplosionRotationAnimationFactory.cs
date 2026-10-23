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
using NullUtil = org.allbinary.logic.NullUtil;
using VectorInfo = org.allbinary.vector.VectorInfo;

namespace org.allbinary.animation;

public class IndependentVectorExplosionRotationAnimationFactory : ProceduralAnimationInterfaceFactoryInterface
{
    private int[][][] framePoints = NullUtil.getInstance().NULL_INT_ARRAY_ARRAY_ARRAY;
    private VectorInfo vectorInfo;
    private BasicColor basicColor;
    private VectorAnimationFactoryInterface vectorAnimationFactoryInterface;
    public IndependentVectorExplosionRotationAnimationFactory(VectorInfo vectorInfo, BasicColor basicColor, VectorAnimationFactoryInterface vectorAnimationFactoryInterface)
    {
        this.vectorInfo = vectorInfo;
        this.basicColor = basicColor;
        this.vectorAnimationFactoryInterface = vectorAnimationFactoryInterface;
        this.init();
    }

    // throws Exception
    public virtual void init()
    {
        this.framePoints = VectorRotationGenerator.getInstance().getInstance(this.vectorInfo);
    }

    private readonly VectorExplosionGenerator vectorExplosionGenerator = VectorExplosionGenerator.getInstance();
    // throws Exception
    public virtual Animation getInstanceAnimation(Animation animationInterface)
    {
        int frame = 0;
        if (animationInterface != null) {
            IndexedAnimation rotationAnimationInterface = ((IndexedAnimation) animationInterface);
            frame = rotationAnimationInterface.getFrame();
        }
        int[][][] points = this.vectorExplosionGenerator.getInstance(this.framePoints[frame], 6, this.vectorExplosionGenerator.ROTATION);
        return this.vectorAnimationFactoryInterface.getInstance(points, this.basicColor);
    }

}

