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
using LocalPlayerInputIdFactory = org.allbinary.game.input.LocalPlayerInputIdFactory;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;

namespace org.allbinary.game.input.@event;

public class DownKeyEventHandler : DownKeyEventHandlerBase
{
    private static readonly DownKeyEventHandler instance = new DownKeyEventHandler();
    private static readonly DownKeyEventHandlerBase[] instanceArray = new DownKeyEventHandlerBase[] { new DownKeyEventHandlerBase(), new DownKeyEventHandlerBase(), new DownKeyEventHandlerBase(), new DownKeyEventHandlerBase(), new DownKeyEventHandlerBase(), new DownKeyEventHandlerBase() };
    public static DownKeyEventHandler getInstance()
    {
        return DownKeyEventHandler.instance;
    }

    private readonly LocalPlayerInputIdFactory playerInputIdFactory = LocalPlayerInputIdFactory.getInstance();
    public virtual DownKeyEventHandlerBase getInstanceForDevice(int deviceId)
    {
        int playerInputId = this.playerInputIdFactory.getPlayerForDevice(deviceId);
        return DownKeyEventHandler.instanceArray[playerInputId];
    }

    public virtual DownKeyEventHandlerBase getInstanceForPlayer(int playerInputId)
    {
        return DownKeyEventHandler.instanceArray[playerInputId];
    }

    private DownKeyEventHandler()
    {
    }

    public override void removeAllListeners()
    {
        base.removeAllListeners();
        for (int index = DownKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            DownKeyEventHandler.instanceArray[index].removeAllListeners();
        }
    }

    public override void removeListenerSingleThreaded(EventListenerInterface eventListenerInterface)
    {
        base.removeListenerSingleThreaded(eventListenerInterface);
        for (int index = DownKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            DownKeyEventHandler.instanceArray[index].removeListenerSingleThreaded(eventListenerInterface);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void removeListener(EventListenerInterface eventListenerInterface)
    {
        base.removeListener(eventListenerInterface);
        for (int index = DownKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            DownKeyEventHandler.instanceArray[index].removeListener(eventListenerInterface);
        }
    }

}

