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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;

namespace org.allbinary.graphics.displayable.@event;

public class LastDisplayChangeEventHandler : BasicEventHandler
{
    private static readonly LastDisplayChangeEventHandler SINGLETON = new LastDisplayChangeEventHandler();
    public static LastDisplayChangeEventHandler getInstance()
    {
        return LastDisplayChangeEventHandler.SINGLETON;
    }

    private LastDisplayChangeEventHandler()
    {
    }

    // throws Exception
    protected override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        DisplayChangeEventListener displayChangeEventListener = (((DisplayChangeEventListener) eventListenerInterface));
        displayChangeEventListener.onDisplayChangeEvent(((DisplayChangeEvent) eventObject));
    }

}

