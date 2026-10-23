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
using StdUtil = org.allbinary.logic.StdUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.terrain;

public class TerrainEventHandler : BasicEventHandler
{
    private static ABHashtable<object, object> hashtable = StdUtil.getInstance().NULL_TABLE;
    public static void init()
    {
        TerrainEventHandler.hashtable = StdUtil.getInstance().createHashtable();
    }

    public static TerrainEventHandler getInstance(object anyType)
    {
        object eventHandlerCanBeNull = TerrainEventHandler.hashtable.get(anyType);
        if (eventHandlerCanBeNull == null) {
            eventHandlerCanBeNull = new TerrainEventHandler();
            TerrainEventHandler.hashtable.put(anyType, eventHandlerCanBeNull);
        }
        return ((TerrainEventHandler) eventHandlerCanBeNull);
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    private TerrainEventHandler()
    {
    }

    public virtual void addListener(TerrainEventListener terrainEventListener)
    {
        if (!this.list.contains(terrainEventListener)) {
            this.list.add(terrainEventListener);
        }
    }

    public override void removeAllListeners()
    {
        this.list.clear();
        base.removeAllListeners();
    }

    public override void removeListener(EventListenerInterface eventListenerInterface)
    {
        this.list.remove(eventListenerInterface);
        base.removeListener(eventListenerInterface);
    }

    // throws Exception
    public override void fireEvent(AllBinaryEventObject eventObject)
    {
        for (int index = this.list.size(); --index >= 0; ) {
            try {
                TerrainEventListener terrainEventListener = ((TerrainEventListener) this.list.get(index));
                terrainEventListener.onTerrainEvent(((TerrainEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        base.fireEvent(eventObject);
    }

    // throws Exception
    public override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        TerrainEventListenerInterface terrainEventListenerInterface = ((TerrainEventListenerInterface) eventListenerInterface);
        terrainEventListenerInterface.onTerrainEvent(((TerrainEvent) eventObject));
    }

}

