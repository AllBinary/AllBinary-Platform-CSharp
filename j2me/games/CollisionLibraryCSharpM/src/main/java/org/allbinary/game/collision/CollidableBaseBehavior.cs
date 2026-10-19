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
//using Graphics = javax.microedition.lcdui.Graphics;
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.collision;

public class CollidableBaseBehavior : CollidableInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly LayerCollisionUtil layerCollisionUtil = LayerCollisionUtil.getInstance();
    private bool collidable = true;
    public CollidableBaseBehavior(bool collidable)
    {
        this.collidable = collidable;
    }

    public virtual void update()
    {
    }

    public virtual string getName()
    {
        return this.GetType().FullName;
    }

    public virtual void setCollidable(bool collidable)
    {
        this.collidable = collidable;
    }

    public virtual bool isCollidable(CollidableCompositeLayer ownerLayer)
    {
        return this.collidable;
    }

    // throws Exception
    public virtual void collide(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer allbinaryCollidableLayer)
    {
        throw new Exception(new StringMaker().append(this.commonStrings.NOT_IMPLEMENTED).append(CommonLabels.getInstance().COLON_SEP).append(this.GetType().FullName).ToString());
    }

    public virtual bool isCollision(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collisionLayer)
    {
        return this.layerCollisionUtil.isCollision(ownerLayer, collisionLayer);
    }

    public virtual bool isCollisionInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface)
    {
        return this.layerCollisionUtil.isCollision(ownerLayer, ((AllBinaryLayer) collidableInterfaceCompositeInterface));
    }

    // throws Exception
    public virtual void collideInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual void paint(CollidableCompositeLayer ownerLayer, Graphics graphics)
    {
    }

    public virtual CollisionType getCollisionTypeWith(AllBinaryLayer layerInterface)
    {
        return CollisionTypeFactory.getInstance().NONE;
    }

}

