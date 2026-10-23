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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input.@event;

public class RawKeyEventHandler
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly RawKeyEventHandler instance = new RawKeyEventHandler();
    public static RawKeyEventHandler getInstance()
    {
        return RawKeyEventHandler.instance;
    }

    public BasicArrayList eventListenerInterfaceList;
    public RawKeyEventHandler()
    {
        this.eventListenerInterfaceList = new BasicArrayListD();
    }

    public virtual void removeAllListeners()
    {
        this.eventListenerInterfaceList = new BasicArrayListD();
    }

    public virtual void addListeners(BasicArrayList vector)
    {
        RawKeyEventListener eventListenerInterface = null;
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            eventListenerInterface = ((RawKeyEventListener) vector.get(index));
            this.addListener(eventListenerInterface);
        }
    }

    public virtual void addListenerSingleThreaded(RawKeyEventListener eventListenerInterface)
    {
        if (!this.eventListenerInterfaceList.contains(eventListenerInterface)) {
            this.eventListenerInterfaceList.add(eventListenerInterface);
        }
    }

    public virtual void addListener(RawKeyEventListener eventListenerInterface)
    {
        if (!this.eventListenerInterfaceList.contains(eventListenerInterface)) {
            this.eventListenerInterfaceList.add(eventListenerInterface);
        }
    }

    public virtual void removeListenerSingleThreaded(RawKeyEventListener eventListenerInterface)
    {
        this.eventListenerInterfaceList.remove(eventListenerInterface);
    }

    public virtual void removeListener(RawKeyEventListener eventListenerInterface)
    {
        this.eventListenerInterfaceList.remove(eventListenerInterface);
    }

    // throws Exception
    public virtual void fireEvent(int keyCode, int deviceId, bool repeated)
    {
        RawKeyEventListener eventListenerInterface = null;
        int index = 0;
        while (index < this.eventListenerInterfaceList.size()) {
            try {
                eventListenerInterface = ((RawKeyEventListener) this.eventListenerInterfaceList.get(index));
                this.process(keyCode, deviceId, repeated, eventListenerInterface);
            } catch (Exception e) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
            index++;
        }
    }

    // throws Exception
    public virtual void process(int keyCode, int deviceId, bool repeated, RawKeyEventListener eventListenerInterface)
    {
        eventListenerInterface.onEventRaw(keyCode, deviceId, repeated);
    }

    public virtual BasicArrayList getEventListenerInterfaceListP()
    {
        return this.eventListenerInterfaceList;
    }

    private static readonly string TOTAL_LISTENERS = "Total Listeners: ";
    private static readonly string LISTENER_LABEL = " Listener: ";
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(RawKeyEventHandler.TOTAL_LISTENERS);
        stringBuffer.appendint(this.eventListenerInterfaceList.size());
        RawKeyEventListener eventListenerInterface = null;
        int index = 0;
        while (index < this.eventListenerInterfaceList.size()) {
            try {
                eventListenerInterface = ((RawKeyEventListener) this.eventListenerInterfaceList.get(index));
                stringBuffer.append(RawKeyEventHandler.LISTENER_LABEL);
                stringBuffer.append(eventListenerInterface.ToString());
            } catch (Exception e) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.TOSTRING, e);
            }
            index++;
        }
        return stringBuffer.ToString();
    }

}

