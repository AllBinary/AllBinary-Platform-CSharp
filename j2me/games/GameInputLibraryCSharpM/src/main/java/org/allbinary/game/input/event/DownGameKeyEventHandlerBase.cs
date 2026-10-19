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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input.@event;

public class DownGameKeyEventHandlerBase : BasicEventHandler
{
    private readonly BasicArrayList list = new BasicArrayListD();
    public DownGameKeyEventHandlerBase()
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
    public override void fireEvent(AllBinaryEventObject eventObject)
    {
        for (int index = this.list.size(); --index >= 0; ) {
            try {
                PlayerGameInput playerGameInput = ((PlayerGameInput) this.list.objectArray[index]);
                playerGameInput.onDownGameKeyEvent(((GameKeyEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        base.fireEvent(eventObject);
    }

    // throws Exception
    protected override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        DownGameKeyEventListenerInterface downGameKeyEventListenerInterface = ((DownGameKeyEventListenerInterface) eventListenerInterface);
        downGameKeyEventListenerInterface.onDownGameKeyEvent(((GameKeyEvent) eventObject));
    }

    private static readonly string TOTAL_LISTENERS = " Total PlayerGameInput Listeners: ";
    private static readonly string LISTENER_LABEL = " PlayerGameInput Listener: ";
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(base.ToString());
        stringBuffer.append(DownGameKeyEventHandlerBase.TOTAL_LISTENERS);
        stringBuffer.appendint(this.list.size());
        EventListenerInterface eventListenerInterface = null;
        int size = this.list.size();
        int index = 0;
        while (index < size) {
            try {
                eventListenerInterface = ((EventListenerInterface) this.list.get(index));
                stringBuffer.append(DownGameKeyEventHandlerBase.LISTENER_LABEL);
                stringBuffer.append(eventListenerInterface.ToString());
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.TOSTRING, e);
            }
            index++;
        }
        return stringBuffer.ToString();
    }

}

