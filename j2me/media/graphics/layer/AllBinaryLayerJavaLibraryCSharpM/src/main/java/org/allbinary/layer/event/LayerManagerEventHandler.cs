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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.layer.@event;

public class LayerManagerEventHandler : BasicEventHandler
{
    private static LayerManagerEventHandler instance = new LayerManagerEventHandler();
    public static LayerManagerEventHandler getInstance()
    {
        return LayerManagerEventHandler.instance;
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    private LayerManagerEventHandler()
    {
    }

    public virtual void addListener(LayerManagerEventListener layerManagerEventListener)
    {
        if (!this.list.contains(layerManagerEventListener)) {
            this.list.add(layerManagerEventListener);
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
                LayerManagerEventListener layerManagerEventListener = ((LayerManagerEventListener) this.list.objectArray[index]);
                layerManagerEventListener.onCreateLayerManagerEvent(((LayerManagerEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        base.fireEvent(eventObject);
    }

    public readonly string CREATE = "Create";
    public readonly string DELETE = "Delete";
    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void fireDeleteEvent(AllBinaryEventObject eventObject)
    {
        for (int index = this.list.size(); --index >= 0; ) {
            try {
                LayerManagerEventListener layerManagerEventListener = ((LayerManagerEventListener) this.list.objectArray[index]);
                layerManagerEventListener.onDeleteLayerManagerEvent(((LayerManagerEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        BasicArrayList eventListenerInterfaceList = this.eventListenerInterfaceList;
        EventListenerInterface eventListenerInterface = null;
        LayerManagerEventListenerInterface layerManagerEventListenerInterface = null;
        int index = 0;
        while (index < eventListenerInterfaceList.size()) {
            try {
                eventListenerInterface = ((EventListenerInterface) eventListenerInterfaceList.objectArray[index]);
                layerManagerEventListenerInterface = (((LayerManagerEventListenerInterface) eventListenerInterface));
                layerManagerEventListenerInterface.onDeleteLayerManagerEvent(((LayerManagerEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
            index++;
        }
    }

    // throws Exception
    public override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        LayerManagerEventListenerInterface layerManagerEventListenerInterface = (((LayerManagerEventListenerInterface) eventListenerInterface));
        layerManagerEventListenerInterface.onCreateLayerManagerEvent(((LayerManagerEvent) eventObject));
    }

}

