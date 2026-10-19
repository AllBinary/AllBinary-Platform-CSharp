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
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using Rectangle = org.allbinary.graphics.Rectangle;
using Movement = org.allbinary.physics.movement.Movement;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer.weapon;

public class DamageWeaponLayer : WeaponLayer
{
    public DamageWeaponLayer(string name, RemoteInfo remoteInfo, Movement movement, Animation animationInterface, Animation destroyedAnimationInterface, Rectangle rectangle, ViewPositionBase viewPosition, string username, int actorSessionId, int id, int multiPlayerType) : base(name, remoteInfo, multiPlayerType, movement, animationInterface, destroyedAnimationInterface, rectangle, viewPosition)
    {
        // base(name, remoteInfo, multiPlayerType, movement, animationInterface, destroyedAnimationInterface, rectangle, viewPosition) is called from the constructor declaration
        this.setCollidableInferface(new CollidableDamageWeaponBehavior(true));
    }

}

