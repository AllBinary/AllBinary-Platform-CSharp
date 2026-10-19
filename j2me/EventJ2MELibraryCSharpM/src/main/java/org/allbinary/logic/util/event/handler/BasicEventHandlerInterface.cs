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
//using JsType = jsinterop.annotations.JsType;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;
//using JsMethod = jsinterop.annotations.JsMethod;

namespace org.allbinary.logic.util.@event.handler;

public interface BasicEventHandlerInterface
{
    void addListenerInterface(EventListenerInterface eventListenerInterface);

    void addListeners(BasicArrayList basicArrayList);

    // throws Exception
    void fireEvent(AllBinaryEventObject eventObject);

    void removeAllListeners();

    void removeListener(EventListenerInterface eventListenerInterface);

}

