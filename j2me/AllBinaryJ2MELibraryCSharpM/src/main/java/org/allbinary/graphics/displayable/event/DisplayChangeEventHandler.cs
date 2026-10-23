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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;

namespace org.allbinary.graphics.displayable.@event;

public class DisplayChangeEventHandler : BasicEventHandler
{
    private static readonly DisplayChangeEventHandler SINGLETON = new DisplayChangeEventHandler();
    public static DisplayChangeEventHandler getInstance()
    {
        return DisplayChangeEventHandler.SINGLETON;
    }

    private DisplayChangeEventHandler()
    {
    }

    // throws Exception
    public override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        DisplayChangeEventListener displayChangeEventListener = (((DisplayChangeEventListener) eventListenerInterface));
        displayChangeEventListener.onDisplayChangeEvent(((DisplayChangeEvent) eventObject));
    }

}

