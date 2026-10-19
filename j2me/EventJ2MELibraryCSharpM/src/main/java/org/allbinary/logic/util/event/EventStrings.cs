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

namespace org.allbinary.logic.util.@event;

public class EventStrings
{
    private static readonly EventStrings instance = new EventStrings();
    public static EventStrings getInstance()
    {
        return EventStrings.instance;
    }

    public readonly string PERFORMANCE_MESSAGE = "Use Custom onEvent Methods for needed optimization";
    public readonly string TOTAL_LISTENERS = "Total Listeners: ";
    public readonly string LISTENER_LABEL = " Listener: ";
    public readonly string FIRE_EVENT = "fireEvent";
}

