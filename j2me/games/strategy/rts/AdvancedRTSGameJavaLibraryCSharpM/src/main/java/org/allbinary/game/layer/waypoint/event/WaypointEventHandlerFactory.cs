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
using Group = org.allbinary.game.identification.Group;

namespace org.allbinary.game.layer.waypoint.@event;

public class WaypointEventHandlerFactory
{
    private static readonly WaypointEventHandler[] eventHandlerArray = new WaypointEventHandler[] { new WaypointEventHandler(), new WaypointEventHandler(), new WaypointEventHandler(), new WaypointEventHandler(), new WaypointEventHandler(), new WaypointEventHandler(), new WaypointEventHandler(), new WaypointEventHandler(), new WaypointEventHandler(), new WaypointEventHandler() };
    public static WaypointEventHandler getInstance(Group groupInterface)
    {
        return WaypointEventHandlerFactory.eventHandlerArray[((int) groupInterface.getGroupId())];
    }

    public static void removeAll()
    {
        for (int index = WaypointEventHandlerFactory.eventHandlerArray.Length - 1; index >= 0; index--) {
            WaypointEventHandlerFactory.eventHandlerArray[index].removeAllListeners();
        }
    }

}

