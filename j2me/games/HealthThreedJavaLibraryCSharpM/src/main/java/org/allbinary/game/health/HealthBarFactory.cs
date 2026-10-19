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
using OpenGLFeatureUtil = org.allbinary.graphics.opengles.OpenGLFeatureUtil;
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.health;

public class HealthBarFactory
{
    // throws Exception
    public virtual HealthBar getInstance(AllBinaryLayer layerInterface, Health healthInterface, int location, int direction)
    {
        if (OpenGLFeatureUtil.getInstance().isAnyThreed()) {
            FeaturedAnimationInterfaceFactoryInterfaceFactory featuredAnimationInterfaceFactoryInterfaceFactory = FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance();
            HealthBarAnimationInterfaceFactory healthBarAnimationInterfaceFactory = ((HealthBarAnimationInterfaceFactory) featuredAnimationInterfaceFactoryInterfaceFactory.get(Health.NAME));
            return new HealthBar(layerInterface, healthInterface, healthBarAnimationInterfaceFactory.getInstanceByLocation(layerInterface, location), direction);
        } else {
            return new HealthBar(layerInterface, healthInterface, new HealthBarTwodAnimation(layerInterface, location), direction);
        }
    }

}

