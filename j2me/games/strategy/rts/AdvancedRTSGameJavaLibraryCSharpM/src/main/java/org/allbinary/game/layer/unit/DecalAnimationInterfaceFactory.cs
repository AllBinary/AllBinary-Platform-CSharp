/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using BasicGameResources = org.allbinary.game.layer.resources.BasicGameResources;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using NullRotationAnimationFactory = org.allbinary.animation.NullRotationAnimationFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;

namespace org.allbinary.game.layer.unit;

public class DecalAnimationInterfaceFactory
{
    private static readonly DecalAnimationInterfaceFactory instance = new DecalAnimationInterfaceFactory();
    public static DecalAnimationInterfaceFactory getInstance()
    {
        return DecalAnimationInterfaceFactory.instance;
    }

    // throws Exception
    public virtual AnimationInterfaceFactoryInterface getAnimationFactory(BasicGameResources basicGameResources, BasicColor basicColor)
    {
        AnimationInterfaceFactoryInterface animationInterfaceFactoryInterface = null;
        if (basicColor == BasicColorFactory.getInstance().RED) {
            animationInterfaceFactoryInterface = FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(basicGameResources.RESOURCE);
        } else {
            animationInterfaceFactoryInterface = NullRotationAnimationFactory.getFactoryInstance();
        }
        return animationInterfaceFactoryInterface;
    }

}

