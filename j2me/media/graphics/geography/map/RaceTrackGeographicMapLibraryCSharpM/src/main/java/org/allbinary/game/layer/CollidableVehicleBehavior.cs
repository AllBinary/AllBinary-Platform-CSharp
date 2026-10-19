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
using PickedUpLayerInterface = org.allbinary.game.layer.pickup.PickedUpLayerInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using CollidableInterfaceCompositeInterface = org.allbinary.game.collision.CollidableInterfaceCompositeInterface;
using CollisionType = org.allbinary.game.collision.CollisionType;
using CollisionTypeFactory = org.allbinary.game.collision.CollisionTypeFactory;
using CollidableDestroyableDamageableBehavior = org.allbinary.game.layer.special.CollidableDestroyableDamageableBehavior;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;

namespace org.allbinary.game.layer;

public class CollidableVehicleBehavior : CollidableDestroyableDamageableBehavior
{
    public long totalImpactVelocity = 0L;
    public CollidableVehicleBehavior(bool collidable) : base(collidable)
    {
        // base(collidable) is called from the constructor declaration
    }

    // throws Exception
    public override void collide(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface)
    {
        CollisionTypeFactory collisionTypeFactory = CollisionTypeFactory.getInstance();
        CollisionType collisionType = collidableInterfaceCompositeInterface.getCollidableInferface().getCollisionTypeWith(ownerLayer);
        if (collisionType == collisionTypeFactory.PICKUP) {
            CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer = (((CollidableDestroyableDamageableLayer) ownerLayer));
            collidableDestroyableDamageableLayer.getPickupBehavior().doPickupLayer(((PickedUpLayerInterface) collidableInterfaceCompositeInterface));
        } else if (collisionType == collisionTypeFactory.COLLISION) {
            base.collide(ownerLayer, collidableInterfaceCompositeInterface);
        } else {
            this.collideVehicle(ownerLayer, ((VehiclePropertiesCompositeInterface) collidableInterfaceCompositeInterface));
        }
    }

    public override void collideInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface)
    {
        ForcedLogUtil.log("Don't Use Interface Version It Is Slower", this);
    }

    private long halfImpactVelocityX = 0L;
    private long halfImpactVelocityY = 0L;
    protected virtual void collideVehicle(CollidableCompositeLayer ownerLayer, VehiclePropertiesCompositeInterface vehiclePropertiesCompositeInterface)
    {
        VehiclePropertiesCompositeInterface ownerVehicleLayerInterface = (((VehiclePropertiesCompositeInterface) ownerLayer));
        VehicleProperties ownerVehicleProperties = ownerVehicleLayerInterface.getVehicleProperties();
        VehicleProperties vehicleProperties = vehiclePropertiesCompositeInterface.getVehicleProperties();
        long impactVelocityX = ownerVehicleProperties.getVelocityProperties().getVelocityXBasicDecimalP().getUnscaled() - vehicleProperties.getVelocityProperties().getVelocityXBasicDecimalP().getUnscaled();
        long impactVelocityY = ownerVehicleProperties.getVelocityProperties().getVelocityYBasicDecimalP().getUnscaled() - vehicleProperties.getVelocityProperties().getVelocityYBasicDecimalP().getUnscaled();
        if (impactVelocityX != 0L) {
            this.halfImpactVelocityX = (impactVelocityX >> 1);
            ownerVehicleProperties.getVelocityProperties().getVelocityXBasicDecimalP().addlong(this.halfImpactVelocityX);
            vehicleProperties.getVelocityProperties().getVelocityXBasicDecimalP().addlong(this.halfImpactVelocityX);
        } else {
        }
        if (impactVelocityY != 0L) {
            this.halfImpactVelocityY = (impactVelocityY >> 1);
            ownerVehicleProperties.getVelocityProperties().getVelocityYBasicDecimalP().addlong(this.halfImpactVelocityY);
            vehicleProperties.getVelocityProperties().getVelocityXBasicDecimalP().addlong(this.halfImpactVelocityY);
        } else {
        }
        this.collideFriction(ownerVehicleLayerInterface);
        this.collideFriction(vehiclePropertiesCompositeInterface);
        this.totalImpactVelocity = impactVelocityX + impactVelocityY;
    }

    private void collideFriction(VehiclePropertiesCompositeInterface vehiclePropertiesCompositeInterface)
    {
        VehicleFrictionProperties vehicleFrictionProperties = vehiclePropertiesCompositeInterface.getVehicleProperties().getVehicleFrictionProperties();
        vehiclePropertiesCompositeInterface.getVehicleProperties().getVehicleFrictionProperties().friction(vehiclePropertiesCompositeInterface.getVehicleProperties().getVelocityProperties(), vehicleFrictionProperties.getCrashFrictionNominator());
    }

}

