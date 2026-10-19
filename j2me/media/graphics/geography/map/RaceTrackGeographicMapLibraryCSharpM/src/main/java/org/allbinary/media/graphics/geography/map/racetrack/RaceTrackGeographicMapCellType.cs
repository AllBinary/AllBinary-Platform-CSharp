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
using CommonStrings = org.allbinary.@string.CommonStrings;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTrackGeographicMapCellType : GeographicMapCellType
{
    public readonly string name;
    private readonly int travelCost;
    public RaceTrackGeographicMapCellType(string name, int type, int travelCost, int reset) : base(type, reset)
    {
        // base(type, reset) is called from the constructor declaration
        this.name = name;
        this.travelCost = travelCost;
    }

    public virtual int getTravelCost()
    {
        return this.travelCost;
    }

}

