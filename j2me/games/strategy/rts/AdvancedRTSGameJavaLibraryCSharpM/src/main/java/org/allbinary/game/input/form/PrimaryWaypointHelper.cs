/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using NullPathFindingLayer = org.allbinary.game.layer.NullPathFindingLayer;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using WaypointLayer = org.allbinary.game.layer.waypoint.WaypointLayer;

namespace org.allbinary.game.input.form;

public class PrimaryWaypointHelper
{
    private static readonly PrimaryWaypointHelper instance = new PrimaryWaypointHelper();
    public static PrimaryWaypointHelper getInstance()
    {
        return PrimaryWaypointHelper.instance;
    }

    private PathFindingLayerInterface waypointLayer = NullPathFindingLayer.NULL_PATH_FINDING_LAYER;
    private PrimaryWaypointHelper()
    {
    }

    public virtual PathFindingLayerInterface getWaypointLayer()
    {
        return this.waypointLayer;
    }

    public virtual void setWaypointLayer(WaypointLayer waypointLayer)
    {
        this.waypointLayer = waypointLayer;
    }

}

