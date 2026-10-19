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
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;

namespace org.allbinary.input.@event;

public class VirtualKeyboardEventHandler : BasicEventHandler
{
    private static readonly VirtualKeyboardEventHandler gameKeyEventHandler = new VirtualKeyboardEventHandler();
    private VirtualKeyboardEventHandler()
    {
    }

    public readonly VirtualKeyboardEvent SHOW_EVENT = new VirtualKeyboardEvent(BooleanFactory.getInstance().TRUE);
    public readonly VirtualKeyboardEvent HIDE_EVENT = new VirtualKeyboardEvent(BooleanFactory.getInstance().FALSE);
    public static VirtualKeyboardEventHandler getInstance()
    {
        return VirtualKeyboardEventHandler.gameKeyEventHandler;
    }

    // throws Exception
    protected override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        VirtualKeyboardEventListenerInterface virtualKeyboardEventListenerInterface = ((VirtualKeyboardEventListenerInterface) eventListenerInterface);
        virtualKeyboardEventListenerInterface.onVirtualKeyboardEvent(((VirtualKeyboardEvent) eventObject));
    }

    public virtual void open()
    {
        try {
            System.Threading.Thread.Sleep((int) (120));
            this.fireEvent(this.SHOW_EVENT);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "open", e);
        }
    }

    // throws Exception
    public virtual void close()
    {
        try {
            System.Threading.Thread.Sleep((int) (120));
            this.fireEvent(this.HIDE_EVENT);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CLOSE, e);
        }
    }

}

