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
//using JsType = jsinterop.annotations.JsType;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.logic.util.@event.handler;

public class BasicEventHandler : BasicEventHandlerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly EventStrings eventStrings = EventStrings.getInstance();
    public BasicArrayList eventListenerInterfaceList;
    public BasicEventHandler()
    {
        this.eventListenerInterfaceList = new BasicArrayListD();
    }

    public virtual void removeAllListeners()
    {
        this.eventListenerInterfaceList = new BasicArrayListD();
    }

    public virtual void addListeners(BasicArrayList vector)
    {
        EventListenerInterface eventListenerInterface = null;
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            eventListenerInterface = ((EventListenerInterface) vector.get(index));
            this.addListenerInterface(eventListenerInterface);
        }
    }

    public virtual void removeListeners(BasicArrayList vector)
    {
        EventListenerInterface eventListenerInterface = null;
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            eventListenerInterface = ((EventListenerInterface) vector.get(index));
            this.removeListener(eventListenerInterface);
        }
    }

    public virtual void addListenerSingleThreaded(EventListenerInterface eventListenerInterface)
    {
        if (!this.eventListenerInterfaceList.contains(eventListenerInterface)) {
            this.eventListenerInterfaceList.add(eventListenerInterface);
        }
    }

    public virtual void addListenerInterface(EventListenerInterface eventListenerInterface)
    {
        if (!this.eventListenerInterfaceList.contains(eventListenerInterface)) {
            this.eventListenerInterfaceList.add(eventListenerInterface);
        }
    }

    public virtual void removeListenerSingleThreaded(EventListenerInterface eventListenerInterface)
    {
        this.eventListenerInterfaceList.remove(eventListenerInterface);
    }

    public virtual void removeListener(EventListenerInterface eventListenerInterface)
    {
        this.eventListenerInterfaceList.remove(eventListenerInterface);
    }

    // throws Exception
    public virtual void fireEvent(AllBinaryEventObject eventObject)
    {
        EventListenerInterface eventListenerInterface = null;
        int index = 0;
        while (index < this.eventListenerInterfaceList.size()) {
            try {
                eventListenerInterface = ((EventListenerInterface) this.eventListenerInterfaceList.get(index));
                this.process(eventObject, eventListenerInterface);
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.eventStrings.FIRE_EVENT, e);
            }
            index++;
        }
    }

    // throws Exception
    public virtual void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        eventListenerInterface.onEvent(eventObject);
    }

    public virtual BasicArrayList getEventListenerInterfaceListP()
    {
        return this.eventListenerInterfaceList;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.eventStrings.TOTAL_LISTENERS);
        stringBuffer.appendint(this.eventListenerInterfaceList.size());
        EventListenerInterface eventListenerInterface = null;
        int index = 0;
        while (index < this.eventListenerInterfaceList.size()) {
            try {
                eventListenerInterface = ((EventListenerInterface) this.eventListenerInterfaceList.get(index));
                stringBuffer.append(this.eventStrings.LISTENER_LABEL);
                stringBuffer.append(eventListenerInterface.ToString());
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.TOSTRING, e);
            }
            index++;
        }
        return stringBuffer.ToString();
    }

}

