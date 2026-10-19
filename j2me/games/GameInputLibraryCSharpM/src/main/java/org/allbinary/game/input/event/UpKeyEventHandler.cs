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
using LocalPlayerInputIdFactory = org.allbinary.game.input.LocalPlayerInputIdFactory;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;

namespace org.allbinary.game.input.@event;

public class UpKeyEventHandler : UpKeyEventHandlerBase
{
    private static readonly UpKeyEventHandler instance = new UpKeyEventHandler();
    private static readonly UpKeyEventHandlerBase[] instanceArray = new UpKeyEventHandlerBase[] { new UpKeyEventHandlerBase(), new UpKeyEventHandlerBase(), new UpKeyEventHandlerBase(), new UpKeyEventHandlerBase(), new UpKeyEventHandlerBase(), new UpKeyEventHandlerBase() };
    public static UpKeyEventHandler getInstance()
    {
        return UpKeyEventHandler.instance;
    }

    private readonly LocalPlayerInputIdFactory playerInputIdFactory = LocalPlayerInputIdFactory.getInstance();
    public virtual UpKeyEventHandlerBase getInstanceForDevice(int deviceId)
    {
        int playerInputId = this.playerInputIdFactory.getPlayerForDevice(deviceId);
        return UpKeyEventHandler.instanceArray[playerInputId];
    }

    public virtual UpKeyEventHandlerBase getInstanceForPlayer(int playerInputId)
    {
        return UpKeyEventHandler.instanceArray[playerInputId];
    }

    private UpKeyEventHandler()
    {
    }

    public override void removeAllListeners()
    {
        base.removeAllListeners();
        for (int index = UpKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            UpKeyEventHandler.instanceArray[index].removeAllListeners();
        }
    }

    public override void removeListenerSingleThreaded(EventListenerInterface eventListenerInterface)
    {
        base.removeListenerSingleThreaded(eventListenerInterface);
        for (int index = UpKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            UpKeyEventHandler.instanceArray[index].removeListenerSingleThreaded(eventListenerInterface);
        }
    }

    public override void removeListener(EventListenerInterface eventListenerInterface)
    {
        base.removeListener(eventListenerInterface);
        for (int index = UpKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            UpKeyEventHandler.instanceArray[index].removeListener(eventListenerInterface);
        }
    }

}

