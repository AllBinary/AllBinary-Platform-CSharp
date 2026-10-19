/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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

namespace org.allbinary.game.input.mapping.@event;

public class NullInputMappingEventListener : InputMappingEventListenerInterface
{
    public static readonly NullInputMappingEventListener NULL_INPUT_MAPPING_EVENT_LISTENER = new NullInputMappingEventListener();
    // throws Exception
    public virtual void onInputMappingEvent(InputMappingEvent inputMappingEvent)
    {
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
    }

}

