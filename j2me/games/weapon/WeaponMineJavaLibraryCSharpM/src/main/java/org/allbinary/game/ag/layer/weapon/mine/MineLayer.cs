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
using DropWeaponSound = org.allbinary.ag.weapon.media.audio.DropWeaponSound;
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using SimpleWeaponLayer = org.allbinary.game.layer.weapon.SimpleWeaponLayer;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using SecondaryPlayerQueueFactory = org.allbinary.media.audio.SecondaryPlayerQueueFactory;
using NoMovementFactory = org.allbinary.physics.movement.NoMovementFactory;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;
using ViewPositionEventHandler = org.allbinary.view.@event.ViewPositionEventHandler;

namespace org.allbinary.game.ag.layer.weapon.mine;

public class MineLayer : SimpleWeaponLayer
{
    private static readonly string NAME = "MineLayer";
    public MineLayer(ViewPositionBase viewPosition) : base(MineLayer.NAME, RemoteInfo.REMOTE_INFO, -1, NoMovementFactory.getInstance().getMovmentInstance(), FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(MineWeaponResources.getInstance().RESOURCE).getInstance(0), SimpleWeaponLayer.createDestroyed(), new Rectangle(PointFactory.getInstance().ZERO_ZERO, 10, 10), viewPosition)
    {
        // base(MineLayer.NAME, RemoteInfo.REMOTE_INFO, -1, NoMovementFactory.getInstance().getMovmentInstance(), FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(MineWeaponResources.getInstance().RESOURCE).getInstance(0), SimpleWeaponLayer.createDestroyed(), new Rectangle(PointFactory.getInstance().ZERO_ZERO, 10, 10), viewPosition) is called from the constructor declaration
    }

    private readonly ViewPositionEventHandler viewPositionEventHandler = ViewPositionEventHandler.getInstance();
    public override void initXYZ(int x, int y, int z)
    {
        this.setPosition(x + 5, y + 5, z);
        this.viewPositionEventHandler.addListener(((AllBinaryLayer) this));
        SecondaryPlayerQueueFactory.getInstance().add(DropWeaponSound.getInstance());
    }

    public override void damage(int damage, int damageType)
    {
        this.totalDamage = this.getInitDamage() + 1;
    }

    public override int getDamage(int damageType)
    {
        base.getDamage(damageType);
        return this.getInitDamage();
    }

    public override void setDestroyed(bool destroyed)
    {
        base.setDestroyed(destroyed);
        if (this.isDestroyed()) {
            this.viewPositionEventHandler.removeListener(this);
        }
    }

}

