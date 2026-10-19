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
using FrictionData = org.allbinary.game.physics.friction.FrictionData;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTrackFrictionProperties
{
    private readonly int ROAD_FRICTION_NOMINATOR;
    private readonly int GROUND_FRICTION_NOMINATOR;
    public RaceTrackFrictionProperties(int roadFriction, int groundFriction)
    {
        this.ROAD_FRICTION_NOMINATOR = FrictionData.getFrictionDenominator() - roadFriction;
        this.GROUND_FRICTION_NOMINATOR = FrictionData.getFrictionDenominator() - groundFriction;
    }

    public virtual int getRoadFrictionNominator()
    {
        return this.ROAD_FRICTION_NOMINATOR;
    }

    public virtual int getGroundFrictionNominator()
    {
        return this.GROUND_FRICTION_NOMINATOR;
    }

}

