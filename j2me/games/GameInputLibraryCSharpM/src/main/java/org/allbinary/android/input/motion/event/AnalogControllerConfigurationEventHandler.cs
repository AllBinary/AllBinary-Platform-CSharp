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
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.android.input.motion.@event;

public class AnalogControllerConfigurationEventHandler : BasicEventHandler
{
    private static readonly AnalogControllerConfigurationEventHandler instance = new AnalogControllerConfigurationEventHandler();
    public static AnalogControllerConfigurationEventHandler getInstance()
    {
        return AnalogControllerConfigurationEventHandler.instance;
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    private AnalogControllerConfigurationEventHandler()
    {
    }

    public virtual void addListener(AnalogControllerConfigurationEventListenerInterface analogControllerConfigurationEventListenerInterface)
    {
        if (!this.list.contains(analogControllerConfigurationEventListenerInterface)) {
            this.list.add(analogControllerConfigurationEventListenerInterface);
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
                AnalogControllerConfigurationEventListenerInterface playerGameInput = ((AnalogControllerConfigurationEventListenerInterface) this.list.objectArray[index]);
                playerGameInput.onAnalogControllerConfigurationEvent(((AnalogControllerConfigurationEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        base.fireEvent(eventObject);
    }

    // throws Exception
    public override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        AnalogControllerConfigurationEventListenerInterface analogControllerConfigurationEventListenerInterface = (((AnalogControllerConfigurationEventListenerInterface) eventListenerInterface));
        analogControllerConfigurationEventListenerInterface.onAnalogControllerConfigurationEvent(((AnalogControllerConfigurationEvent) eventObject));
    }

}

