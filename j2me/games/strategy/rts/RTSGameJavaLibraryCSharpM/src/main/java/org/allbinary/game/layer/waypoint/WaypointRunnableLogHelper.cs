/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;

namespace org.allbinary.game.layer.waypoint;

public class WaypointRunnableLogHelper
{
    private static readonly WaypointRunnableLogHelper instance = new WaypointRunnableLogHelper();
    public static WaypointRunnableLogHelper getInstance()
    {
        return WaypointRunnableLogHelper.instance;
    }

    public virtual void start(PathFindingLayerInterface pathFindingLayerInterface)
    {
    }

    public virtual void end(PathFindingLayerInterface pathFindingLayerInterface)
    {
    }

}

