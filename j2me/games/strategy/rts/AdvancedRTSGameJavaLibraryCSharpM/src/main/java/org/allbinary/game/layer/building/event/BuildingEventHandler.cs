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
using RTSLayerEvent = org.allbinary.game.layer.RTSLayerEvent;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;

namespace org.allbinary.game.layer.building.@event;

public class BuildingEventHandler : BasicEventHandler
{
    private static BuildingEventHandler eventHandler = new BuildingEventHandler();
    private BuildingEventHandler()
    {
    }

    public static BuildingEventHandler getInstance()
    {
        return BuildingEventHandler.eventHandler;
    }

    // throws Exception
    public override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        BuildingEventListenerInterface buildingEventListenerInterface = (((BuildingEventListenerInterface) eventListenerInterface));
        buildingEventListenerInterface.onBuildingEvent(((RTSLayerEvent) eventObject));
    }

}

