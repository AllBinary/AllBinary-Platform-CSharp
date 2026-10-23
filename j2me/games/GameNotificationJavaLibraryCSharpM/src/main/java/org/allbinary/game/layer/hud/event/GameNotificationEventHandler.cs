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
using NullEventListener = org.allbinary.logic.util.@event.NullEventListener;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer.hud.@event;

public class GameNotificationEventHandler : BasicEventHandler
{
    private static readonly GameNotificationEventHandler instance = new GameNotificationEventHandler();
    private GameNotificationEventHandler()
    {
    }

    public bool enabled = true;
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void removeAllListeners()
    {
        EventListenerInterface eventListenerInterface = NullEventListener.NULL_EVENT_LISTENER;
        BasicArrayList list = this.eventListenerInterfaceList;
        if (list.size() > 0) {
            eventListenerInterface = ((EventListenerInterface) list.objectArray[0]);
        }
        base.removeAllListeners();
        if (eventListenerInterface != NullEventListener.NULL_EVENT_LISTENER) {
            this.addListenerInterface(eventListenerInterface);
        }
    }

    public static GameNotificationEventHandler getInstance()
    {
        return GameNotificationEventHandler.instance;
    }

    // throws Exception
    public override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        if (!this.enabled) {
            return;
        }
        GameNotificationListenerInterface gameNotificationListenerInterface = ((GameNotificationListenerInterface) eventListenerInterface);
        gameNotificationListenerInterface.onGameNotificationEvent(((GameNotificationEvent) eventObject));
    }

}

