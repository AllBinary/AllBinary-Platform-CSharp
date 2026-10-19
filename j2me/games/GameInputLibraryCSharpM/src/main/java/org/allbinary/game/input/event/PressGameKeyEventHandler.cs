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
using PlayerGameInput = org.allbinary.game.input.PlayerGameInput;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input.@event;

public class PressGameKeyEventHandler : BasicEventHandler
{
    private static readonly PressGameKeyEventHandler instance = new PressGameKeyEventHandler();
    public static PressGameKeyEventHandler getInstance()
    {
        return PressGameKeyEventHandler.instance;
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    private PressGameKeyEventHandler()
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
                playerGameInput.onPressGameKeyEvent(((GameKeyEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        base.fireEvent(eventObject);
    }

    // throws Exception
    protected override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        PressGameKeyEventListenerInterface pressGameKeyEventListenerInterface = (((PressGameKeyEventListenerInterface) eventListenerInterface));
        pressGameKeyEventListenerInterface.onPressGameKeyEvent(((GameKeyEvent) eventObject));
    }

}

