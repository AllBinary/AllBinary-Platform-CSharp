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
using System.Runtime.CompilerServices;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using MiniMapLayer = org.allbinary.game.layer.geographic.map.MiniMapLayer;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;

namespace org.allbinary.media.graphics.geography.map.@event;

public class GeographicMapCellPositionEventHandler : BasicEventHandler
{
    private static GeographicMapCellPositionEventHandler instance = new GeographicMapCellPositionEventHandler();
    public static GeographicMapCellPositionEventHandler getInstance()
    {
        return GeographicMapCellPositionEventHandler.instance;
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    private GeographicMapCellPositionEventHandler()
    {
    }

    public virtual void addListener(MiniMapLayer miniMapLayer)
    {
        if (!this.list.contains(miniMapLayer)) {
            this.list.add(miniMapLayer);
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
                MiniMapLayer miniMapLayer = ((MiniMapLayer) this.list.get(index));
                miniMapLayer.onGeographicMapCellPositionEvent(((GeographicMapCellPositionEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        base.fireEvent(eventObject);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void fireRemoveEvent(AllBinaryEventObject eventObject)
    {
        BasicArrayList list = this.eventListenerInterfaceList;
        for (int index = this.list.size(); --index >= 0; ) {
            try {
                MiniMapLayer miniMapLayer = ((MiniMapLayer) this.list.get(index));
                miniMapLayer.onRemoveGeographicMapCellPositionEvent(((GeographicMapCellPositionEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        EventListenerInterface eventListenerInterface = null;
        GeographicMapCellPositionEventListenerInterface geographicMapCellPositionEventListenerInterface = null;
        int size = list.size();
        for (int index = 0; index < size; index++) {
            try {
                eventListenerInterface = ((EventListenerInterface) list.get(index));
                geographicMapCellPositionEventListenerInterface = (((GeographicMapCellPositionEventListenerInterface) eventListenerInterface));
                geographicMapCellPositionEventListenerInterface.onRemoveGeographicMapCellPositionEvent(((GeographicMapCellPositionEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
    }

    // throws Exception
    public override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        GeographicMapCellPositionEventListenerInterface geographicMapCellPositionEventListenerInterface = (((GeographicMapCellPositionEventListenerInterface) eventListenerInterface));
        geographicMapCellPositionEventListenerInterface.onGeographicMapCellPositionEvent(((GeographicMapCellPositionEvent) eventObject));
    }

}

