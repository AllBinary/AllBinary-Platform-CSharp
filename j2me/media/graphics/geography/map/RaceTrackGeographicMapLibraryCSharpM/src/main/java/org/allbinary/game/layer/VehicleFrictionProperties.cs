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
using FrictionProperties = org.allbinary.game.physics.FrictionProperties;
using FrictionData = org.allbinary.game.physics.friction.FrictionData;

namespace org.allbinary.game.layer;

public class VehicleFrictionProperties : FrictionProperties
{
    private readonly int TIRE_FRICTION_NOMINATOR;
    private readonly int BRAKE_FRICTION_NOMINATOR;
    private readonly int AIR_FRICTION_NOMINATOR;
    private readonly int CRASH_FRICTION_NOMINATOR;
    public VehicleFrictionProperties(int tireFriction, int brakeFriction, int airFriction, int crashFriction)
    {
        this.TIRE_FRICTION_NOMINATOR = FrictionData.getFrictionDenominator() - tireFriction;
        this.BRAKE_FRICTION_NOMINATOR = FrictionData.getFrictionDenominator() - brakeFriction;
        this.AIR_FRICTION_NOMINATOR = FrictionData.getFrictionDenominator() - airFriction;
        this.CRASH_FRICTION_NOMINATOR = FrictionData.getFrictionDenominator() - crashFriction;
    }

    public virtual int getTireFrictionNominator()
    {
        return this.TIRE_FRICTION_NOMINATOR;
    }

    public virtual int getBrakeFrictionNominator()
    {
        return this.BRAKE_FRICTION_NOMINATOR;
    }

    public virtual int getAirFrictionNominator()
    {
        return this.AIR_FRICTION_NOMINATOR;
    }

    public virtual int getCrashFrictionNominator()
    {
        return this.CRASH_FRICTION_NOMINATOR;
    }

}

