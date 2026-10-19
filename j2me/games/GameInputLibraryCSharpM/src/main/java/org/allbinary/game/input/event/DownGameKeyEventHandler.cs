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

public class DownGameKeyEventHandler : DownGameKeyEventHandlerBase
{
    private static readonly DownGameKeyEventHandler instance = new DownGameKeyEventHandler();
    private static readonly DownGameKeyEventHandlerBase[] instanceArray = new DownGameKeyEventHandlerBase[] { new DownGameKeyEventHandlerBase(), new DownGameKeyEventHandlerBase(), new DownGameKeyEventHandlerBase(), new DownGameKeyEventHandlerBase(), new DownGameKeyEventHandlerBase(), new DownGameKeyEventHandlerBase() };
    public static DownGameKeyEventHandler getInstance()
    {
        return DownGameKeyEventHandler.instance;
    }

    private readonly LocalPlayerInputIdFactory playerInputIdFactory = LocalPlayerInputIdFactory.getInstance();
    public virtual DownGameKeyEventHandlerBase getInstanceForDevice(int deviceId)
    {
        int playerInputId = this.playerInputIdFactory.getPlayerForDevice(deviceId);
        return DownGameKeyEventHandler.instanceArray[playerInputId];
    }

    public virtual DownGameKeyEventHandlerBase getInstanceForPlayer(int playerInputId)
    {
        return DownGameKeyEventHandler.instanceArray[playerInputId];
    }

    private DownGameKeyEventHandler()
    {
    }

    public override void removeAllListeners()
    {
        base.removeAllListeners();
        for (int index = DownGameKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            DownGameKeyEventHandler.instanceArray[index].removeAllListeners();
        }
    }

    public override void removeListenerSingleThreaded(EventListenerInterface eventListenerInterface)
    {
        base.removeListenerSingleThreaded(eventListenerInterface);
        for (int index = DownGameKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            DownGameKeyEventHandler.instanceArray[index].removeListenerSingleThreaded(eventListenerInterface);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void removeListener(EventListenerInterface eventListenerInterface)
    {
        base.removeListener(eventListenerInterface);
        for (int index = DownGameKeyEventHandler.instanceArray.Length - 1; index >= 0; index--) {
            DownGameKeyEventHandler.instanceArray[index].removeListener(eventListenerInterface);
        }
    }

}

