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
using Angle = org.allbinary.math.Angle;
using AngleFactory = org.allbinary.math.AngleFactory;

namespace org.allbinary.game.terrain;

public class BasicTerrainInfo
{
    public static readonly BasicTerrainInfo NULL_BASIC_TERRAIN_INFO = new BasicTerrainInfo(AngleFactory.getInstance().NOT_ANGLE);
    private Angle angle;
    public BasicTerrainInfo(Angle angle)
    {
        this.angle = angle;
    }

    public virtual Angle getAngle()
    {
        return this.angle;
    }

    public virtual void setAngle(Angle angle)
    {
        this.angle = angle;
    }

}

