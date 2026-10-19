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
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;

namespace org.allbinary.game.layer;

public class Driver
{
    public static readonly Driver NULL_DRIVER = new Driver(SmallIntegerSingletonFactory.getInstance().getAt(0), SmallIntegerSingletonFactory.getInstance().getAt(0), new Aggression(SmallIntegerSingletonFactory.getInstance().getAt(0), SmallIntegerSingletonFactory.getInstance().getAt(0), SmallIntegerSingletonFactory.getInstance().getAt(0)));
    private int? turnSpeed = SmallIntegerSingletonFactory.getInstance().getAt(0);
    private int? trackPathSelectionSkill = SmallIntegerSingletonFactory.getInstance().getAt(0);
    private Aggression aggression;
    public Driver(int? turnSpeed, int? trackPathSelectionSkill, Aggression aggression)
    {
        this.setTurnSpeed(turnSpeed);
        this.setTrackPathSelectionSkill(trackPathSelectionSkill);
        this.aggression = aggression;
    }

    public virtual int? getTurnSpeed()
    {
        return this.turnSpeed;
    }

    public virtual void setTurnSpeed(int? turnSpeed)
    {
        this.turnSpeed = turnSpeed;
    }

    public virtual int? getTrackPathSelectionSkill()
    {
        return this.trackPathSelectionSkill;
    }

    public virtual void setTrackPathSelectionSkill(int? trackPathSelectionSkill)
    {
        this.trackPathSelectionSkill = trackPathSelectionSkill;
    }

    public virtual Aggression getAggression()
    {
        return this.aggression;
    }

    public virtual void setAggression(Aggression aggression)
    {
        this.aggression = aggression;
    }

}

