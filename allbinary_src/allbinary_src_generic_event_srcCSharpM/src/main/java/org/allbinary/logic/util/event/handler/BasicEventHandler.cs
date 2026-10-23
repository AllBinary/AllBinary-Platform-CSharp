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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.util.@event.handler;

public class BasicEventHandler : BasicEventHandlerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly string PERFORMANCE_MESSAGE = "Use Custom onEvent Methods for needed optimization";
    private BasicArrayList eventListenerInterfaceList;
    public BasicEventHandler()
    {
        this.eventListenerInterfaceList = new BasicArrayListD();
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        string LISTENER = " Listener: ";
        stringBuffer.append("Total Listeners: ");
        stringBuffer.appendint(this.eventListenerInterfaceList.size());
        EventListenerInterface eventListenerInterface = null;
        int index = 0;
        while (index < this.eventListenerInterfaceList.size()) {
            try {
                eventListenerInterface = ((EventListenerInterface) this.eventListenerInterfaceList.objectArray[index]);
                stringBuffer.append(LISTENER);
                stringBuffer.append(StringUtil.getInstance().toString(eventListenerInterface));
            } catch (Exception e) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.TOSTRING, e);
            }
            index++;
        }
        return stringBuffer.ToString();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void removeAllListeners()
    {
        this.eventListenerInterfaceList = new BasicArrayListD();
    }

    public virtual void addListenerSingleThreaded(EventListenerInterface eventListenerInterface)
    {
        if (!this.eventListenerInterfaceList.contains(eventListenerInterface)) {
            this.eventListenerInterfaceList.add(eventListenerInterface);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
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

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void removeListener(EventListenerInterface eventListenerInterface)
    {
        this.eventListenerInterfaceList.remove(eventListenerInterface);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void fireEvent(AllBinaryEventObject eventObject)
    {
        int index = 0;
        EventListenerInterface eventListenerInterface = null;
        while (index < this.eventListenerInterfaceList.size()) {
            try {
                eventListenerInterface = ((EventListenerInterface) this.eventListenerInterfaceList.objectArray[index]);
                this.process(eventObject, eventListenerInterface);
            } catch (Exception e) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
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

}

