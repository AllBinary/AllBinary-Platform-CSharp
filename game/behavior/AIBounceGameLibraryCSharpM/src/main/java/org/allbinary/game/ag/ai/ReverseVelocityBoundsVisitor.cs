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
using BoundsVisitorInterface = org.allbinary.bounds.BoundsVisitorInterface;
using VelocityInterface = org.allbinary.game.physics.velocity.VelocityInterface;
using VelocityInterfaceCompositeInterface = org.allbinary.game.physics.velocity.VelocityInterfaceCompositeInterface;
using LayerInterface = org.allbinary.layer.LayerInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.ag.ai;

public class ReverseVelocityBoundsVisitor : BoundsVisitorInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public VelocityInterface velocityInterface;
    private LayerInterface layerInterface;
    public ReverseVelocityBoundsVisitor(LayerInterface layerInterface)
    {
        this.layerInterface = layerInterface;
        VelocityInterfaceCompositeInterface velocityInterfaceCompositeInterface = ((VelocityInterfaceCompositeInterface) layerInterface);
        this.velocityInterface = ((VelocityInterface) velocityInterfaceCompositeInterface.getVelocityProperties());
    }

    public virtual int getX()
    {
        return this.layerInterface.getXP();
    }

    public virtual int getY()
    {
        return this.layerInterface.getYP();
    }

    public virtual void minX()
    {
        if (this.velocityInterface.getVelocityXBasicDecimalP().getUnscaled() < 0) {
            this.velocityInterface.getVelocityXBasicDecimalP().multiplyint(-1);
        }
    }

    public virtual void maxX()
    {
        if (this.velocityInterface.getVelocityXBasicDecimalP().getUnscaled() > 0) {
            this.velocityInterface.getVelocityXBasicDecimalP().multiplyint(-1);
        }
    }

    public virtual void minY()
    {
        if (this.velocityInterface.getVelocityYBasicDecimalP().getUnscaled() < 0) {
            this.velocityInterface.getVelocityYBasicDecimalP().multiplyint(-1);
        }
    }

    public virtual void maxY()
    {
        if (this.velocityInterface.getVelocityYBasicDecimalP().getUnscaled() > 0) {
            this.velocityInterface.getVelocityYBasicDecimalP().multiplyint(-1);
        }
    }

}

