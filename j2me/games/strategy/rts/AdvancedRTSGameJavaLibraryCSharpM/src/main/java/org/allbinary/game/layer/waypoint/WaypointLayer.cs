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
//using Graphics = javax.microedition.lcdui.Graphics;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using ProceduralAnimationInterfaceFactoryInterface = org.allbinary.animation.ProceduralAnimationInterfaceFactoryInterface;
using Health = org.allbinary.game.health.Health;
using Group = org.allbinary.game.identification.Group;
using NullRTSFormInputFactory = org.allbinary.game.input.form.NullRTSFormInputFactory;
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using AdvancedRTSProperties = org.allbinary.game.layer.AdvancedRTSProperties;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using TileLayerPositionIntoViewPosition = org.allbinary.game.view.TileLayerPositionIntoViewPosition;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using AttackSound = org.allbinary.media.audio.AttackSound;

namespace org.allbinary.game.layer.waypoint;

public class WaypointLayer : AdvancedRTSGameLayer
{
    protected WaypointLayer(RemoteInfo remoteInfo, PathFindingLayerInterface parentLayer, Group[] groupInterface, string rootName, string name, AnimationInterfaceFactoryInterface animationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface proceduralAnimationInterfaceFactoryInterface, Rectangle rectangle, int x, int y) : base(remoteInfo, parentLayer, AdvancedRTSProperties.createProperties(), groupInterface, rootName, name, new Health(1000), NullRTSFormInputFactory.getInstance(), animationInterfaceFactoryInterface, animationInterfaceFactoryInterface, animationInterfaceFactoryInterface, animationInterfaceFactoryInterface, animationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y, new TileLayerPositionIntoViewPosition())
    {
        // base(remoteInfo, parentLayer, AdvancedRTSProperties.createProperties(), groupInterface, rootName, name, new Health(1000), NullRTSFormInputFactory.getInstance(), animationInterfaceFactoryInterface, animationInterfaceFactoryInterface, animationInterfaceFactoryInterface, animationInterfaceFactoryInterface, animationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y, new TileLayerPositionIntoViewPosition()) is called from the constructor declaration
        this.setCollidableInferface(new CollidableWaypointBehavior(true));
        this.getWaypointBehavior().setWaypoint(new Waypoint(this, AttackSound.getInstance()));
        this.setAnimationInterface(this.indexedButShouldBeRotationAnimationInterface);
    }

    public override void construct(RTSPlayerLayerInterface rtsPlayerLayerInterface)
    {
        this.percentCompleteP = 100;
        this.initVisibility(rtsPlayerLayerInterface);
    }

    public override void paint(Graphics graphics)
    {
        if (this.isVisible()) {
            base.paint(graphics);
        }
    }

    public override void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        try {
            this.indexedButShouldBeRotationAnimationInterface.nextFrame();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "processTick", e);
        }
    }

    public override void damage(int damage, int damageType)
    {
    }

    // throws Exception
    public override int getDamage(int damageType)
    {
        return 0;
    }

    // throws Exception
    public override void setDestroyed(bool destroyed)
    {
        base.setDestroyed(destroyed);
        if (this.isDestroyed()) {
            WaypointCellPositionHistory.getInstance().removeLayer(this);
        }
    }

    public override int getType()
    {
        return WaypointLayer.getStaticType();
    }

    public static int getStaticType()
    {
        return 4;
    }

    public override bool isSelfUpgradeable()
    {
        return false;
    }

}

