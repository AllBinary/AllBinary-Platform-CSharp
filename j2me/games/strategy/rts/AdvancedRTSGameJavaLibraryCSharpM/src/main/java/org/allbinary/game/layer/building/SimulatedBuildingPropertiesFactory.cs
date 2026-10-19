/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using DamageFloaters = org.allbinary.game.combat.damage.DamageFloaters;
using TrackingEvent = org.allbinary.game.tracking.TrackingEvent;
using TrackingEventHandler = org.allbinary.game.tracking.TrackingEventHandler;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.game.layer.building;

public class SimulatedBuildingPropertiesFactory : BuildingPropertiesFactory
{
    private static readonly SimulatedBuildingPropertiesFactory instanceC = new SimulatedBuildingPropertiesFactory();
    public static SimulatedBuildingPropertiesFactory getInstance()
    {
        return SimulatedBuildingPropertiesFactory.instanceC;
    }

    public override int getEfficiencyPerLevel(BuildingLayer buildingLayer)
    {
        return 0;
    }

    public override DamageFloaters getDamageFloaters(BuildingLayer buildingLayer)
    {
        DamageFloaters damageFloaters = DamageFloaters.getInstance();
        this.damageFloatersPaintableInterface = damageFloaters;
        return damageFloaters;
    }

    // throws Exception
    public override Paintable getHealthBar(BuildingLayer buildingLayer)
    {
        return NullPaintable.getInstance();
    }

    public override ABHashtable<object, object> getHashtable()
    {
        return StdUtil.getInstance().NULL_TABLE;
    }

    public override TrackingEvent getTrackingEvent(BuildingLayer buildingLayer)
    {
        return new TrackingEvent(TrackingEventHandler.getInstance());
    }

}

