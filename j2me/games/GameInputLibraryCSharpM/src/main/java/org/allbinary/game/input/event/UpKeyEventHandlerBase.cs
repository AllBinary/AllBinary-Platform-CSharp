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
using PlayerGameInput = org.allbinary.game.input.PlayerGameInput;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input.@event;

public class UpKeyEventHandlerBase : BasicEventHandler
{
    private readonly BasicArrayList list = new BasicArrayListD();
    public UpKeyEventHandlerBase()
    {
    }

    public virtual void addListener(PlayerGameInput playerGameInput)
    {
        if (!this.list.contains(playerGameInput)) {
            this.list.add(playerGameInput);
        }
    }

    public override void removeAllListeners()
    {
        this.list.clear();
        base.removeAllListeners();
    }

    public override void removeListenerSingleThreaded(EventListenerInterface eventListenerInterface)
    {
        this.list.remove(eventListenerInterface);
        base.removeListenerSingleThreaded(eventListenerInterface);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void removeListener(EventListenerInterface eventListenerInterface)
    {
        this.list.remove(eventListenerInterface);
        base.removeListener(eventListenerInterface);
    }

    // throws Exception
    public virtual void fireEventForInteger(int? eventObject)
    {
        for (int index = this.list.size(); --index >= 0; ) {
            try {
                PlayerGameInput playerGameInput = ((PlayerGameInput) this.list.objectArray[index]);
                playerGameInput.onUpKeyEvent(eventObject);
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        int index = 0;
        EventListenerInterface eventListenerInterface = null;
        while (index < this.eventListenerInterfaceList.size()) {
            try {
                eventListenerInterface = ((EventListenerInterface) this.eventListenerInterfaceList.get(index));
                this.processForInteger(eventObject, eventListenerInterface);
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
            index++;
        }
    }

    // throws Exception
    public virtual void processForInteger(int? eventObject, EventListenerInterface eventListenerInterface)
    {
        UpKeyEventListenerInterface upKeyEventListenerInterface = ((UpKeyEventListenerInterface) eventListenerInterface);
        upKeyEventListenerInterface.onUpKeyEvent(eventObject);
    }

    private static readonly string TOTAL_LISTENERS = " Total PlayerGameInput Listeners: ";
    private static readonly string LISTENER_LABEL = " PlayerGameInput Listener: ";
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(base.ToString());
        stringBuffer.append(UpKeyEventHandlerBase.TOTAL_LISTENERS);
        stringBuffer.appendint(this.list.size());
        for (int index = 0; index < this.list.size(); index++) {
            try {
                EventListenerInterface eventListenerInterface = ((EventListenerInterface) this.list.get(index));
                stringBuffer.append(UpKeyEventHandlerBase.LISTENER_LABEL);
                stringBuffer.append(eventListenerInterface.ToString());
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.TOSTRING, e);
            }
        }
        return stringBuffer.ToString();
    }

}

