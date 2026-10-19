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
using VelocityProperties = org.allbinary.game.physics.velocity.VelocityProperties;

namespace org.allbinary.game.layer;

public class VehicleProperties
{
    private readonly VelocityProperties velocityProperties;
    private VehicleFrictionProperties vehicleFrictionProperties;
    public VehicleProperties(VelocityProperties velocityProperties, VehicleFrictionProperties vehicleFrictionProperties)
    {
        this.velocityProperties = velocityProperties;
        this.vehicleFrictionProperties = vehicleFrictionProperties;
    }

    public virtual VehicleFrictionProperties getVehicleFrictionProperties()
    {
        return this.vehicleFrictionProperties;
    }

    public virtual void setVehicleFrictionProperties(VehicleFrictionProperties vehicleFrictionProperties)
    {
        this.vehicleFrictionProperties = vehicleFrictionProperties;
    }

    public virtual VelocityProperties getVelocityProperties()
    {
        return this.velocityProperties;
    }

}

