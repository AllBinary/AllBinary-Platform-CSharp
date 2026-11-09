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
using GameAdStateBase = org.allbinary.business.advertisement.GameAdStateBase;
using AdConfiguration = org.allbinary.business.advertisement.AdConfiguration;
using VirtualKeyboardEvent = org.allbinary.input.@event.VirtualKeyboardEvent;
using VirtualKeyboardEventHandler = org.allbinary.input.@event.VirtualKeyboardEventHandler;
using VirtualKeyboardEventListenerInterface = org.allbinary.input.@event.VirtualKeyboardEventListenerInterface;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game;

public class GameAdState : GameAdStateBase, VirtualKeyboardEventListenerInterface
{
    public GameAdState(AdConfiguration adConfiguration) : base(adConfiguration)
    {
        // base(adConfiguration) is called from the constructor declaration
        VirtualKeyboardEventHandler.getInstance().addListenerInterface(this);
    }

    // throws Exception
    public virtual void onVirtualKeyboardEvent(VirtualKeyboardEvent virtualKeyboardEvent)
    {
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        base.onEvent(eventObject);
    }

}

