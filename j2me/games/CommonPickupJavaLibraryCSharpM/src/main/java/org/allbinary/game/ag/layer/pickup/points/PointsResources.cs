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

namespace org.allbinary.game.ag.layer.pickup.points;

public class PointsResources
{
    private static readonly PointsResources SINGLETON = new PointsResources();
    public string RESOURCE = "points_drop_20_by_20.png";
    public string RESOURCE_2 = "points_2_drop_20_by_20.png";
    public string RESOURCE_3 = "points_3_drop_20_by_20.png";
    public string RESOURCE_4 = "points_4_drop_20_by_20.png";
    private PointsResources()
    {
    }

    public static PointsResources getInstance()
    {
        return PointsResources.SINGLETON;
    }

}

