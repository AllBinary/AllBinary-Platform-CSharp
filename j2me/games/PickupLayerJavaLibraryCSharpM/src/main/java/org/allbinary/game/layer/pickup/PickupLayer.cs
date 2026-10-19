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
//using GL = javax.microedition.khronos.opengles.GL;
//using Graphics = javax.microedition.lcdui.Graphics;
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using CollidableAlwaysPickupNeverCollideBehaviorFactory = org.allbinary.game.collision.CollidableAlwaysPickupNeverCollideBehaviorFactory;
using DestroyedLayerProcessor = org.allbinary.game.combat.destroy.DestroyedLayerProcessor;
using BasicGroupFactory = org.allbinary.game.identification.BasicGroupFactory;
using MultiPlayerGameLayer = org.allbinary.game.multiplayer.layer.MultiPlayerGameLayer;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using Rectangle = org.allbinary.graphics.Rectangle;
using OpenGLSurfaceChangedInterface = org.allbinary.image.opengles.OpenGLSurfaceChangedInterface;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer.pickup;

public class PickupLayer : MultiPlayerGameLayer, PickedUpLayerInterface, PickupableInterface
{
    private PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactoryInterface = CountedPickedUpLayerInterfaceFactory.NULL_COUNTED_PICKUP_LAYER_FACTORY;
    private bool destroyed = false;
    private Animation animationInterface = NullAnimationFactory.getFactoryInstance().getInstance(0);
    public PickupLayer(string name, RemoteInfo remoteInfo, int total, PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactoryInterface, Animation animationInterface, Rectangle rectangle, ViewPositionBase viewPosition) : base(remoteInfo, BasicGroupFactory.getInstance().NONE_ARRAY, name, rectangle, viewPosition)
    {
        // base(remoteInfo, BasicGroupFactory.getInstance().NONE_ARRAY, name, rectangle, viewPosition) is called from the constructor declaration
        this.setCollidableInferface(CollidableAlwaysPickupNeverCollideBehaviorFactory.getInstance().createBehavior());
        this.setLayerWidth(10);
        this.setLayerHeight(10);
        this.init(pickedUpLayerInterfaceFactoryInterface, animationInterface);
    }

    public virtual void init(PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactoryInterface, Animation animationInterface)
    {
        this.pickedUpLayerInterfaceFactoryInterface = pickedUpLayerInterfaceFactoryInterface;
        this.animationInterface = animationInterface;
        this.setDestroyed(false);
    }

    public virtual void initXYZ(int x, int y, int z)
    {
        this.setPosition(x, y, z);
    }

    public override void paint(Graphics graphics)
    {
        ViewPositionBase viewPosition = this.getViewPosition();
        int viewX = viewPosition.getX();
        int viewY = viewPosition.getY();
        this.animationInterface.paintXY(graphics, viewX, viewY);
    }

    public override void paintThreed(Graphics graphics)
    {
        ViewPositionBase viewPosition = this.getViewPosition();
        int viewX = viewPosition.getX();
        int viewY = viewPosition.getY();
        this.animationInterface.paintThreedXYZ(graphics, viewX, viewY, 3);
    }

    public override PickedUpLayerInterfaceFactoryInterface getPickedUpLayerInterfaceFactoryInterface()
    {
        return this.pickedUpLayerInterfaceFactoryInterface;
    }

    public override void setPickedUp()
    {
        this.setDestroyed(true);
    }

    public override bool isDestroyed()
    {
        return this.destroyed;
    }

    public virtual void setDestroyed(bool destroyed)
    {
        this.destroyed = destroyed;
        if (this.isDestroyed()) {
            DestroyedLayerProcessor.getInstance().add(this);
        }
    }

    public override void damage(int damage, int damageType)
    {
    }

    public override int getDamage(int damageType)
    {
        return 0;
    }

    // throws Exception
    public override void set(GL gl)
    {
        OpenGLSurfaceChangedInterface openGLSurfaceChangedInterface = ((OpenGLSurfaceChangedInterface) this.animationInterface);
        openGLSurfaceChangedInterface.set(gl);
    }

}

