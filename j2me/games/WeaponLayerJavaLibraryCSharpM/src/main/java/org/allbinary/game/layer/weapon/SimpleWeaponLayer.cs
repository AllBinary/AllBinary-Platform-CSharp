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
using Animation = org.allbinary.animation.Animation;
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using NullIndexedAnimationFactory = org.allbinary.animation.NullIndexedAnimationFactory;
using ExplosionResources = org.allbinary.game.combat.damage.ExplosionResources;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using Rectangle = org.allbinary.graphics.Rectangle;
using Movement = org.allbinary.physics.movement.Movement;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer.weapon;

public class SimpleWeaponLayer : WeaponLayer
{
    // throws Exception
    public static Animation createDestroyed()
    {
        return FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().getProcedural(ExplosionResources.getInstance().THIRD_EXPLOSION_RESOURCE).getInstanceAnimation(NullIndexedAnimationFactory.getFactoryInstance().getInstance(0));
    }

    public SimpleWeaponLayer(string name, RemoteInfo remoteInfo, int multiPlayerType, Movement movement, Animation animationInterface, Animation destroyedAnimationInterface, Rectangle rectangle, ViewPositionBase viewPosition) : base(name, remoteInfo, multiPlayerType, movement, animationInterface, destroyedAnimationInterface, rectangle, viewPosition)
    {
        // base(name, remoteInfo, multiPlayerType, movement, animationInterface, destroyedAnimationInterface, rectangle, viewPosition) is called from the constructor declaration
        this.setCollidableInferface(new CollidableWeaponBehavior(true));
    }

}

